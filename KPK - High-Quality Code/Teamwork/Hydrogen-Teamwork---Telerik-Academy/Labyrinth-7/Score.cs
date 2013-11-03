using System;

namespace Labyrinth
{
    public class Score : IComparable<Score>
    {
        private int moves;
        private string name;

        public int Moves
        {
            get
            {
                return this.moves;
            }
            set
            {
                this.moves = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public Score(int moves, string name)
        {
            this.Moves = moves;
            this.Name = name;
        }

        public int CompareTo(Score other)
        {
            return this.Moves.CompareTo(other.Moves);
        }

        public override bool Equals(object obj)
        {
            if (((Score)obj).Name == this.Name &&
                ((Score)obj).Moves == this.Moves)
            {
                return true;
            }

            return false;
        }
    }
}