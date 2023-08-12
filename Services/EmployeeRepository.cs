using APPITasks.IRepos;
using APPITasks.Models;

namespace APPITasks.Services
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly ApplicationDbContext context;
		public EmployeeRepository(ApplicationDbContext _context)
        {
            context= _context;
        }
		public List<Employee> GetAll()
		{
			
			return context.Employees.ToList();
		}
		public Employee GetById(int id)
		{
			return context.Employees.FirstOrDefault(i=>i.Id == id);
		}
		public int Add(Employee employee)
		{
			context.Employees.Add(employee);
			int row = context.SaveChanges();
			return row;
		}
		public int Update(int id,Employee employee)
		{
			Employee oldEmp = context.Employees.FirstOrDefault(i => i.Id == id);

			oldEmp.Name = employee.Name;
			oldEmp.Salary = employee.Salary;
			oldEmp.Phone = employee.Phone;
			oldEmp.Adress = employee.Adress;

			int row = context.SaveChanges();
			return row;
		}
		 public int Delete(int id)
		 {
			Employee oldEmp = context.Employees.FirstOrDefault(i => i.Id == id);

			context.Remove(oldEmp);
			int row = context.SaveChanges();
			return row;
		 }
	}
}
