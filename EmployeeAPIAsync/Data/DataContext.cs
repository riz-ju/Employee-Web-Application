using EmployeeAPIAsync.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIAsync.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
                
        }
        public DbSet<Employee> Employee => Set<Employee>();
    }
}
