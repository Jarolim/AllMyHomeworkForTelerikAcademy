using System;

namespace MobilePhone
{
    class MobileProgram
    {
        static void Main(string[] args)
        {
            GSMTest test = new GSMTest();
            string testResult = test.displayInformation();

            Console.WriteLine(testResult);
            //Console.WriteLine(GSM.IPhone4S);
            //Console.WriteLine("**********************");

            //GSM tester = new GSM();
            //Call newCall = new Call("08.08.2012", "18:00", "0886254882", 600);
            //Console.WriteLine(newCall);
            //Call newCaller = new Call("10.02.2012", "17:00", "0886254882", 600);
            //Call newCaller2 = new Call("11.12.2012", "17:00", "0886254882", 600);
            //Call newCaller3 = new Call("08.08.2012", "18:00", "0886254882", 600);
            //tester.AddCall(newCaller);
            //tester.AddCall(newCaller2);
            //tester.AddCall(newCaller3);
            ////tester.RemoveCall(1);
            ////tester.EmptyCallHistory();

            //decimal price = tester.CalculatePrice(1.0m);
            //Console.WriteLine("{0:F2}лв.", price);

            GSMCallHistoryTest testCall = new GSMCallHistoryTest();
            testCall.Test();
        }
    }
}