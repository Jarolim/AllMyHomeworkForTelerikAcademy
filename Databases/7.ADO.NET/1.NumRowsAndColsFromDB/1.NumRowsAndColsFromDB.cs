//1.Write a program that retrieves from the Northwind sample database in MS SQL Server
//the number of  rows in the Categories table.
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
            SqlCommand commandCount = new SqlCommand("SELECT COUNT(CategoryID) FROM Categories", dbConnection);
            int categoriesCount = (int)commandCount.ExecuteScalar();
            Console.WriteLine("Categories count = {0}", categoriesCount);
        }
    }
}
