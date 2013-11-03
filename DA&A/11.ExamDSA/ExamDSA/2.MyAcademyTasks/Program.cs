using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.MyAcademyTasks
{
    class Program
    {

        static List<int> tasks = new List<int>();
        static int variety;

        static void Main(string[] args)
        {
            string taskAsStringLine = Console.ReadLine();

            var tasksAsString = taskAsStringLine.Split(new char[]{',', ' '},StringSplitOptions.RemoveEmptyEntries);

            foreach (var taskAsString in tasksAsString)
            {
                tasks.Add(int.Parse(taskAsString));
            }

            bestSolution = tasks.Count;

            variety = int.Parse(Console.ReadLine());


            Solve(0, 1, tasks[0], tasks[0]);
            Console.WriteLine(bestSolution);
        }


        static int bestSolution;

        static void Solve(int currentIndex, int taskSolved, int currentMin, int currentMax)
        {
            if (currentMax - currentMin >= variety)
            {
                bestSolution = Math.Min(bestSolution, taskSolved);
                return;
            }

            if (currentIndex >= tasks.Count)
            {
                return;
            }

            for (int i = 1; i <= 2; i++)
            {
                if (currentIndex + i < tasks.Count)
                {
                    Solve(currentIndex + i, taskSolved + 1,
                        Math.Min(currentMin, tasks[currentIndex + i]),
                        Math.Max(currentMax, tasks[currentIndex + i]));
                }
            }
        }
    }
}
