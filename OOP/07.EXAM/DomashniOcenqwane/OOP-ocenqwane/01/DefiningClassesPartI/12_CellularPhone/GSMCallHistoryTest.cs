using System;
using System.Collections.Generic;

namespace CellularPhone
{
    class GSMCallHistoryTest
    {
        static void Main()
        {
            GSM phone = new GSM("6800 ExpressMusic", "Nokia", 300, "Petko Slaveikov", new Battery("DSD-435"), new Display(3.5f));
            Random rand = new Random();

            int numberOfCalls = rand.Next(1, 10);
            int maxCallLength = rand.Next(60, 3600);
            byte counter = 1;

            for (int i = 0; i < numberOfCalls; i++)
            {
                phone.AddCall(new Call(DateTime.Now.AddSeconds(rand.Next(-3600 * 24 * 30, -maxCallLength)), "0899-999-999", (uint)rand.Next(0, maxCallLength)));
            }

            foreach (Call call in phone.CallHistory)
            {
                Console.WriteLine("Record {0} out of {1}", counter++, phone.CallHistory.Count);
                DisplayCallInformation(call);
            }

            Console.WriteLine("The total price of the calls in the call history is: {0:C2}", phone.CalculateBill(0.37m));
            phone.DeleteCall(FindLongestCallInHistory(phone.CallHistory));
            Console.WriteLine("\nLongest call in history was removed.");
            Console.WriteLine("\nThe total price of the calls in the call history is: {0:C2}", phone.CalculateBill(0.37m));
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            phone.ClearCallHistory();

            Console.Clear();
            Console.WriteLine("Call history was cleared.");
            Console.WriteLine("Call history length: {0}", phone.CallHistory.Count);
        }

        static void DisplayCallInformation(Call call)
        { 
            Console.WriteLine("Call started on: " + call.TimeInstance);
            Console.WriteLine("Phone dialed: " + call.DialedPhoneNumber);
            Console.WriteLine("Call duration in seconds: " + call.Duration);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static Call FindLongestCallInHistory(List<Call> history)
        {
            Call longestCall = new Call(DateTime.Now, "", 0);

            foreach (Call call in history)
            {
                if (call.Duration > longestCall.Duration)
                {
                    longestCall = call;
                }
            }

            return longestCall;
        }
    }
}