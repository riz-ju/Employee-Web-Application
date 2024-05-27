using Employee.Web.Models;

namespace Employee.Web.Service.IService
{
    public interface IEmployeeService
    {
        Task<ServiceResponse?> GetEmployeeAsync(int id);
        Task<ServiceResponse?> GetAllEmployeeAsync();
        Task<ServiceResponse?> CreateEmployee(EmployeeDto employee);
        Task<ServiceResponse?> UpdateEmployee(EmployeeDto employee);
        Task<ServiceResponse?> DeleteEmployee(int id);

    }
}
