using CompanyManagement.Data;
using CompanyManagement.Models;

namespace CompanyManagement.Repository
{
    public class DepartmentRepository:GenericRepo<Department>
    {

        public DepartmentRepository(AppDbContext ctx) : base(ctx)
        {
        }

        public override async Task<Department> ReadAsync(int id)
        {
            return await ctx.Departments.FindAsync(id);
        }

        public override async Task UpdateAsync(Department item)
        {
            var entity = await ReadAsync(item.Id);
            if (entity != null)
            {
                entity.Name = item.Name;
                entity.Budget = item.Budget;
                entity.CompanyId = item.CompanyId;
                await ctx.SaveChangesAsync();
            }
        }

    }
}
