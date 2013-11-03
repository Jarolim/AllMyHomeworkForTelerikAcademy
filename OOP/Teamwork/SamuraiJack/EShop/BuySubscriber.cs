using System;

namespace EShop
{
    public class BuySubscriber
    {
        private string id;
        public BuySubscriber(string ID, BuyPublisher publisher)
        {
            id = ID;
            publisher.RaiseEvent += HandleEvent;
        }

        void HandleEvent(object sender, Event buy)
        {
            Console.WriteLine(buy.Message);
        }
    }
}