using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleAspCore.DataLayer.Entities;
using SampleAspCore.Helpers;

namespace SampleAspCore.DataLayer.EntityConfigurations
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public override void Map(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employees");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("emp_no");
            builder.Property(x => x.Dob).HasColumnName("birth_date");
            builder.Property(x => x.FirstName).HasColumnName("first_name");
            builder.Property(x => x.LastName).HasColumnName("last_name");
            builder.Property(x => x.Gender).HasColumnName("gender");
            builder.Property(x => x.Doh).HasColumnName("hire_date");

            builder.HasMany(x => x.Salaries).WithOne(x => x.Employee).HasForeignKey(x => x.EmpId);
        }
    }
}
