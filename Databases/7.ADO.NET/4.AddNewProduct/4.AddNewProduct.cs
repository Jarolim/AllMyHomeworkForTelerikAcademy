//Write a method that adds a new product in the products table in the Northwind database.
//Use a parameterized SQL command.
using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        AddProduct("Musaka", true);
        AddProduct("Goblin", false);
    }

    static void AddProduct(string name, bool discontinued)
    {
        SqlConnection dbConnection = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");

        dbConnection.Open();
        using (dbConnection)
        {
            SqlCommand addProduct = new SqlCommand("INSERT Products (ProductName,Discontinued) VALUES(@name,@discontinued);", dbConnection);

            addProduct.Parameters.AddWithValue("@name", name);
            addProduct.Parameters.AddWithValue("@discontinued", discontinued);
            addProduct.ExecuteNonQuery();
        }
    }
}