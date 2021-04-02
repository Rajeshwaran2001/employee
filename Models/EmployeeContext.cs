using Microsoft.EntityFrameworkCore;



namespace employee.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        public DbSet<Employee> EmployeeTable { get; set; }

    }
}