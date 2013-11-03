using System;

class sBaseTorBase
{

    static void Main()
    {
        Console.WriteLine("Enter numberic system base S(form 2 to 16): ");
        int sBase = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter numberic system base D(form 2 to 16): ");
        int dBase = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter a number: ");
        string num = Console.ReadLine();

        char[] bin = num.ToCharArray();
        Array.Reverse(bin);
        int dec = 0;

        for (int i = 0; i < bin.Length; i++)
        {
            string st = bin[i].ToString();
            int number = int.Parse(st) * (int)(Math.Pow(sBase, i));
            dec = dec + number;
        }
        //Console.WriteLine(dec);//decimal number

        string converted = "",
            reminder="";
        while (dec != 0)
        {
            reminder = (dec % dBase).ToString();// 
            switch (reminder)
            {
                case "10": reminder = "A"; break;
                case "11": reminder = "B"; break;
                case "12": reminder = "C"; break;
                case "13": reminder = "D"; break;
                case "14": reminder = "E"; break;
                case "15": reminder = "F"; break;
            }
            converted = reminder + converted;
            dec = (dec / dBase);
        }
        Console.WriteLine("Your converted number(base{0} to base{1}): {2}", sBase, dBase, converted);
    }
}

