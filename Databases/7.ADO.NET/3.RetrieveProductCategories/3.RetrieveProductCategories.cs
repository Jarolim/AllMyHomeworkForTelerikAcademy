//Write a program that retrieves from the Northwind database 
//all product categories and the names of the products in each category. 
//Can you do this with a single SQL query (with table join)?
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
            SqlCommand joinTable = new SqlCommand(@"SELECT c.CategoryName,p.ProductName FROM Categories c inner join
                                                    Products p on c.CategoryID = p.CategoryID ORDER BY p.CategoryID", dbConnection);
            SqlDataReader reader = joinTable.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                { 
                    string categoryName = (string)reader["CategoryName"];
                    string productName = (string)reader["ProductName"];
                    Console.WriteLine("{0} - {1}", categoryName, productName);
                }
            }
        }
    }
}
