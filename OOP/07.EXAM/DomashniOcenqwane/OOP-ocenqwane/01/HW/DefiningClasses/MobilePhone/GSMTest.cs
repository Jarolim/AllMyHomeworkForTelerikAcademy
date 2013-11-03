using System;
using System.Text;

namespace MobilePhone
{
    public class GSMTest
    {
        public string displayInformation()
        {
            StringBuilder testOutput = new StringBuilder();
            GSM[] gsmTests = new GSM[3];
            GSM[] containGSMInfo = new GSM[3];
            GSM firstGSM = new GSM("LG", "Germany", "Asparuh", 520.50m);
            GSM secondGSM = new GSM("Nokia", "China", "Atanas", 150.50m);
            GSM thirdGSM = new GSM("Sony", "Bulgaria", "Bubche", 790.99m);

            gsmTests[0] = firstGSM;
            gsmTests[1] = secondGSM;
            gsmTests[2] = thirdGSM;

            for (int i = 0; i < gsmTests.Length; i++)
            {
                testOutput.Append(gsmTests[i] + "\n\r");
            }
            return testOutput.ToString();
        }
    }
}