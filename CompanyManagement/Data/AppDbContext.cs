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

            modelBuilder.Entity<Company>()
                .Property(c => c.AnnualRevenue)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Department>()
                .Property(d => d.Budget)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Company>().HasData(
              new Company { Id = 1, Name = "Tech Innovators", Address = "123 Innovation St", FoundedDate = new DateTime(2000, 1, 1), TaxNumber = 123456789, AnnualRevenue = 10000000 },
              new Company { Id = 2, Name = "Global Solutions", Address = "456 Global Ave", FoundedDate = new DateTime(2005, 2, 15), TaxNumber = 987654321, AnnualRevenue = 15000000 },
              new Company { Id = 3, Name = "Eco Friendly Inc.", Address = "789 Green Rd", FoundedDate = new DateTime(2010, 3, 10), TaxNumber = 567890123, AnnualRevenue = 8000000 }
          );

            
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Research and Development", Budget = 5000000, CompanyId = 1 },
                new Department { Id = 2, Name = "Sales", Budget = 3000000, CompanyId = 1 },
                new Department { Id = 3, Name = "Customer Support", Budget = 2000000, CompanyId = 2 },
                new Department { Id = 4, Name = "Marketing", Budget = 2500000, CompanyId = 2 },
                new Department { Id = 5, Name = "Sustainability", Budget = 1500000, CompanyId = 3 }
            );

            
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Alice Johnson", Address = "101 Main St", BirthPlace = "City A", BirthDate = new DateTime(1985, 1, 1), MobileNumber = "123-456-7890", LandlineNumber = "098-765-4321", DepartmentId = 1 },
                new Employee { Id = 2, Name = "Bob Smith", Address = "102 Main St", BirthPlace = "City B", BirthDate = new DateTime(1987, 2, 2), MobileNumber = "123-456-7891", LandlineNumber = "098-765-4322", DepartmentId = 1 },
                new Employee { Id = 3, Name = "Charlie Brown", Address = "103 Main St", BirthPlace = "City C", BirthDate = new DateTime(1990, 3, 3), MobileNumber = "123-456-7892", LandlineNumber = "098-765-4323", DepartmentId = 2 },
                new Employee { Id = 4, Name = "David Williams", Address = "104 Main St", BirthPlace = "City D", BirthDate = new DateTime(1992, 4, 4), MobileNumber = "123-456-7893", LandlineNumber = "098-765-4324", DepartmentId = 2 },
                new Employee { Id = 5, Name = "Emma Wilson", Address = "105 Main St", BirthPlace = "City E", BirthDate = new DateTime(1994, 5, 5), MobileNumber = "123-456-7894", LandlineNumber = "098-765-4325", DepartmentId = 3 },
                new Employee { Id = 6, Name = "Frank Miller", Address = "106 Main St", BirthPlace = "City F", BirthDate = new DateTime(1996, 6, 6), MobileNumber = "123-456-7895", LandlineNumber = "098-765-4326", DepartmentId = 3 },
                new Employee { Id = 7, Name = "Grace Davis", Address = "107 Main St", BirthPlace = "City G", BirthDate = new DateTime(1998, 7, 7), MobileNumber = "123-456-7896", LandlineNumber = "098-765-4327", DepartmentId = 4 },
                new Employee { Id = 8, Name = "Henry Garcia", Address = "108 Main St", BirthPlace = "City H", BirthDate = new DateTime(2000, 8, 8), MobileNumber = "123-456-7897", LandlineNumber = "098-765-4328", DepartmentId = 4 },
                new Employee { Id = 9, Name = "Ivy Martinez", Address = "109 Main St", BirthPlace = "City I", BirthDate = new DateTime(2002, 9, 9), MobileNumber = "123-456-7898", LandlineNumber = "098-765-4329", DepartmentId = 5 },
                new Employee { Id = 10, Name = "Jack Taylor", Address = "110 Main St", BirthPlace = "City J", BirthDate = new DateTime(2004, 10, 10), MobileNumber = "123-456-7899",  DepartmentId = 5 }
            );

            Console.WriteLine("Seed data has been applied.");
        }
    }
}
