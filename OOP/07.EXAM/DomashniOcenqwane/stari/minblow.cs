using System;

class Program
{
    static void Main()
    {
        int coins = 0;
        int maxCoins = int.MinValue;
        int Position = 0;
        int k =0;
        string InputPath;
        string inputValey = Console.ReadLine();
        string[] separatedValey = inputValey.Split(new char[] { ',' });
        int[] Valey = new int[separatedValey.Length];
        for (int i = 0; i < separatedValey.Length; i++)
        {
            Valey[i] = int.Parse(separatedValey[i]);
        }        
        int numberOfPaths = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < numberOfPaths; i++)
        {
            InputPath = Console.ReadLine();
            string[] separatePath = InputPath.Split(new char[]{','});
            int PathSize = separatePath.Length;
            int[] Path = new int[PathSize];
            for (int j = 0; j < PathSize; j++)
            {
                Path[j] = int.Parse(separatePath[j]);                
            }
            k = 0;
            Position = 0;
            coins = 0;
            while (Valey[Position] != int.MinValue)
            {
                coins += Valey[Position];
                Valey[Position] = int.MinValue;
                Position += Path[k];
                k++;
                if (Position >= Valey.Length || Position < 0)
                {
                    break;
                }
                if (k == PathSize)
                {
                    k = 0;
                }                
            }
            if (coins>maxCoins)
            {
                maxCoins = coins;
                coins = 0;
            }
            for (int f = 0; f < separatedValey.Length; f++)
            {
                Valey[f] = int.Parse(separatedValey[f]);
            }
        }
        Console.WriteLine(maxCoins);
        
    }
}
