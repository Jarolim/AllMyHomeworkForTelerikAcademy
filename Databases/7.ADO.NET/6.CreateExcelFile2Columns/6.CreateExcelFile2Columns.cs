//Create an Excel file with 2 columns: name and score:
//Write a program that reads your MS Excel file through
//the OLE DB data provider and displays the name and score row by row.
using System;
using System.Data;
using System.Data.OleDb;

class Program
{
    static void Main()
    {
        OleDbConnection dbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data Source=C:\Users\Deblia\Dropbox\TelerikAcademy\Ivo\Homework\Databases\7.ADO.NET\Table.xlsx;Extended Properties=""Excel 12.0 XML;HDR=Yes""");
        OleDbCommand myCommand = new OleDbCommand("SELECT * FROM [Sheet1$]", dbConnection);

        dbConnection.Open();

        OleDbDataReader reader = myCommand.ExecuteReader();

        while (reader.Read())
        {
            string name = (string)reader["Name"];
            double score = (double)reader["Score"];
            Console.WriteLine("Name: {0} - Score: {1}", name, score);
        }

        dbConnection.Close();

        //Does the same ------------------

        //dbConn.Open();

        //DataTable dataSet = new DataTable();
        //OleDbDataAdapter adapter = new OleDbDataAdapter("select * from [Sheet1$]", dbConn);
        //adapter.Fill(dataSet);

        //foreach (DataRow item in dataSet.Rows)
        //{
        //    Console.WriteLine("{0}|{1}", item.ItemArray[0], item.ItemArray[1]);
        //}

        //dbConn.Close();
    }
}
