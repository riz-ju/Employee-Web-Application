using Employee.Web.Models;
using Employee.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace Employee.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<IActionResult> EmployeeIndex()
        {
            List<EmployeeDto>? list = new();
            ServiceResponse? response = await _employeeService.GetAllEmployeeAsync();

            if(response != null && response.success)
            {
                list = JsonConvert.DeserializeObject<List<EmployeeDto>>(Convert.ToString(response.Data));
            }
            return View(list);
        }

        public async Task<IActionResult> EmployeeCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeCreate(EmployeeDto model)
        {
            if (ModelState.IsValid)
            {
                ServiceResponse? response = await _employeeService.CreateEmployee(model);

                if (response != null && response.success)
                {
                    return RedirectToAction(nameof(EmployeeIndex));
                }
            }
            return View(model);
        }

        
		public async Task<IActionResult> EmployeeDelete(int Id)
		{
            ServiceResponse? response = await _employeeService.DeleteEmployee(Id);

            if(response != null && response.success)
            {
                return RedirectToAction(nameof(EmployeeIndex));
            }
			return RedirectToAction(nameof(EmployeeIndex));
		}

        public async Task<IActionResult> EmployeeUpdate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeUpdate(EmployeeDto model)
        {
            if (ModelState.IsValid)
            {
                ServiceResponse? response = await _employeeService.UpdateEmployee(model);

                if (response != null && response.success)
                {
                    return RedirectToAction(nameof(EmployeeIndex));
                }
            }
            return View(model);
        }
    }
}
