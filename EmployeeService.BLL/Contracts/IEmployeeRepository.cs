using EmployeeService.BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeService.BLL.Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeViewModel>> GetAll();
        Task<EmployeeViewModel> GetById(int id);
        Task<EmployeeViewModel> Create(EmployeeCreateModel item);
        Task<bool> Update(EmployeeViewModel item);
        Task<bool> Delete(int id);
    }
}
