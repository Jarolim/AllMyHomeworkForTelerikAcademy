using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.MYRiskWinsRiskLoses
{
    //84 to4ki
    class Program
    {
        static void Main(string[] args)
        {

            string startCombi = Console.ReadLine();
            string endCombi = Console.ReadLine();
            HashSet<string> visited = new HashSet<string>();
            List<string> forbiddenCombi = new List<string>();

            int forbiddenCombiCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < forbiddenCombiCount; i++)
            {
                visited.Add(Console.ReadLine());
            }


            Queue<Tuple<string ,int>> queue = new Queue<Tuple<string ,int>>();
            queue.Enqueue(new Tuple<string ,int>(startCombi, 0));
            visited.Add(startCombi);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.Item1 == endCombi)
                {
                    Console.WriteLine(current.Item2);
                    return;
                }
                var sb = new StringBuilder(current.Item1);
                //Press ^
                for (int i = 0; i < 5; i++)
                {
                    int digit = current.Item1[i] - '0';
                    digit++;
                    if (digit == 10)
                    {
                        digit = 0;
                    }

                    //TODO Generate new node

                    //var sb = new StringBuilder(current.Item1);
                    sb[i] = (char)(digit + '0');
                    var newNode = sb.ToString();

                    //string newNode = string.Empty;

                    if (!visited.Contains(newNode))
                    {
                        visited.Add(newNode);
                        queue.Enqueue(new Tuple<string,int>(newNode, current.Item2 + 1));
                    }

                    sb[i] = current.Item1[i];
                }


                //Press v
                for (int i = 0; i < 5; i++)
                {
                    int digit = current.Item1[i] - '0';
                    digit--;
                    if (digit == -1)
                    {
                        digit = 9;
                    }

                    //TODO Generate new node

                    //var sb = new StringBuilder(current.Item1);
                    sb[i] = (char)(digit + '0');
                    var newNode = sb.ToString();

                    //string newNode = string.Empty;

                    if (!visited.Contains(newNode))
                    {
                        visited.Add(newNode);
                        queue.Enqueue(new Tuple<string, int>(newNode, current.Item2 + 1));
                    }

                    sb[i] = current.Item1[i];
                }

            }

            Console.WriteLine(-1);

            /*
BFS(node)
{
  queue  node
  visited[node] = true
  while queue not empty
    v  queue
    print v
    for each child c of v
      if not visited[c]
        queue  c
        visited[c] = true
}
*/


            //int count = 0;

            //for (int i = 0; i < startCombi.Length; i++)
            //{
            //    int startDigit = startCombi[i] - '0';
            //    int endDigit = endCombi[i] - '0';

            //    count += Math.Min(Math.Abs(startDigit - endDigit), 10 - Math.Abs(startDigit - endDigit));
            //}
            //Console.WriteLine(count);

        }
    }
}
