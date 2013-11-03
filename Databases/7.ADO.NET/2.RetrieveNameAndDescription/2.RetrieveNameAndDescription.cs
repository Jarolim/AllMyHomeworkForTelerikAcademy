//Write a program that retrieves the name and description of all categories in the Northwind DB.
using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        SqlConnection dbConnection = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");

        dbConnection.Open();
        using (dbConnection)
        {
            SqlCommand categoryInfoCommand = new SqlCommand("SELECT CategoryName, Description FROM Categories;", dbConnection);
            SqlDataReader reader = categoryInfoCommand.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string categoryDescription = (string)reader["Description"];
                    Console.WriteLine("{0} - {1}", categoryName, categoryDescription);
                }
            }
        }
    }
}