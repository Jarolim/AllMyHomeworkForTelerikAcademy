using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    public class GSMCallHistoryTest
    {
        public void Test()
        {
            GSM iPhone = GSM.IPhone4S;

            //Add Calls
            Call newCaller = new Call("10.02.2012", "17:00", "0886254882", 600);
            Call newCaller2 = new Call("11.12.2012", "17:00", "0886254882", 2500);
            Call newCaller3 = new Call("08.08.2012", "18:00", "0886254882", 600);
            iPhone.AddCall(newCaller);
            iPhone.AddCall(newCaller2);
            iPhone.AddCall(newCaller3);

            //Print CallHistory
            StringBuilder testOutput = new StringBuilder();
            foreach (var call in iPhone.CallHistory)
            {
                string callStr = call.ToString();
                testOutput.Append(callStr);
                testOutput.Append("\n\r");
            }
            Console.WriteLine(testOutput.ToString());

            //Calculate Price
            decimal price = iPhone.CalculatePrice(0.37m);
            Console.WriteLine("{0:F2}лв.", price);

            //Remove one Call from CallHistory
            iPhone.RemoveCall(1);
            testOutput.Remove(0, testOutput.Length);
            foreach (var call in iPhone.CallHistory)
            {
                string callStr = call.ToString();
                testOutput.Append(callStr);
                testOutput.Append("\n\r");
            }
            Console.WriteLine(testOutput.ToString());

            //Calculate New Price
            price = iPhone.CalculatePrice(0.37m);
            Console.WriteLine("{0:F2}лв.", price);

            //Clear CallHistory
            iPhone.EmptyCallHistory();
        }
    }
}
