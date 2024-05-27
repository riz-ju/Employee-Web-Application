
using Employee.Web.Models;

namespace Employee.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ServiceResponse?> SendAsync(RequestDto requestDto);
    }
}
