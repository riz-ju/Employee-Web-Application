using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace EmployeeAPIAsync.Model
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
