using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;

class AddRowsToTable
{
    static void Main(string[] args)
    {
        Console.WriteLine("Rows afected: {0}", InsertToTable("Misho Ivanov", 20)); 
    }

    private static int InsertToTable(string name, int score)
    {
        int result = 0;
        OleDbConnectionStringBuilder csbuilder = new OleDbConnectionStringBuilder();
        csbuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
        csbuilder.DataSource = @"..\..\Table.xlsx";
        csbuilder.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES");

        using (OleDbConnection connection = new OleDbConnection(csbuilder.ConnectionString))
        {
            string insertToTable = @"INSERT INTO [Sheet1$] (Name, Score) VALUES (@Name, @Score)";
            using (OleDbCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = insertToTable;
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Score", score);
                result = command.ExecuteNonQuery();
            }
        }
        return result;
    }
}
