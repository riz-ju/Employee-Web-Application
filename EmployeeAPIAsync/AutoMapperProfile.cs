using AutoMapper;
using EmployeeAPIAsync.Dtos;
using EmployeeAPIAsync.Model;

namespace EmployeeAPIAsync
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();
        }
    }
}
