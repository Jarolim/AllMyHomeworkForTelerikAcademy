using System;
using System.Collections.Generic;
using System.Linq;

namespace KnapsackProblem
{
    class KnapsackProblem
    {
        static void Main(string[] args)
        {
            Product[] store = new Product[] {
                new Product("beer",2,3),
                new Product("vodka ",12,8),
                new Product("cheese",5,4),
                new Product("nuts",4,1),
                new Product("ham",3,2),
                new Product("whiskey",13,8)
            };

            int maxWeight = 10;
            List<int> allSums = new List<int>();
            List<int> allWeight = new List<int>();
            List<List<Product>> allSets = new List<List<Product>>();
            allSums.Add(0);
            allWeight.Add(0);
            allSets.Add(new List<Product>());

            for (int i = 0; i < store.Length; i++)
            {
                List<int> tempSum = new List<int>();
                List<int> tempWeight = new List<int>();
                List<List<Product>> tempSets = new List<List<Product>>();
                for (int j = 0; j < allSums.Count; j++)
                {
                    if (allWeight[j] + store[i].Weight <= maxWeight)
                    {
                        tempSum.Add(allSums[j] + store[i].Price);
                        tempWeight.Add(allWeight[j] + store[i].Weight);
                        List<Product> newSet = new List<Product>();
                        if (allSets[j].Count > 0)
                        {
                            foreach (var item in allSets[j])
                            {
                                newSet.Add(item);
                            }
                        }
                        newSet.Add(store[i]);
                        tempSets.Add(newSet);
                    }
                }

                for (int k = 0; k < tempSum.Count; k++)
                {
                    allSums.Add(tempSum[k]);
                    allWeight.Add(tempWeight[k]);
                    allSets.Add(tempSets[k]);
                }

            }

            int maxSum = int.MinValue;
            int index = 0;

            for (int i = 0; i < allSums.Count; i++)
            {
                if (allSums[i] > maxSum)
                {
                    maxSum = allSums[i];
                    index = i;
                }
            }
            foreach (var item in allSets[index])
            {
                Console.WriteLine("{0} {1} {2}", item.Name, item.Price, item.Weight);
            }

            Console.WriteLine("Best weight {0}, best price {1}", allWeight[index], allSums[index]);
        }
    }
}