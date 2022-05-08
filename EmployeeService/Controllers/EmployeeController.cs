using EmployeeService.BLL.Contracts;
using EmployeeService.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet(Name = "GetAllEmployee")]
        public async Task<IEnumerable<EmployeeViewModel>> Get()
        {
            return await _employeeRepository.GetAll();
        }

        [HttpGet("{EmployeeId}", Name = "GetEmployeeById")]
        public async Task<IActionResult> GetById(int EmployeeId)
        {
            var employeeItem = await _employeeRepository.GetById(EmployeeId);

            if (employeeItem is null)
            {
                return NotFound();
            }

            return Ok(employeeItem);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeCreateModel employeeItem)
        {
            if (employeeItem == null)
            {
                return BadRequest();
            }
            await _employeeRepository.Create(employeeItem);

            return Created(nameof(GetById), employeeItem);
        }

        [HttpPut("{EmployeeId}")]
        public async Task<IActionResult> Update(int EmployeeId, [FromBody] EmployeeViewModel updatedEmployeeItem)
        {
            if (EmployeeId != updatedEmployeeItem.EmployeeId || updatedEmployeeItem is null)
            {
                return BadRequest();
            }
            
            if(await _employeeRepository.Update(updatedEmployeeItem))
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpDelete("{EmployeeId}")]
        public async Task<IActionResult> Delete(int EmployeeId)
        {
            var previousDataItem = await _employeeRepository.GetById(EmployeeId);

            if (previousDataItem is null)
            {
                return NotFound();
            }
            
            if (await _employeeRepository.Delete(EmployeeId))
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
