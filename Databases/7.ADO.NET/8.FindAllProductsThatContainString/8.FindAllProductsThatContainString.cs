//Write a program that reads a string from the console and
//finds all products that contain this string. 
//Ensure you handle correctly characters like ', %, ", \ and _.
using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        SqlConnection dbConnection = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");
        Console.Write("Search: ");
        string input = Console.ReadLine();
        string[] inputSeparator = input.Split(new char[] { '_', '\'', '%', '\"', '\\' });

        if (inputSeparator.Length > 1)
        {
            Console.WriteLine("Are you trying SQL Injection?");
        }
        else
        {
            FindProduct(input, dbConnection);
        }
    }

    static void FindProduct(string searchedSubstring, SqlConnection dbConnection)
    {
        SqlCommand command = new SqlCommand("SELECT ProductName FROM Products WHERE ProductName Like @searchedSubstring;", dbConnection);
        command.Parameters.AddWithValue("@searchedSubstring", "%" + searchedSubstring + "%");
        dbConnection.Open();
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            string product = (string)reader["ProductName"];
            Console.WriteLine(product);
        }
    }
}