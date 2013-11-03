using BullsAndCows.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BullsAndCows.Models
{
    public class GamesRepository : BaseRepository
    {
        private const string MessageTextJoinedGame = "{0} joined your game {1}";
        private const string MessageTextStartedGame = "{0} started the game {1}";

        private static void ValidateGamePassword(string password)
        {
            if (password != null)
            {
                if (password.Length != Sha1CodeLength)
                {
                    throw new ServerErrorException("Invalid AuthCode", "ERR_INV_AUTH");
                }
            }
        }

        //Not implemented
        private static void ValidateGameTitle(string title)
        {
        }

        private static IEnumerable<GameModel> ParseGamesToModels(IEnumerable<Game> games)
        {
            var models =
                        from game in games
                        select new GameModel()
                        {
                            Id = (int)game.Id,
                            Title = game.Title,
                            CreatorNickname = game.RedUser.Nickname
                        };
            return models.ToList();
        }

        public static void CreateGame(int userId, CreateGameModel gameModel)
        {
            ValidateGameTitle(gameModel.Title);
            ValidateGamePassword(gameModel.Password);
            ValidateUserNumber(gameModel.Number);

            var context = new BullsAndCowsEntities();
            using (context)
            {
                var redUser = GetUser(userId, context);

                var gameOpenStatus = context.GameStatuses.First(st => st.Status == GameStatusOpen);

                var game = new Game()
                {
                    Title = gameModel.Title,
                    Password = gameModel.Password,
                    RedUser = redUser,
                    RedUserNumber = gameModel.Number,
                    GameStatus = gameOpenStatus
                };

                context.Games.Add(game);
                context.SaveChanges();
            }
        }

        public static void JoinGame(int userId, JoinGameModel gameModel)
        {
            ValidateGamePassword(gameModel.Password);
            ValidateUserNumber(gameModel.Number);

            var context = new BullsAndCowsEntities();
            using (context)
            {
                var game = GetGame(gameModel.Id, context);

                if (game.GameStatus.Status != GameStatusOpen)
                {
                    throw new ServerErrorException("Game is unavailable", "ERR_INV_GAME");
                }

                if (game.Password != gameModel.Password)
                {
                    throw new ServerErrorException("Incorrect game password", "ERR_BAD_PASS");
                }

                var blueUser = GetUser(userId, context);
                game.BlueUser = blueUser;
                game.BlueUserNumber = gameModel.Number;
                var fullGameStatus = context.GameStatuses.First(st => st.Status == GameStatusFull);
                game.GameStatus = fullGameStatus;

                MessageState unreadMessageState = context.MessageStates.First(ms => ms.State == MessageStateUnread);
                MessageType gameJoinedMessageType = context.MessageTypes.First(mt => mt.Type == MessageTypeGameJoined);
                var message = new Message()
                {
                    Text = string.Format(MessageTextJoinedGame, blueUser.Nickname, game.Title),
                    Game = game,
                    User = game.RedUser,
                    MessageState = unreadMessageState,
                    MessageType = gameJoinedMessageType
                };
                context.Messages.Add(message);
                context.SaveChanges();
            }
        }

        public static IEnumerable<GameModel> GetOpenGames(int userId)
        {
            var context = new BullsAndCowsEntities();
            using (context)
            {
                var user = GetUser(userId, context);

                var openGameStatus = context.GameStatuses.Include("Games").First(st => st.Status == GameStatusOpen);

                IEnumerable<GameModel> openGameModels;

                if (openGameStatus.Games.Any(g => g.RedUser != user))
                {
                    openGameModels = ParseGamesToModels(openGameStatus.Games.Where(g => g.RedUser != user));
                }
                else
                {
                    openGameModels = new List<GameModel>();
                }

                return openGameModels;
            }
        }

        public static IEnumerable<GameModel> GetActiveGames(int userId)
        {
            var context = new BullsAndCowsEntities();
            using (context)
            {
                var user = GetUser(userId, context);

                var inProgressGameStatus = context.GameStatuses.First(st => st.Status == GameStatusInProgress);
                var fullGameStatus = context.GameStatuses.First(st => st.Status == GameStatusFull);

                IEnumerable<GameModel> activeGameModels;


                var userGames =
                    from g in context.Games
                    where (g.RedUser == user || g.BlueUser == user) && (g.GameStatus == inProgressGameStatus || g.GameStatus == fullGameStatus)
                    select g;
                if (userGames.Any())
                {
                    activeGameModels = ParseGamesToModels(userGames);
                }
                else
                {
                    activeGameModels = new List<GameModel>();
                }

                return activeGameModels;
            }
        }

        public static void StartGame(int userId, int gameId)
        {
            var context = new BullsAndCowsEntities();
            using (context)
            {
                var redUser = GetUser(userId, context);
                var game = GetGame(gameId, context);

                if (game.RedUser != redUser)
                {
                    throw new ServerErrorException("You cannot start the game", "ERR_INV_OP");
                }
                var fullGameStatus = context.GameStatuses.First(st => st.Status == GameStatusFull);
                if (game.GameStatus != fullGameStatus)
                {
                    throw new ServerErrorException("Game cannot be started", "ERR_INV_OP");
                }
                var inProgressGameStatus = context.GameStatuses.First(st => st.Status == GameStatusInProgress);

                game.GameStatus = inProgressGameStatus;
                game.UserInTurn = rand.Next(2) == 0 ? game.RedUser.Id : game.BlueUser.Id;

                MessageState unreadMessageState = context.MessageStates.First(ms => ms.State == MessageStateUnread);
                MessageType gameStartedMessageType = context.MessageTypes.First(mt => mt.Type == MessageTypeGameStarted);
                var message = new Message()
                {
                    Text = string.Format(MessageTextStartedGame, redUser.Nickname, game.Title),
                    Game = game,
                    User = game.BlueUser,
                    MessageState = unreadMessageState,
                    MessageType = gameStartedMessageType
                };
                context.Messages.Add(message);
                context.SaveChanges();
            }
        }

        public static string GetUserInTurn(int gameId)
        {
            var context = new BullsAndCowsEntities();
            using (context)
            {
                var game = GetGame(gameId, context);
                if (game.GameStatus != context.GameStatuses.First(st => st.Status == GameStatusInProgress))
                {
                    throw new ServerErrorException("Game is not in progress", "ERR_INV_OP");
                }

                var userInTurn = game.UserInTurn == game.RedUser.Id ? game.RedUser.Nickname : game.BlueUser.Nickname;
                return userInTurn;

            }

        }

        public static GameStateModel GetGameState(int gameId, int userId)
        {
            var context = new BullsAndCowsEntities();
            using (context)
            {
                var user = GetUser(userId, context);
                var game = GetGame(gameId, context);

                if (game.GameStatus != context.GameStatuses.First((st) => st.Status == GameStatusInProgress))
                {
                    throw new ServerErrorException("Game is not in progress", "ERR_INV_OP");
                }

                if (game.RedUser != user && game.BlueUser != user)
                {
                    throw new ServerErrorException("User not in game", "ERR_INV_GAME");
                }

                var gameStateModel = new GameStateModel()
                {
                    Id = (int)game.Id,
                    Title = game.Title,
                    RedPlayer = game.RedUser.Nickname,
                    BluePlayer = game.BlueUser.Nickname,
                    PlayerInTurn = (game.RedUser.Id == game.UserInTurn) ? "red" : "blue",
                    RedPlayerGuesses = ParseGuessesToModels(game.Guesses.Where(g => g.User == game.RedUser)),
                    BluePlayerGuesses = ParseGuessesToModels(game.Guesses.Where(g => g.User == game.BlueUser))
                };
                return gameStateModel;
            }
        }

        private static IEnumerable<GuessDetailsModel> ParseGuessesToModels(IEnumerable<Guess> guesses)
        {
            var models =
                from guess in guesses
                select new GuessDetailsModel()
                {
                    Number = guess.Number,
                    Cows = guess.Cows,
                    Bulls = guess.Bulls
                };

            return models;
        }
    }
}