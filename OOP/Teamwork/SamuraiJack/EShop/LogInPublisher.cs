using System;
using System.Threading;
using System.Threading.Tasks;

namespace EShop
{
    public class LogInPublisher
    {
        public event EventHandler<Event> RaiseEvent;

        public void Execute(int interval)
        {
            OnRaiseEvent(new Event("You are not logged in."));
            Thread.Sleep(interval * 1000);
        }
        protected virtual void OnRaiseEvent(Event logIn)
        {
            EventHandler<Event> handler = RaiseEvent;

            if (handler != null)
            {
                logIn.Message += "\r\nPlease press any key to log in." ;
                handler(this, logIn);
            }
        }
    }
}