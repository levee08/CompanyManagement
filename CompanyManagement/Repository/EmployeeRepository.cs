using CompanyManagement.Data;
using CompanyManagement.Models;

namespace CompanyManagement.Repository
{
    public class EmployeeRepository : GenericRepo<Employee>
    {
        public EmployeeRepository(AppDbContext ctx) : base(ctx)
        {
        }

        public override async Task<Employee> ReadAsync(int id)
        {
            return await ctx.Employees.FindAsync(id);
        }

        public override async Task UpdateAsync(Employee item)
        {
            var entity = await ReadAsync(item.Id);
            if (entity != null)
            {
                entity.Name = item.Name;
                entity.Address = item.Address;
                entity.BirthPlace = item.BirthPlace;
                entity.BirthDate = item.BirthDate;
                entity.MobileNumber = item.MobileNumber;
                entity.LandlineNumber = item.LandlineNumber;
                entity.DepartmentId = item.DepartmentId;
                await ctx.SaveChangesAsync();
            }
        }
    }
}
