using AutoMapper;
using EmployeeAPIAsync.Data;
using EmployeeAPIAsync.Dtos;
using EmployeeAPIAsync.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;

namespace EmployeeAPIAsync.Services.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ILogger<EmployeeService> _logger;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public EmployeeService(DataContext context, IMapper mapper, ILogger<EmployeeService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ServiceResponse> CreateEmployee(AddEmployeeDto employee)
        {
            var serviceResponse = new ServiceResponse();
            var newEmployee = _mapper.Map<Employee>(employee);
            try
            {
                await _context.Employee.AddAsync(newEmployee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = newEmployee;
                serviceResponse.success = true;
                serviceResponse.message = "Hye the data is added successfully";

                return serviceResponse;
            }
            catch(Exception e)
            {
                _logger.LogDebug(e.Message);
                serviceResponse.Data = newEmployee;
                serviceResponse.success = false;
                serviceResponse.message = e.ToString();

                return serviceResponse;
               // throw;
            }
          
        }

        public async Task<ServiceResponse> DeleteEmployee(int id)
        {
                var serviceResponse = new ServiceResponse();
                var employe = await _context.Employee.FindAsync(id);
                if (employe == null)
                {
                serviceResponse.Data = null;
                serviceResponse.success = false;
                serviceResponse.message = "Employee with id " + id + " doesn't exist";

                return serviceResponse;
                //throw new Exception("Employee with id "+id+ " doesn't exist");
            }

            try
            {

                _context.Employee.Remove(employe);
                    await _context.SaveChangesAsync();
                serviceResponse.Data = employe;
                serviceResponse.success = true;
                serviceResponse.message = "Employee with id " + id + " is removed";
                return serviceResponse; 
            }
            catch(Exception e)
            {
                serviceResponse.Data = employe;
                serviceResponse.success = false;
                serviceResponse.message = "Employee with id " + id + " is not deleted";
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse> GetAllEmployees()
        {
            try
            {
                var employees = await _context.Employee.ToListAsync();
                if(employees == null)
                {
                    throw new Exception("Employee is empty");
                }
                var serviceResponse = new ServiceResponse();
                serviceResponse.Data = employees;
                serviceResponse.success = true;
                serviceResponse.message = "Successfully responding all the employees";
                return serviceResponse;
            }
            catch(Exception e)
            {
                throw new Exception("Exception is encountered"+ e);
            }
            
     
        }

        public async Task<ServiceResponse> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _context.Employee.FindAsync(id);
                var serviceResponse = new ServiceResponse();
                if (employee == null)
                {
                    serviceResponse.Data = employee;
                    serviceResponse.success = false;
                    serviceResponse.message = "No employee with the id found";
                    return serviceResponse;
                     //throw new Exception("Empoye with id "+ id +" Not Found");
                }
                
                serviceResponse.Data = employee;
                serviceResponse.success = true;
                serviceResponse.message = "Successfully responding the employee with the id";
                return serviceResponse;

            }
            catch(Exception e)
            {
                _logger.LogWarning(e.Message);
                 throw new Exception("Exception is encountered" + e);
            }
           
          
        }

        public async Task<ServiceResponse> UpdateEmployee(UpdateEmployeeDto employee)
        {
            var serviceResponse = new ServiceResponse();

            /* var existingEmployee =await _context.Employee.FindAsync(id);
             if(existingEmployee == null)
             {
                 serviceResponse.Data = null;
                 serviceResponse.success = false;
                 serviceResponse.message = "Employee with id not found";
                 return serviceResponse;
             }
             existingEmployee.FirstName = employee.FirstName;
             existingEmployee.LastName = employee.LastName;
             existingEmployee.Email = employee.Email;
             existingEmployee.AddressId = employee.AddressId;
             existingEmployee.Code = employee.Code;*/
            var updateEmployee = _mapper.Map<Employee>(employee);
            try
            {
                _context.Employee.Update(updateEmployee);
                await _context.SaveChangesAsync();
                serviceResponse.Data = updateEmployee;
                serviceResponse.success = true;
                serviceResponse.message = "Employee is updated";
                return serviceResponse;
            }
            catch(DbUpdateException e)
            {
                serviceResponse.Data = updateEmployee;
                serviceResponse.success = false;
                serviceResponse.message = e.ToString();
                return serviceResponse;
            }
           // throw new NotImplementedException();
        }
    }
}
