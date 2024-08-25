using CompanyManagement.Data;
using CompanyManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CompanyManagement.Repository
{
    public class EmployeeRepository : GenericRepo<Employee>
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<Employee> ReadAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.Id == id);
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
                await _context.SaveChangesAsync();
            }
        }
    }
}
