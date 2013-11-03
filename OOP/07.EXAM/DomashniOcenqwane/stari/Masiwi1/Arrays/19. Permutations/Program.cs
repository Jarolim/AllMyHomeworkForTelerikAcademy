using System;

class Permutations
{
    private void swap(ref int a, ref int b)
    {
        if (a == b) return;
        int c = a;
        a = b;
        b = c;
    }

    public void setper(int[] list)
    {
        int x = list.Length - 1;
        go(list, 0, x);
    }

    public void print(int[] a)
    {
        foreach (int item in a)
        {
            Console.Write(item + " ");
        }
    }

    private void go(int[] list, int k, int m)
    {
        int i;
        if (k == m)
        {
            print(list);
            Console.WriteLine(" ");
        }
        else
            for (i = k; i <= m; i++)
            {
                swap(ref list[k], ref list[i]);
                go(list, k + 1, m);
                swap(ref list[k], ref list[i]);
            }
    }

    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());
        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            arr[i] = i + 1;
        }

        Permutations p = new Permutations();
        p.setper(arr);
    }
}