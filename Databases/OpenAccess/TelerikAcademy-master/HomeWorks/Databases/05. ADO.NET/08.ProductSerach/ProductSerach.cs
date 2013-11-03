using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class ProductSerach
{
    static void Main(string[] args)
    {

        string userSearch = Console.ReadLine();
        //string output = Regex.Replace(userSearch, @"[^A-z0-9\-\s]*", "");
        List<string> allProducts;
        GetProducts(out allProducts, userSearch);
        foreach (var item in allProducts)
        {
            Console.WriteLine(item);
        }
    }

    private static void GetProducts(out  List<string> allProducts, string input)
    {
        allProducts = new List<string>();
        SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; " +
                "Database=Northwind; Integrated Security=true");
        dbCon.Open();
        using (dbCon)
        {
            string sql = "SELECT ProductName FROM Products where ProductName LIKE @input";
            SqlParameter userInput = new SqlParameter("@input", "%" + input + "%");
            SqlCommand cmdAllRows = new SqlCommand(sql, dbCon);
            cmdAllRows.Parameters.Add(userInput);

            SqlDataReader reader = cmdAllRows.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    allProducts.Add((string)reader["ProductName"]);

                }
            }
        }
    }
}