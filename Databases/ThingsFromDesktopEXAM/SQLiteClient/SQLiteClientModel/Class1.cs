using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace SQLiteExperiment
{
  class Program
  {
    static void Main(string[] args)
    {
        var dbFile = @"C:\Users\Deblia\Desktop\TWDatabases\SQLite\Supermarket.db";
      if (File.Exists(dbFile)) File.Delete(dbFile);
 
      var connString = string.Format(@"Data Source={0}; Pooling=false; FailIfMissing=false;", dbFile);
 
      //test using System.Data.Common and SQLiteFactory
      Test1(connString);
 
      if (File.Exists(dbFile))
        Console.WriteLine("Test1 succeeds");
      else
        Console.WriteLine("Test1 fails.");
 
      //prepare for test 2 using SQLite
      //Note: If Pooling=true in connection string the 
      //      File.Delete will fail with IOException - The process cannot
      //      access the file because it is being used by another process.
      if (File.Exists(dbFile)) File.Delete(dbFile);
 
       
      Console.WriteLine(string.Empty);
 
      //test using System.Data.SQLite namespace including SQLiteConnection
      Test2(connString);
 
      if (File.Exists(dbFile))
        Console.WriteLine("Test2 succeeds");
      else
        Console.WriteLine("Test2 fails.");
 
      Console.ReadLine(); //prevent close while in debug
    }
 
    static void Test1(string connString)
    {
      Console.WriteLine("Begin Test1");
      using (var factory = new System.Data.SQLite.SQLiteFactory())
      using (System.Data.Common.DbConnection dbConn = factory.CreateConnection())
      {
        dbConn.ConnectionString = connString;
        dbConn.Open();
        using (System.Data.Common.DbCommand cmd = dbConn.CreateCommand())
        {
          //create table
          cmd.CommandText = @"CREATE TABLE IF NOT EXISTS T1 (ID integer primary key, T text);";
          cmd.ExecuteNonQuery();
 
          //parameterized insert
          cmd.CommandText = @"INSERT INTO T1 (ID,T) VALUES(@id,@t)";
           
          var p1 = cmd.CreateParameter();
          p1.ParameterName = "@id";
          p1.Value = 1;
 
          var p2 = cmd.CreateParameter();
          p2.ParameterName = "@t";
          p2.Value = "test1";
 
          cmd.Parameters.Add(p1);
          cmd.Parameters.Add(p2);
 
          cmd.ExecuteNonQuery();
 
          //read from the table
          cmd.CommandText = @"SELECT ID, T FROM T1";
          using (System.Data.Common.DbDataReader reader = cmd.ExecuteReader())
          {
            while (reader.Read())
            {
              long id = reader.GetInt64(0);
              string t = reader.GetString(1);
              Console.WriteLine("record read as id: {0} t: {1}", id, t);
            }
          }
          cmd.Dispose();
        }
        if (dbConn.State != System.Data.ConnectionState.Closed) dbConn.Close();
        dbConn.Dispose();
        factory.Dispose();
      }
      Console.WriteLine("End Test1");
    }
 
    private static void Test2(string connString)
    {
      Console.WriteLine("Begin Test2");
 
      using (var dbConn = new System.Data.SQLite.SQLiteConnection(connString))
      {
        dbConn.Open();
        using (System.Data.SQLite.SQLiteCommand cmd = dbConn.CreateCommand())
        {
          //create table
          cmd.CommandText = @"CREATE TABLE IF NOT EXISTS T1 (ID integer primary key, T text);";
          cmd.ExecuteNonQuery();
 
          //parameterized insert - more flexibility on parameter creation
          cmd.CommandText = @"INSERT INTO T1 (ID,T) VALUES(@id,@t)";
 
          cmd.Parameters.Add(new System.Data.SQLite.SQLiteParameter 
            { 
              ParameterName = "@id", 
              Value = 1 
            });
 
          cmd.Parameters.Add(new System.Data.SQLite.SQLiteParameter
          {
            ParameterName = "@t",
            Value = "test2"
          });
 
          cmd.ExecuteNonQuery();
 
          //read from the table
          cmd.CommandText = @"SELECT ID, T FROM T1";
          using (System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader())
          {
            while (reader.Read())
            {
              long id = reader.GetInt64(0);
              string t = reader.GetString(1);
              Console.WriteLine("record read as id: {0} t: {1}", id, t);
            }
          }
        }
        if (dbConn.State != System.Data.ConnectionState.Closed) dbConn.Close();
      }
      Console.WriteLine("End Test2");
    }
  }
}
        //C:\Users\Deblia\Desktop\TWDatabases\SQLite

