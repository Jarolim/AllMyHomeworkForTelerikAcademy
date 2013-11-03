using System;

namespace EShop
{
    public class Event : EventArgs
    {
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public Event(string text)
        {
            message = text;
        }
    }
}