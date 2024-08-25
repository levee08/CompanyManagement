using CompanyManagement.Data;
using CompanyManagement.Models;
public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Companies.Any())
        {
            return;   // Seed data already present
        }

        var companies = new Company[]
        {
            new Company { Name = "Tech Innovators", Address = "123 Innovation St", FoundedDate = new DateTime(2000, 1, 1), TaxNumber = 123456789, AnnualRevenue = 10000000M },
            // Add other companies here
        };

        foreach (var c in companies)
        {
            context.Companies.Add(c);
        }
        context.SaveChanges();
    }
}
