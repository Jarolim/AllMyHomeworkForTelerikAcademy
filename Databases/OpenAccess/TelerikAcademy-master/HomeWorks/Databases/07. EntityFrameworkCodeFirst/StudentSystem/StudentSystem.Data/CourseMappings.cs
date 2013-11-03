using StudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data
{
    class CourseMappings : EntityTypeConfiguration<Course>
    {
        public CourseMappings()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Name).IsUnicode(true);
            this.Property(c => c.Name).HasMaxLength(255);
            this.Property(c => c.Name).IsRequired();
            this.Property(c => c.Description).IsUnicode(true);
            this.Property(c => c.Description).IsMaxLength();
            this.Property(c => c.Description).IsOptional();
            this.Property(c => c.Materials).IsUnicode(true);
            this.Property(c => c.Materials).IsMaxLength();
            this.Property(c => c.Materials).IsOptional();
        }
    }
}
