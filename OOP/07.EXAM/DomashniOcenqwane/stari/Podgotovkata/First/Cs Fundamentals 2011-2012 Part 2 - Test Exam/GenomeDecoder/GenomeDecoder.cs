using System;
using System.Linq;
using System.Text;

class GenomeDecoder
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] numbers = input.Split(' ');
        int lineLenght = int.Parse(numbers[0]);
        int wordLenght = int.Parse(numbers[1]);
        string encodedGenome = Console.ReadLine();
        StringBuilder decodedGenome = new StringBuilder();
        int letterLenght = 1;
        bool numberFound = false;

        for (int index = 0; index < encodedGenome.Length; index++)
        {
            if (Char.IsDigit(encodedGenome[index]))
            {
                if (numberFound)
                {
                    letterLenght = letterLenght * 10 + encodedGenome[index] - '0';
                }
                else
                {
                    letterLenght = encodedGenome[index] - '0';
                    numberFound = true;
                }
            }
            else
            {
                decodedGenome.Append(new String(encodedGenome[index], letterLenght));
                letterLenght = 1;
                numberFound = false;
            }
        }

        double lineNumber = decodedGenome.Length / (double)lineLenght;

        if (lineNumber != (int)lineNumber)
        {
            lineNumber = (int)lineNumber + 1;
        }
        int intLineNumber = (int)lineNumber;

        int padding = ((int)lineNumber).ToString().Length;
        StringBuilder printGenome = new StringBuilder();

        for (int line = 1, index = 0; line <= intLineNumber; line++)
        {
            printGenome.Append(line.ToString().PadLeft(padding, ' '));

            for (int lineIndex = 1; lineIndex <= lineLenght && index < decodedGenome.Length; lineIndex++, index++)
            {
                if ((lineIndex - 1) % wordLenght == 0)
                {
                    printGenome.Append(" ");
                }
                printGenome.Append(decodedGenome[index]);
            }
            if (line < intLineNumber)
            {
                printGenome.Append(Environment.NewLine);
            }
        }

        Console.WriteLine(printGenome);
    }
}
