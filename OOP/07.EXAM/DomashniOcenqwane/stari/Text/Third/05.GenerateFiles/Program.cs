using System;
using System.Linq;
using System.IO;
// avtomatichno sym generiral failovete za chetene, za ydobstvo na proverqvashtiqt, da ne se muchi da vkarva neshta do bezkrai
class Program
{
    private static readonly char[] delimers = { ' ' };
    private static readonly String readFile = @"../../readfrom.txt";
    private static int[,] arr;
    static void Main(string[] args)
    {
        try
        {
            GenerateMatrix(readFile);
            ReadMatrix(readFile);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found, try adding a new file");
        }
        catch (IOException io)
        {
            Console.WriteLine(io.Message);
        }
        catch (OutOfMemoryException ome)
        {
            Console.WriteLine(ome.Message);
        }
        finally { }
    }

    private static void ReadMatrix(string file)
    {
        using (StreamReader reader = new StreamReader(file))
        {
            string line;
            int size = int.Parse(reader.ReadLine()), br = 0;
            arr = new int[size,size];
            
            while((line=reader.ReadLine())!=null) //populate the matrix >.<
            {
                string[] splitLine = line.Split(delimers, StringSplitOptions.RemoveEmptyEntries);
                for (int i = br; i < br+1; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        arr[i,j] = int.Parse(splitLine[j]);
                    }
                }
                br++;
            }
            Find2X2Area(arr);
        }
    }

    private static void Find2X2Area(int[,] tmp)
    {
        int max = tmp[0, 0] + tmp[0, 1] + tmp[1, 0] + tmp[1, 1];
        int temp = 0;
        int[,] final = new int[2, 2];
        {
            final[0, 0] = tmp[0, 0];
            final[0, 1] = tmp[0, 1];
            final[1, 0] = tmp[1, 0];
            final[1, 1] = tmp[1, 1];
        }
        for (int i = 0; i < tmp.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < tmp.GetLength(0) - 1; j++)
            {
                temp = tmp[i, j] + tmp[i, j + 1] + tmp[i + 1, j] + tmp[i + 1, j + 1];
                if (temp > max)
                {
                    max = temp;
                    Array.Clear(final, 0, 4);
                    final[0, 0] = tmp[i, j];
                    final[0, 1] = tmp[i, j + 1];
                    final[1, 0] = tmp[i + 1, j];
                    final[1, 1] = tmp[i + 1, j + 1];
                }
            }
        }
        Console.WriteLine("Best sum is {0} and the 2x2 area is :", max);
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.Write(final[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("From :");
        for (int i = 0; i < tmp.GetLength(0); i++)
        {
            for (int j = 0; j < tmp.GetLength(0); j++)
            {
                Console.Write(tmp[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    private static void GenerateMatrix(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            Random rnd = new Random();
            int size = rnd.Next(3, 10);
            writer.WriteLine(size);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    writer.Write(rnd.Next(1, 10) + " ");
                }
                writer.WriteLine();
                writer.Flush();
            }
        }
    }
}

