using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//How to set the bit at position p to 0?
//int p = 5;
//int n = 35;                 // 00000000 00100011
//int mask = ~(1 << p);       // 11111111 11011111
//int result = n & mask;      // 00000000 00000011
//Console.WriteLine(result);  // 3

//How to set the bit at position p to 1?
//int p = 4;
//int n = 35;                 // 00000000 00100011
//int mask = 1 << p;          // 00000000 00010000
//int result = n | mask;      // 00000000 00110011
//Console.WriteLine(result);  // 3

//How to get the bit at position p in a number n?
//int p = 5;
//int n = 35;               // 00000000 00100011
//int mask = 1 << p;        // 00000000 00100000
//int nAndMask = n & mask;  // 00000000 00100000
//int bit = nAndMask >> p;  // 00000000 00000001
//Console.WriteLine(bit);   // 1


//Print binary
//Console.WriteLine(Convert.ToString(n, 2));


namespace ExchangeBits3_4_5WithBits24_25_26
{
    class EcxhangeBits
    {
        static int GetValueAtPossionP(int i, int p)
        {
            int mask = 1 << p;
            int iAndMask = i & mask;
            int bit = iAndMask >> p;
            return bit; 
        }

        static int SetOneAtPossisionP(int i, int p)
        {
            int mask = 1 << p;
            i = i | mask;
            return i;
        }

        static int SetZeroAtPossisionP(int i, int p)
        {
            int mask = ~(1 << p);
            i = i & mask;
            return i;
        }

        static void Main()
        {
            int i = int.Parse(Console.ReadLine());
            int before = i;
            int bit3 = GetValueAtPossionP(i, 3);
            int bit4 = GetValueAtPossionP(i, 4);
            int bit5 = GetValueAtPossionP(i, 5);
            int bit24 = GetValueAtPossionP(i, 24);
            int bit25 = GetValueAtPossionP(i, 25);
            int bit26 = GetValueAtPossionP(i, 26);

            if (bit3 == 0)
            {
                i = SetZeroAtPossisionP(i, 24);
            }
            else
            {
                i = SetOneAtPossisionP(i, 24);
            }

            if (bit4 == 0)
            {
                i = SetZeroAtPossisionP(i, 25);
            }
            else 
            {
                i = SetOneAtPossisionP(i, 25);
            }

            if (bit5 == 0)
            {
                i = SetZeroAtPossisionP(i, 26);
            }
            else
            {
                i = SetOneAtPossisionP(i, 26);
            }

            if (bit24 == 0)
            {
                i = SetZeroAtPossisionP(i, 3);
            }
            else
            {
                i = SetOneAtPossisionP(i, 3);            
            }

            if (bit25 == 0)
            {
                i = SetZeroAtPossisionP(i, 4);
            }
            else
            {
                i = SetOneAtPossisionP(i, 4);
            }

            if (bit26 == 0)
            {
                i = SetZeroAtPossisionP(i, 5);
            }
            else
            {
                i = SetOneAtPossisionP(i, 5);
            }

            Console.WriteLine("Before Exchange: " + Convert.ToString(before, 2));
            Console.WriteLine("After Exchange:  " + Convert.ToString(i, 2));
        }
    }
}
