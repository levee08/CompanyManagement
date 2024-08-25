using CompanyManagement.Data;
using CompanyManagement.Models;

namespace CompanyManagement.Repository
{
    public class CompanyRepository:GenericRepo<Company>
    {

        public CompanyRepository(AppDbContext ctx) : base(ctx)
        {
        }

        public override async Task<Company> ReadAsync(int id)
        {
            return await ctx.Companies.FindAsync(id);
        }

        public override async Task UpdateAsync(Company item)
        {
            var entity = await ReadAsync(item.Id);
            if (entity != null)
            {
                entity.Name = item.Name;
                entity.TaxNumber = item.TaxNumber;
                entity.Address = item.Address;
                entity.FoundedDate = item.FoundedDate;
                entity.AnnualRevenue = item.AnnualRevenue;
                await ctx.SaveChangesAsync();
            }
        }
    }
}
