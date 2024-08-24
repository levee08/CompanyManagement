using CompanyManagement.Data;
using CompanyManagement.Models;

namespace CompanyManagement.Repository
{
    public class DepartmentRepository:GenericRepo<Department>
    {

        public DepartmentRepository(AppDbContext ctx) : base(ctx)
        {
        }

        public override Department Read(int id)
        {
            return ctx.Departments.FirstOrDefault(d => d.Id == id);
        }

        public override void Update(Department item)
        {
            var entity = Read(item.Id);
            if (entity != null)
            {
                entity.Name = item.Name;
                entity.Budget = item.Budget;
                entity.CompanyId = item.CompanyId;
                ctx.SaveChanges();
            }
        }

    }
}
