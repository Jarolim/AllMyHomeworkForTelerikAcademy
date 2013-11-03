using System;

namespace EShop
{
    public class BuyPublisher
    {
        public event EventHandler<Event> RaiseEvent;

        public void Execute(decimal totalPrice)
        {
            OnRaiseEvent(new Event(string.Format("You just spent ${0}.", totalPrice)));
        }
        protected virtual void OnRaiseEvent(Event buy)
        {
            EventHandler<Event> handler = RaiseEvent;

            if (handler != null)
            {
                buy.Message += String.Format(" at {0}", DateTime.Now.ToString());
                handler(this, buy);
            }
        }
    }
}