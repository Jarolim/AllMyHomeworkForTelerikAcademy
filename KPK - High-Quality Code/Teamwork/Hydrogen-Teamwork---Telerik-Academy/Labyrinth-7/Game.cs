namespace Labyrinth
{
    public abstract class Game
    {
        private bool isRunning;     
        private int currentMoves;
        private bool isGameRestarted;
        
        public bool IsRunning
        {
            get
            {
                return this.isRunning;
            }

            protected set
            {
                this.isRunning = value;
            }
        }

        public int CurrentMoves
        {
            get
            {
                return this.currentMoves;
            }

            protected set
            {
                this.currentMoves = value;
            }
        }

        public bool IsGameRestarted
        {
            get 
            {
                return this.isGameRestarted;
            }

            protected set
            {
                this.isGameRestarted = value;
            }
        }
    }
}