using System;
using System.Data.SqlClient;

class AddProducts
{
    static void Main(string[] args)
    {
        SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; " +
                    "Database=Northwind; Integrated Security=true");
        dbCon.Open();
        using (dbCon)
        {
            int addedRow = InsertInProducts("kifte", 1, 3, "10 per box", 0.70m, dbCon);
            Console.WriteLine("Row position in database {0}", addedRow);
        }
    }
    private static int InsertInProducts(string productName, int supplierID, int categoryID, string quantity, decimal price, SqlConnection dbCon)
    {
        SqlCommand cmd = new SqlCommand("INSERT INTO Products " +
          "(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice) VALUES " +
          "(@name, @supplier, @category, @quantity, @price)", dbCon);
        cmd.Parameters.AddWithValue("@name", productName);
        cmd.Parameters.AddWithValue("@supplier", supplierID);
        cmd.Parameters.AddWithValue("@category", categoryID);
        cmd.Parameters.AddWithValue("@quantity", quantity);
        cmd.Parameters.AddWithValue("@price", price);
        cmd.ExecuteNonQuery();

        SqlCommand cmdSelectIdentity = new SqlCommand("SELECT @@Identity", dbCon);
        int insertedRecordId = (int)(decimal)cmdSelectIdentity.ExecuteScalar();
        return insertedRecordId;
    }
}
