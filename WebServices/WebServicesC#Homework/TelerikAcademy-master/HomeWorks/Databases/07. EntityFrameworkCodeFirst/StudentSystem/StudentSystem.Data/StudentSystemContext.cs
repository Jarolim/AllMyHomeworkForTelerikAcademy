using StudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("StudentSystem")
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Tag>().HasKey(x => x.TagId);
            //modelBuilder.Entity<Tag>().Property(x => x.Text).IsUnicode(true);
            //modelBuilder.Entity<Tag>().Property(x => x.Text).HasMaxLength(255);

            //// modelBuilder.Entity<Tag>().Property(x => x.Text).IsFixedLength();

            //// modelBuilder.Configurations.Add(new TagMappings());

            modelBuilder.Configurations.Add(new HomeworkMappings());
            modelBuilder.Configurations.Add(new StudentMappings());
            modelBuilder.Configurations.Add(new CourseMappings());
            base.OnModelCreating(modelBuilder);
        }
    }
}
