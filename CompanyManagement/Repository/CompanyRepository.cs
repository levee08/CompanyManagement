using CompanyManagement.Data;
using CompanyManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class CompanyRepository : GenericRepo<Company>
{
    public CompanyRepository(AppDbContext context) : base(context)
    {
    }

    
    public override async Task<Company> ReadAsync(int id)
    {
        return await _context.Companies
       .Include(c => c.Departments) 
           .ThenInclude(d => d.Employees) 
       .FirstOrDefaultAsync(c => c.Id == id);

    }


    public override async Task<IQueryable<Company>> ReadAllAsync()
    {
        return await Task.FromResult(
        _context.Companies
        .Include(c => c.Departments) 
            .ThenInclude(d => d.Employees)
    );
    }
}
