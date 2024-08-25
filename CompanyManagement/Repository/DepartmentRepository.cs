using CompanyManagement.Data;
using CompanyManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class DepartmentRepository : GenericRepo<Department>
{
    public DepartmentRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task<Department> ReadAsync(int id)
    {
        return await _context.Departments
            .Include(d => d.Employees)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public override async Task<IQueryable<Department>> ReadAllAsync()
    {
        return await Task.FromResult(
            _context.Departments
            .Include(d => d.Employees)
        );
    }
}
