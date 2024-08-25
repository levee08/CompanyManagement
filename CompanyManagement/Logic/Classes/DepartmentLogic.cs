using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyManagement.Logic.Interfaces;
using CompanyManagement.Models;
using CompanyManagement.Repository;

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

        public async Task UpdateAsync(Department department)
        {
            await _departmentRepository.UpdateAsync(department);
        }

        public async Task DeleteAsync(int id)
        {
            await _departmentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _departmentRepository.ReadAllAsync();
        }
    }
}
