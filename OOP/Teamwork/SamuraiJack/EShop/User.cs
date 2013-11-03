using System;

namespace EShop
{
    public abstract class User : ILogable, IComment
    {
        //fields
        private string username;
        private string password;
        private string comment;
        private bool isLogged;

        //properties
        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }

        public string Username
        {
            get { return this.username; }
            set
            {
                if (value.Length < 3 || value.Length > 16)
                {
                    throw new ArgumentOutOfRangeException(
                        "Invalid input! Username should be between 3 and 16 characters.");
                }
                this.username = value;
            }
        }

        public string Password
        {
            get { return this.password; }
            set
            {
                if (value.Length < 3 || value.Length > 16)
                {
                    throw new ArgumentOutOfRangeException(
                        "Invalid input! Password should be between 3 and 16 characters.");
                }
                this.password = value;
            }
        }

        public bool IsLogged
        {
            get { return this.isLogged; }
            set { this.isLogged = value; }
        }

        public User(string username, string password, string comment = null)
        {
            this.Username = username;
            this.Password = password;
            this.Comment = comment;
        }

        public abstract void PrintComment();
        public abstract User LogIn();
        public abstract void LogOut();
    }
}