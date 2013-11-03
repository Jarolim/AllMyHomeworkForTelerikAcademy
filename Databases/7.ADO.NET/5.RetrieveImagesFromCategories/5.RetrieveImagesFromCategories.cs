//Write a program that retrieves the images for all categories
//in the Northwind database and stores them as JPG files in the file system.
using System;
using System.Data.SqlClient;
using System.IO;

class Program
{
    const string FILE_LOCATION = @"..\";
    const string FILE_EXTENSION = @".jpg";

    static void Main()
    {
        ExtractImageFromDB();
        Console.WriteLine("You can find the picture files in the bin directory of the project.");
    }

    static void ExtractImageFromDB()
    {
        SqlConnection dbConnection = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");

        dbConnection.Open();

        using (dbConnection)
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT PICTURE, CategoryID, CategoryName FROM Categories", dbConnection);

            SqlDataReader reader = cmd.ExecuteReader();

            using (reader)
            {
                byte[] image;
                int categoryId;
                string categoryName;
                while (reader.Read())
                {
                    image = (byte[])reader["Picture"];
                    categoryId = (int)reader["CategoryID"];
                    categoryName = (string)reader["CategoryName"];
                    WriteBinaryFile(image, FILE_LOCATION + categoryId + FILE_EXTENSION);
                    image = null;
                }
            }
        }
    }

    static void WriteBinaryFile(byte[] fileContents, string fileLocation)
    {
        FileStream stream = new FileStream(fileLocation, FileMode.Create);
        using (stream)
        {
            stream.Write(fileContents, 0, fileContents.Length);
        }
    }
}
