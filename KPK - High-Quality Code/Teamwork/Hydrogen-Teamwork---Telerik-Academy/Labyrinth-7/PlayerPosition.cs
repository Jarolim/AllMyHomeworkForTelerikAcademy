using System;

namespace Labyrinth
{
    public class PlayerPosition
    {
        private int x;
        private int y;

        public PlayerPosition()
        { 
        }

        public PlayerPosition(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The value cannot be negative", "y");
                }

                this.y = value;
            }
        }

        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The value cannot be negative", "x");
                }

                this.x = value;
            }
        }
    }
}
