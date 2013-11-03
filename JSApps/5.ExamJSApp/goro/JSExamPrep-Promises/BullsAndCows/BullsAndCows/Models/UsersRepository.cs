using BullsAndCows.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Models
{
    public class UsersRepository : BaseRepository
    {
        private const string SessionKeyChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private const int SessionKeyLen = 50;

        private const string ValidUsernameChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_1234567890";
        private const string ValidNicknameChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_1234567890 -";
        private const int MinUsernameNicknameChars = 4;
        private const int MaxUsernameNicknameChars = 30;

        private static void ValidateSessionKey(string sessionKey)
        {
            if (sessionKey.Length != SessionKeyLen || sessionKey.Any(ch => !SessionKeyChars.Contains(ch)))
            {
                throw new ServerErrorException("Invalid Password", "ERR_INV_AUTH");
            }
        }

        private static string GenerateSessionKey(int userId)
        {
            StringBuilder keyChars = new StringBuilder(50);
            keyChars.Append(userId.ToString());
            while (keyChars.Length < SessionKeyLen)
            {
                int randomCharNum;
                lock (rand)
                {
                    randomCharNum = rand.Next(SessionKeyChars.Length);
                }
                char randomKeyChar = SessionKeyChars[randomCharNum];
                keyChars.Append(randomKeyChar);
            }
            string sessionKey = keyChars.ToString();
            return sessionKey;
        }

        private static void ValidateUsername(string username)
        {
            if (username == null || username.Length < MinUsernameNicknameChars || username.Length > MaxUsernameNicknameChars)
            {
                throw new ServerErrorException("Username should be between 4 and 30 symbols long", "ERR_INV_USR");
            }
            else if (username.Any(ch => !ValidUsernameChars.Contains(ch)))
            {
                throw new ServerErrorException("Username contains invalid characters", "ERR_INV_USR");
            }
        }

        private static void ValidateNickname(string nickname)
        {
            if (nickname == null || nickname.Length < MinUsernameNicknameChars || nickname.Length > MaxUsernameNicknameChars)
            {
                throw new ServerErrorException("Nickname should be between 4 and 30 symbols long", "ERR_INV_NICK");
            }
            else if (nickname.Any(ch => !ValidNicknameChars.Contains(ch)))
            {
                throw new ServerErrorException("Nickname contains invalid characters", "ERR_INV_NICK");
            }
        }

        private static void ValidateAuthCode(string authCode)
        {
            if (authCode.Length != Sha1CodeLength)
            {
                throw new ServerErrorException("Invalid AuthCode", "ERR_INV_AUTH");
            }
        }

        public static void CreateUser(string username, string nickname, string authCode)
        {
            try
            {
                ValidateUsername(username);
                ValidateNickname(nickname);
                ValidateAuthCode(authCode);
                using (BullsAndCowsEntities context = new BullsAndCowsEntities())
                {
                    var usernameToLower = username.ToLower();
                    var nicknameToLower = nickname.ToLower();

                    var dbUser = context.Users.FirstOrDefault(u => u.Username == usernameToLower || u.Nickname.ToLower() == nicknameToLower);

                    if (dbUser != null)
                    {
                        if (dbUser.Username.ToLower() == usernameToLower)
                        {
                            throw new ServerErrorException("Invalid AuthCode", "ERR_DUP_USR");
                        }
                        else
                        {
                            throw new ServerErrorException("Invalid AuthCode", "ERR_DUP_NICK");
                        }
                    }

                    dbUser = new User()
                    {
                        Username = usernameToLower,
                        Nickname = nickname,
                        AuthCode = authCode
                    };
                    context.Users.Add(dbUser);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
            }
        }

        public static string LoginUser(string username, string authCode, out string nickname)
        {
            ValidateUsername(username);
            ValidateAuthCode(authCode);
            var context = new BullsAndCowsEntities();
            using (context)
            {
                var usernameToLower = username.ToLower();
                var user = context.Users.FirstOrDefault(u => u.Username == usernameToLower && u.AuthCode == authCode);
                if (user == null)
                {
                    throw new ServerErrorException("Invalid user", "ERR_INV_USR");
                }

                var sessionKey = GenerateSessionKey((int)user.Id);
                user.SessionKey = sessionKey;
                nickname = user.Nickname;
                context.SaveChanges();
                return sessionKey;
            }
        }

        public static int LoginUser(string sessionKey)
        {
            ValidateSessionKey(sessionKey);
            var context = new BullsAndCowsEntities();
            using (context)
            {
                var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new ServerErrorException("Invalid password", "ERR_INV_AUTH");
                }
                return (int)user.Id;
            }
        }

        public static void LogoutUser(string sessionKey)
        {
            ValidateSessionKey(sessionKey);
            var context = new BullsAndCowsEntities();
            using (context)
            {
                var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new ServerErrorException("Invalid user", "ERR_INV_USR");
                }
                user.SessionKey = null;
                context.SaveChanges();
            }
        }

        public static IEnumerable<UserScore> GetAllUsers()
        {
            var context = new BullsAndCowsEntities();
            using (context)
            {
                var users =
                    (from user in context.Users
                     select new UserScore()
                     {
                         Nickname = user.Nickname,
                         Score = user.Scores.Any() ? user.Scores.Sum(sc => sc.Value) : 0
                     });
                return users.ToList();
            }
        }
    }
}