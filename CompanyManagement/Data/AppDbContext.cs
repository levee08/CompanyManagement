using CompanyManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>()
               .HasMany(c => c.Departments)
               .WithOne(d => d.Company)
               .HasForeignKey(d => d.CompanyId);

            modelBuilder.Entity<Department>()
               .HasMany(d => d.Employees)
               .WithOne(e => e.Department)
               .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<Company>()
             .HasIndex(c => c.Name)
              .IsUnique();

        }
    }
}
