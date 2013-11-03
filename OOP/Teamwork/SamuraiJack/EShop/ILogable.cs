using System;

namespace EShop
{
    interface ILogable
    {
        string Username { get; set; }
        string Password { get; set; }

        User LogIn();
        void LogOut();
    }
}