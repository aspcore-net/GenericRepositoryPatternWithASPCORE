using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleAspCore.DataLayer.Entities;
using SampleAspCore.Helpers;

namespace SampleAspCore.DataLayer.EntityConfigurations
{
    public class DepartmentConfiguration : EntityTypeConfiguration<Department>
    {
        public override void Map(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("departments");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("dept_no");
            builder.Property(x => x.Name).HasColumnName("dept_name");
        }
    }
}
