using System;
using System.Threading.Tasks;

namespace EShop
{
    public class LogInSubscriber
    {
        private string id;
        public LogInSubscriber(string ID, LogInPublisher publisher)
        {
            id = ID;
            publisher.RaiseEvent += HandleEvent;
        }

        void HandleEvent(object sender, Event logIn)
        {
            Console.WriteLine(logIn.Message);
        }
    }
}