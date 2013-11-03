﻿using System;
using System.Text;

public class ReverseStringPrinter
{
    public static string[] Palindromes = 
    {
        "I, man, am regal a German am I",
        "Never odd or even",
        "If I had a hi-fi",
        "Madam, I'm Adam",
        "Too hot to hoot",
        "No lemons, no melon",
        "Too bad I hid a boot",
        "Lisa Bonet ate no basil",
        "Warsaw was raw",
        "Was it a car or a cat I saw?",
        "Rise to vote, sir",
        "Do geese see God?",
        "'Do nine men interpret?' 'Nine men,' I nod",
        "Rats live on no evil star",
        "Won't lovers revolt now?",
        "Race fast, safe car",
        "Pa's a sap",
        "Ma is as selfless as I am",
        "May a moody baby doom a yam?",
        "Ah Satan sees Natasha",
        "No devil lived on",
        "Lonely Tylenol ",
        "Not a banana baton",
        "No 'x' in 'Nixon'",
        "O, stone, be not so",
        "O Geronimo, no minor ego",
        "'Naomi', I moan",
        "'A Toyota's a Toyota'",
        "A dog, a panic in a pagoda",
        "Oh, no! Don Ho!",
        "Nurse, I spy gypsies -- run!",
        "Senile felines",
        "Now I see bees I won",
        "UFO tofu",
        "We panic in a pew",
        "Oozy rat in a sanitary zoo",
        "God! A red nugget! A fat egg under a dog!",
        "Go hang a salami, I'm a lasagna hog"
    };

    public static string ReverseString(string input)
    {
        StringBuilder reversed = new StringBuilder(input.Length);

        for (int index = input.Length - 1; index >= 0; index--)
        {
            reversed.Append(input[index]);
        }
        return reversed.ToString();
    }

    public static void Main()
    {
        for (int index = 0; index < Palindromes.Length; index++)
        {
            Console.WriteLine(ReverseString(Palindromes[index]));
        }
    }
}