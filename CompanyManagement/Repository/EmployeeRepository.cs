using CompanyManagement.Data;
using CompanyManagement.Models;

namespace CompanyManagement.Repository
{
    public class EmployeeRepository : GenericRepo<Employee>
    {
        public EmployeeRepository(AppDbContext ctx) : base(ctx)
        {
        }

        public override Employee Read(int id)
        {
            return ctx.Employees.FirstOrDefault(e => e.Id == id);
        }

        public override void Update(Employee item)
        {
            var entity = Read(item.Id);
            if (entity != null)
            {
                entity.Name = item.Name;
                entity.Address = item.Address;
                entity.BirthPlace = item.BirthPlace;
                entity.BirthDate = item.BirthDate;
                entity.MobileNumber = item.MobileNumber;
                entity.LandlineNumber = item.LandlineNumber;
                entity.DepartmentId = item.DepartmentId;
                ctx.SaveChanges();
            }
        }
    }
}
