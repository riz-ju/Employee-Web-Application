using Employee.Web.Models;
using Employee.Web.Service.IService;
using Employee.Web.Utility;
using static Employee.Web.Utility.SD;
using System;

namespace Employee.Web.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IBaseService _baseService;
        public EmployeeService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ServiceResponse?> CreateEmployee(EmployeeDto employee)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data=employee,
                Url = SD.EmployeeAPIBase + "/api/Employee" 

            }); 
        }

        public async Task<ServiceResponse?> DeleteEmployee(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.EmployeeAPIBase + "/api/Employee/" + id
            });
            
        }

        public async  Task<ServiceResponse?> GetAllEmployeeAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType= SD.ApiType.GET,
                Url = SD.EmployeeAPIBase + "/api/Employee/GetAllEmployees"

            });
        }

        public async Task<ServiceResponse?> GetEmployeeAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.EmployeeAPIBase + "/api/Employee/" + id

            }); ;
        }

        public async Task<ServiceResponse?> UpdateEmployee(EmployeeDto employee)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = employee,
                Url = SD.EmployeeAPIBase + "/api/Employee"

            }); ;
        }
    }
}
