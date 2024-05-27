using Microsoft.AspNetCore.Mvc;
using static Employee.Web.Utility.SD;

namespace Employee.Web.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        
    }
}
