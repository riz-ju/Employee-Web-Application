using EmployeeAPIAsync.Data;
using EmployeeAPIAsync.Dtos;
using EmployeeAPIAsync.Model;
using EmployeeAPIAsync.Services.EmployeeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EmployeeAPIAsync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
      
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<ActionResult<ServiceResponse>> GetAllEmployees()
        {

           
            _logger.LogCritical("Hye the Get All controller is invoked here");

            return Ok( await _employeeService.GetAllEmployees());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse>> GetEmployeeById(int id)
        {
            return Ok(await _employeeService.GetEmployeeById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> CreateEmployee([FromBody] AddEmployeeDto employee)
        {
            return Ok(await _employeeService.CreateEmployee(employee));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse>> UpdateEmployee([FromBody] UpdateEmployeeDto employee)
        {
            return Ok(await _employeeService.UpdateEmployee(employee));
        }

		[HttpDelete("{id}")]
		public async Task<ActionResult<ServiceResponse>> DeleteEmployee(int id)
        {
            return Ok(await _employeeService.DeleteEmployee(id));
        } 
    }
}
