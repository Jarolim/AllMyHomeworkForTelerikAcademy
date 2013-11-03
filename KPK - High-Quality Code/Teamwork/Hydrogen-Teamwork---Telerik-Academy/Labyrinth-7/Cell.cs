using System;

namespace Labyrinth
{
    public class Cell : ICloneable
    {
        public const char Empty = '-';
        public const char Block = 'x';
        public const char Player = '*';

        private int row;        
        private int column;
        private char value;

        public Cell(int row, int column, char value)
        {
            this.Row = row;
            this.Column = column;
            this.Value = value;
        }

        public char Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public int Column
        {
            get
            {
                return this.column;
            }

            private set
            {
                this.column = value;
            }
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            private set
            {
                this.row = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (((Cell)obj).Row == this.Row &&
                ((Cell)obj).Column == this.Column &&
                ((Cell)obj).Value == this.Value)
            {
                return true;
            }

            return false;
        }

        public object Clone()
        {
            Cell cloned = new Cell(this.Row, this.Column, this.Value);

            return cloned;
        }
    }
}