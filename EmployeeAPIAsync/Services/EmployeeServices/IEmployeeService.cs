using EmployeeAPIAsync.Dtos;
using EmployeeAPIAsync.Model;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPIAsync.Services.EmployeeServices
{
    public interface IEmployeeService
    {
        public Task<ServiceResponse> GetAllEmployees();
        public Task<ServiceResponse> GetEmployeeById(int id);
        public Task<ServiceResponse> CreateEmployee(AddEmployeeDto employee);
        public Task<ServiceResponse> UpdateEmployee( UpdateEmployeeDto Employee);
        public Task<ServiceResponse> DeleteEmployee(int id);
    }
}
