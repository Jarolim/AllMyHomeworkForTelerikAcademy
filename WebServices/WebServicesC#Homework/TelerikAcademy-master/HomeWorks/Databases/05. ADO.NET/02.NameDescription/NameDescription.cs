using System;
using System.Linq;
using System.Data.SqlClient;

class NameDescription
{
    static void Main(string[] args)
    {
        SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; " +
                                "Database=Northwind; Integrated Security=true");
        dbCon.Open();
        using (dbCon)
        {
            SqlCommand cmdAllRows = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbCon);
            SqlDataReader reader = cmdAllRows.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string description = (string)reader["Description"];
                    Console.WriteLine("{0}: {1}", categoryName, description);
                }
            }
        }
    }
}
