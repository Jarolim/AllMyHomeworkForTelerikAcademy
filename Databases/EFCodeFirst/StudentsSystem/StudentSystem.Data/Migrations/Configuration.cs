namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    public sealed class Configuration : DbMigrationsConfiguration<StudentsSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentsSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            HashSet<Homework> homeworks = new HashSet<Homework>();

            Homework firstHomework = new Homework
            {
                HomeworkID = 1,
                CourseId = 1,
                HomeworkContent = "Bubla2013",
                StudentId = 1,
                TimeSent = new DateTime(1999, 02, 03)
            };

            Homework secondHomework = new Homework
            {
                HomeworkID = 2,
                CourseId = 1,
                HomeworkContent = "Bubla2014",
                StudentId = 1,
                TimeSent = new DateTime(1999, 02, 03)
            };

            homeworks.Add(firstHomework);

            homeworks.Add(secondHomework);

            Course js = new Course
            {
                CourseId = 1,
                CourseName = "JS",
                Description = "Web",
                Materials = "Many",
                Homeworks = homeworks
            };

            Student sam = new Student
            {
                StudentId = 1,
                StudentName = "Samuel",
                StudentNumber = 666,
                Homeworks = homeworks,
                Courses = new HashSet<Course> { js },
                StudentLastName = "Jackson"
            };

            Student dan = new Student
            {
                StudentId = 2,
                StudentName = "Daniel",
                StudentNumber = 999,
                Homeworks = homeworks,
                Courses = new HashSet<Course> { js },
                StudentLastName = "Crank"
            };

            js.Students = new HashSet<Student> { sam };
            js.Students = new HashSet<Student> { dan };

            context.Students.AddOrUpdate(sam);
            context.Students.AddOrUpdate(dan);
            context.Courses.AddOrUpdate(js);
            context.Homeworks.AddOrUpdate(firstHomework, secondHomework);
        }
    }
}