using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class GSMTest
    {
        private GSM[] gsms;
        public GSM[] GSMs
        {
            get
            {
                return this.gsms;
            }
            set
            {
                this.gsms = value;
            }
        }
        public GSMTest(uint count)
        {
            this.gsms = new GSM[count];
            for (int i = 0; i < count; i++)
            {
                gsms[i] = new GSM();
            }
        }
        public GSMTest()
        {
            this.gsms = new GSM[0];
        }
        public void PrintGSMs()
        {
            foreach (GSM gsm in gsms)
            {
                Console.WriteLine(gsms.ToString());
            }
        }
        public static void printIphone4S()
        {
            Console.WriteLine(GSM.IPhone4S.ToString());
        }
    }
}
