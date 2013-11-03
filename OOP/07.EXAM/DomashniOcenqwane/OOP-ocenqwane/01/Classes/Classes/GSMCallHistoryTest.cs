using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    static class GSMCallHistoryTest
    {
        public static void TestClass()
        {
            GSM gsm = GSM.IPhone4S;

            Console.WriteLine(gsm);

            gsm.AddCall(new Call(DateTime.Now, 60, "12345"));
            gsm.AddCall(new Call(DateTime.Now.AddHours(1), 90, "12345"));
            gsm.AddCall(new Call(DateTime.Now.AddDays(3), 160, "12345"));
            foreach (var call in gsm.CallHistory)
            {
                Console.WriteLine(call.ToString());
            }
            Console.WriteLine(gsm.CalculateBill(0.37M));
            uint longestCall = gsm.CallHistory.Max(t => t.CallDuarationInSeconds);
            int index = gsm.CallHistory.FindIndex(t => t.CallDuarationInSeconds == longestCall);
            gsm.RemoveCall(index);
            Console.WriteLine(gsm.CalculateBill(0.37M));
            gsm.ClearCallHistory();
        }
    }
}
