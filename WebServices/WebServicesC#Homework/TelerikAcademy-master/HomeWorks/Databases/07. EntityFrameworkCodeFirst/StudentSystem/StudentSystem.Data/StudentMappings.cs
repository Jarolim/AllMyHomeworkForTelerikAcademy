using StudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data
{
    public class StudentMappings : EntityTypeConfiguration<Student>
    {
        public StudentMappings()
        {
            this.HasKey(s => s.Id);
            this.Property(s => s.Name).IsUnicode(true);
            this.Property(s => s.Name).HasMaxLength(255);
            this.Property(s => s.Name).IsRequired();
            this.Property(s => s.Number).IsRequired();
        }
    }
}
