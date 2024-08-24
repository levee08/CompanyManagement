using CompanyManagement.Data;
using CompanyManagement.Models;

namespace CompanyManagement.Repository
{
    public class CompanyRepository:GenericRepo<Company>
    {

        public CompanyRepository(AppDbContext ctx) : base(ctx)
        {
        }

        public override Company Read(int id)
        {
            return ctx.Companies.FirstOrDefault(c => c.Id == id);
        }

        public override void Update(Company item)
        {
            var entity = Read(item.Id);
            if (entity != null)
            {
                entity.Name = item.Name;
                entity.TaxNumber = item.TaxNumber;
                entity.Address = item.Address;
                entity.FoundedDate = item.FoundedDate;
                entity.AnnualRevenue = item.AnnualRevenue;
                ctx.SaveChanges();
            }
        }
    }
}
