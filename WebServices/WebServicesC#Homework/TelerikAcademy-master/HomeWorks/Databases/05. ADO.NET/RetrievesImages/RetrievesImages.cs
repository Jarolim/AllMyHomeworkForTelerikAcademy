using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace RetrievesImages
{
    class RetrievesImages
    {
        static void Main(string[] args)
        {
            List<byte[]> allPictures;
            ExtractImageFromDB(out allPictures);
            string imgDestination = @"..\..\image";

            for (int i = 0; i < allPictures.Count; i++)
            {
                var image = new Image(allPictures[i]);
                image.WriteToFile(imgDestination + i);
            }
        }

        private static void ExtractImageFromDB(out List<byte[]> allPictures)
        {
            SqlConnection dbConn = new SqlConnection("Server=.\\SQLEXPRESS; " +
                                                     "Database=Northwind; Integrated Security=true");

            allPictures = new List<byte[]>();
            dbConn.Open();
            using (dbConn)
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT Picture FROM Categories", dbConn);
                SqlDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        allPictures.Add((byte[])reader["Picture"]);
                    }
                }
            }
        }
    }
}