using System;
using System.Data.SqlClient;

    class CategoriesProductNames
    {
        static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; " +
                                "Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                string sql = "SELECT CategoryName, ProductName FROM Products" +
                    " JOIN Categories" +
                    " ON Products.CategoryId = Categories.CategoryId" +
                    " ORDER BY CategoryName";
                SqlCommand cmdAllRows = new SqlCommand(sql,dbCon);
                SqlDataReader reader = cmdAllRows.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string productName = (string)reader["ProductName"];
                        Console.WriteLine("{0}: {1}", categoryName, productName);
                    }
                }
            }
        }
    }