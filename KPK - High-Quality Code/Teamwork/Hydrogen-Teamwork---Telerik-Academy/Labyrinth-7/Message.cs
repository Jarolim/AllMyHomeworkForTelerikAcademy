namespace Labyrinth
{
    public static class Message
    {
        public const string Welcome = "Welcome to Labyrinth game." +
                                      " Please try to escape." +
                                      " Use 'top' to view the top scoreboard," +
                                      " 'restart' to start a new game and 'exit' to quit the game. \n";

        public const string EnterNameForScoreboard = "Please enter" +
                                                     " your name for the top scoreboard: ";

        public const string Congratulations = "\nCongratulations you escaped with {0} moves.\n";

        public const string InvalidMove = "\nInvalid move!\n";

        public const string InvalidCommand = "Invalid command!";

        public const string ScoreboardEmpty = "The scoreboard is empty.";
        
        public const string ValidCommands = "Enter your move (L=left," +
                                            "R-right, U=up, D=down): ";

        public const string GoodBye = "Good Bye!";
    }
}