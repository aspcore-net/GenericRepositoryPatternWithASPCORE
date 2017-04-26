using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleAspCore.DataLayer.Entities;
using SampleAspCore.Helpers;

namespace SampleAspCore.DataLayer.EntityConfigurations
{
    public class SalaryConfiguration : EntityTypeConfiguration<Salary>
    {
        public override void Map(EntityTypeBuilder<Salary> builder)
        {
            builder.ToTable("salaries");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("sal_no");
            builder.Property(x => x.EmpId).HasColumnName("emp_no");
            builder.Property(x => x.Amount).HasColumnName("salary");
            builder.Property(x => x.FromDate).HasColumnName("from_date");
            builder.Property(x => x.ToDate).HasColumnName("to_date");
        }
    }
}
