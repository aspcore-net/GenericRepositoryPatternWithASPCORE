using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleAspCore.DataLayer.Entities;
using SampleAspCore.Helpers;

namespace SampleAspCore.DataLayer.EntityConfigurations
{
    public class EmployeeDepartmentConfiguration : EntityTypeConfiguration<EmployeeDepartment>
    {
        public override void Map(EntityTypeBuilder<EmployeeDepartment> builder)
        {
            builder.ToTable("dept_emp");

            builder.HasKey(x => new { x.DeptId, x.EmpId });
            builder.Property(x => x.DeptId).HasColumnName("dept_no");
            builder.Property(x => x.EmpId).HasColumnName("emp_no");
            builder.Property(x => x.StartDate).HasColumnName("from_date");
            builder.Property(x => x.EndDate).HasColumnName("to_date");
        }
    }
}
