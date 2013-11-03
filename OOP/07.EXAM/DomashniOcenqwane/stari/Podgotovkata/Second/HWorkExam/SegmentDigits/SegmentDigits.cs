using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegmentDigits
{
    class SegmentDigits
    {
        static int[] digs;
        static int[] output;
        static int[] input;
        static int N;
        static StringBuilder consoleOut;
        static void solve(int a) 
        {
            if (a == N) 
            {
                for (int i = 0; i < N; i++) 
                {
                    consoleOut.Append(output[i]);
                }
                consoleOut.AppendLine();
            }
            else 
            {
                for (int i = 0; i < 10; i++) 
                {
                    if (((digs[i] & input[a]) == input[a])) 
                    {
                        output[a] = i;
                        solve(a + 1);
                    }
                }
            }
        }
 
        static long many(int b) 
        {
            long res = 0;
            for (int i = 0; i < 10; i++) 
            {
                if (((b & digs[i]) == b)) res++;
            }
            return res;
        }
        static void Main(string[] args) 
        {
            consoleOut = new StringBuilder(100000);
            digs = new int[10];      //ABCDEFG
            digs[0] = Convert.ToInt32("1111110", 2);
            digs[1] = Convert.ToInt32("0110000", 2);
            digs[2] = Convert.ToInt32("1101101", 2);
            digs[3] = Convert.ToInt32("1111001", 2);
            digs[4] = Convert.ToInt32("0110011", 2);
            digs[5] = Convert.ToInt32("1011011", 2);
            digs[6] = Convert.ToInt32("1011111", 2);
            digs[7] = Convert.ToInt32("1110000", 2);
            digs[8] = Convert.ToInt32("1111111", 2);
            digs[9] = Convert.ToInt32("1111011", 2);
            N = int.Parse(Console.ReadLine());
            input = new int[N];
            output = new int[N];
            long res = 1;
            for (int i = 0; i < N; i++) 
            {
                input[i] = Convert.ToInt32(Console.ReadLine(), 2);
                res *= many(input[i]);
            }
            Console.WriteLine(res);
            solve(0);
            Console.Write(consoleOut);
        }
    }
}


