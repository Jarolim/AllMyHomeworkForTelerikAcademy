﻿/*Code to refactor*/

//      class class_123{
//        const int max_count=6;
//        class InClass_class_123  {
//          void Метод_нА_class_InClass_class_123(bool promenliva)    {
//            string promenlivaKatoString=promenliva.ToString();
//            Console.WriteLine(promenlivaKatoString);    }
//        }    
//        public static void Метод_За_Вход()  {
//          class_123.InClass_class_123 инстанция =
//            new class_123.InClass_class_123();
//          инстанция.Метод_нА_class_InClass_class_123(true); 
//        }
//      }

using System;

public class BoolExtension
{
    private const int MaxCount = 6;

    public static void Main()
    {
        BoolExtension instanseBool = new BoolExtension();
        instanseBool.PrintBoolAsString(true);
    }

    public void PrintBoolAsString(bool instanseBool)
    {
        string boolToString = instanseBool.ToString();
        Console.WriteLine(boolToString);
    }
}
