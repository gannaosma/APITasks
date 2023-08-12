using APPITasks.IRepos;
using APPITasks.Models;
using Microsoft.EntityFrameworkCore;

namespace APPITasks.Services
{
	public class DepartmentRepository : IDepartmentRepository
	{
		public ApplicationDbContext Context;
		public DepartmentRepository() { }
        public DepartmentRepository(ApplicationDbContext _context)
        {
			Context = _context;
		}

		public List<Department> GetDepartments()
		{
			return Context.Departments.ToList();
		}

		public Department GetDepartmentById(int id)
		{
			return Context.Departments.Include(e=>e.Employee).FirstOrDefault(i=>i.Id == id);
		}
	}
}
