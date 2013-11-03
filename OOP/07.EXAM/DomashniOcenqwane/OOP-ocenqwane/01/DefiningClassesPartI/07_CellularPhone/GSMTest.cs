using System;


namespace CellularPhone
{
    class GSMTest
    {
        static void Main()
        {
            GSM[] phones = new GSM[4];
            phones[0] = new GSM("Asha", "Nokia");
            phones[1] = new GSM("Lumia", "Nokia");
            phones[2] = new GSM("6800 ExpressMusic", "Nokia");
            phones[3] = new GSM("A36", "Siemens", 1);

            foreach (var phone in phones)
            {
                Console.WriteLine(phone.ToString());
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine(GSM.IPhone4S.ToString());
        }
    }
}
