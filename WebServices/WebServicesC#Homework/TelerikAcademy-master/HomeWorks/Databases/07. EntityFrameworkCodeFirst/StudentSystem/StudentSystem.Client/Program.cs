using StudentSystem.Data;
using StudentSystem.Data.Migrations;
using StudentSystem.Model;
using System.Data.Entity;


namespace StudentSystem.Client
{
    class Program
    {
        static void Main(string[] args)
        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());

            using (var studentSystem = new StudentSystemContext())
            {
                studentSystem.Students.Add(new Student()
                {
                    Name = "Svetlin Nakov",
                    Number = 1534
                });

                studentSystem.SaveChanges();
            }
        }
    }
}
