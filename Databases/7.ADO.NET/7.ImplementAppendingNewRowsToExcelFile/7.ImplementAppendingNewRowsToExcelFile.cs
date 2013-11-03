//7.Implement appending new rows to the Excel file.
using System;
using System.Data.OleDb;

class Program
{
    static void Main()
    {
        OleDbConnection dbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
           @"Data Source=C:\Users\Deblia\Dropbox\TelerikAcademy\Ivo\Homework\Databases\7.ADO.NET\Table.xlsx;Extended Properties=""Excel 12.0 XML;HDR=Yes""");

        for (int i = 1; i < 5; i++)
        {
            InsertDataIntoEcxel("Гугла " + i, i, dbConnection);
        }
    }

    static void InsertDataIntoEcxel(string name, double score, OleDbConnection dbConnection)
    {
        OleDbCommand myCommand = new OleDbCommand("INSERT INTO [Sheet1$] (Name,Score) VALUES (@Name,@Score)", dbConnection);
        dbConnection.Open();
        myCommand.Parameters.AddWithValue("@Name", name);
        myCommand.Parameters.AddWithValue("@Score", score);
        myCommand.ExecuteNonQuery();
        dbConnection.Close();
    }
}