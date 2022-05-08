using EmployeeService.BLL.Contracts;
using EmployeeService.BLL.Models;
using EmployeeService.DAL.Entities;
using EmployeeService.DAL.Storage;
using Mapster;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.BLL.Managers
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBContext _context;

        public EmployeeRepository(EmployeeDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetAll()
        {
            var list = _context.Employees.ProjectToType<EmployeeViewModel>().ToList();

            return list;
        }

        public async Task<EmployeeViewModel> GetById(int id)
        {
            var employeeItem = await _context.Employees.FindAsync(id);

            return employeeItem.Adapt<EmployeeViewModel>();
        }

        public async Task<EmployeeViewModel> Create(EmployeeCreateModel item)
        {
            var employeeModel = item.Adapt<Employee>();

            _context.Employees.Add(employeeModel);
            await _context.SaveChangesAsync();

            return employeeModel.Adapt<EmployeeViewModel>();
        }

        public async Task<bool> Update(EmployeeViewModel item)
        {
            var updateEmployeeItem = item.Adapt<Employee>();

            try
            {
                _context.Employees.Update(updateEmployeeItem);
                await _context.SaveChangesAsync();
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var employeeItemtoDelete = await _context.Employees.FindAsync(id);

                _context.Employees.Remove(employeeItemtoDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
