using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SampleAspCore.DataLayer.EntityConfigurations;
using SampleAspCore.DataLayer.Interfaces;
using SampleAspCore.Helpers;
namespace SampleAspCore.DataLayer
{
    public sealed class DataContext : DbContext, IDataContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json")
                           .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DataContext"));
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //configuring department table
            modelBuilder.AddConfiguration(new DepartmentConfiguration());
            modelBuilder.AddConfiguration(new EmployeeDepartmentConfiguration());
            modelBuilder.AddConfiguration(new EmployeeConfiguration());
            modelBuilder.AddConfiguration(new SalaryConfiguration());
        }
    }
}
