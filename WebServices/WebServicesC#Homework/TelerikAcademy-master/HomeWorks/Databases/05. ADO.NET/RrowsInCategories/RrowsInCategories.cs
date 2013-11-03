using System;
using System.Data.SqlClient;

class RrowsInCategories
{
    static void Main(string[] args)
    {
        SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; " +
        "Database=Northwind; Integrated Security=true");
        dbCon.Open();
        using (dbCon)
        {
            SqlCommand cmdCount = new SqlCommand(
                "SELECT COUNT(CategoryID) FROM Categories", dbCon);
            int rowCount = (int)cmdCount.ExecuteScalar();
            Console.WriteLine("Rows count: {0} ", rowCount);
            Console.WriteLine();
        }
    }
}