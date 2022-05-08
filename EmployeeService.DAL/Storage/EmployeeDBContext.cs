using EmployeeService.DAL.Entities;
using EmployeeService.DAL.Storage.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.DAL.Storage
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EmployeeItemConfiguration());
        }
    }
}
