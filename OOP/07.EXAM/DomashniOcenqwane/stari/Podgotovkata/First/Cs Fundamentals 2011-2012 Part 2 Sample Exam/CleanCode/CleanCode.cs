using System;
using System.Linq;
using System.Text;

class CleanCode
{
    static void Main()
    {
        StringBuilder input = new StringBuilder();
        StringBuilder output = new StringBuilder();

        int numberOfLines = int.Parse(Console.ReadLine());

        for (int line = 0; line < numberOfLines; line++)
        {
            input.Append(String.Format("{0}\n", Console.ReadLine()));
        }

        CheckCode(input, output);



        string[] output2 = output.ToString().Split('\n');
        foreach (var line in output2)
        {
            if (!String.IsNullOrWhiteSpace(line))
            {
                Console.WriteLine(line);
            }
        }
    }

    private static void CheckCode(StringBuilder input, StringBuilder output)
    {
        int state = 0;
        for (int index = 0; index < input.Length; index++)
        {
            switch (state)
            {
                //code
                case 0:
                    switch (input[index])
                    {
                        case '"':
                            state = 1;
                            output.Append(input[index]);
                            break;
                        case '\'':
                            state = 2;
                            output.Append(input[index]);
                            break;
                        case '/':
                            if (input[index + 1] == '/')
                            {
                                if (input[index + 2] == '/')
                                {
                                    output.Append(input[index]);
                                    output.Append(input[index + 1]);
                                    output.Append(input[index + 2]);
                                    index += 2;
                                }
                                else
                                {
                                    index++;
                                    state = 3;
                                }

                            }
                            else if (input[index + 1] == '*')
                            {
                                index++;
                                state = 4;
                            }
                            else
                            {
                                output.Append(input[index]);
                            }
                            break;
                        case '@':
                            if (input[index + 1] == '"')
                            {
                                state = 5;
                            }
                            output.Append(input[index]);
                            output.Append(input[index + 1]);
                            index++;
                            break;
                        default:
                            output.Append(input[index]);
                            break;
                    }

                    break;
                // "
                case 1:
                    if (input[index] == '"' && input[index - 1] != '\\')
                    {
                        state = 0;
                    }
                    output.Append(input[index]);
                    break;
                // '
                case 2:
                    if (input[index] == '\'' && input[index - 1] != '\\')
                    {
                        state = 0;
                    }
                    output.Append(input[index]);
                    break;
                // //
                case 3:
                    if (input[index] == '\n')
                    {
                        state = 0;
                        output.Append(input[index]);
                    }
                    break;
                // /*
                case 4:
                    if (input[index] == '*')
                    {
                        if (index + 1 < input.Length)
                        {
                            if (input[index + 1] == '/')
                            {
                                index++;
                                state = 0;
                            }
                        }
                    }
                    break;
                //megastring mode
                case 5:
                    if (input[index] == '"')
                    {
                        if (input[index - 1] != '"')
                        {
                            state = 0;
                        }
                    }
                    output.Append(input[index]);
                    break;
            }
        }
    }
}
