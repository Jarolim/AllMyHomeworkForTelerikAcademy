using System;
using System.Linq;
using StudentSystem.Data;
using StudentSystem.Data.Migrations;

using System.Data.Entity;


namespace StudentSystem.Data.Migrations
{
    public class Program
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsSystemContext, Configuration>());


            StudentsSystemContext studentSystemDb = new StudentsSystemContext();

            foreach (var item in studentSystemDb.Students)
            {
                Console.WriteLine("Name: {0} with studentNumber {1}", item.StudentName + ' ' + item.StudentLastName, item.StudentNumber);
            }

            studentSystemDb.SaveChanges();
        }
    }
}