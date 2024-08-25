using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyManagement.Logic.Interfaces;
using CompanyManagement.Models;
using CompanyManagement.Repository;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace CompanyManagement.Logic
{
    public class DepartmentLogic : IDepartmentLogic
    {
        private readonly IRepository<Department> _departmentRepository;

        public DepartmentLogic(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task CreateAsync(Department department)
        {
            await _departmentRepository.CreateAsync(department);
        }

        public async Task<Department> ReadAsync(int id)
        {
            return await _departmentRepository.ReadAsync(id);
        }

        public async Task<bool> UpdateAsync(Department department)
        {
            var entity =await _departmentRepository.ReadAsync(department.Id);
            if(department==null)
            {
                return false;
            }
            await _departmentRepository.UpdateAsync(department);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _departmentRepository.ReadAsync(id);
            if(entity==null)
            {
                return false;
            }
            await _departmentRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _departmentRepository.ReadAllAsync();
        }


    
    }
}
