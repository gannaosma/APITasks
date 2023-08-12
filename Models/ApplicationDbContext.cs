using Microsoft.EntityFrameworkCore;

namespace APPITasks.Models
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
