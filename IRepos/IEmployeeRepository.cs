using APPITasks.Models;

namespace APPITasks.IRepos
{
	public interface IEmployeeRepository
	{
		List<Employee> GetAll();
		Employee GetById(int id);
		int Add(Employee employee);
		int Update(int id,Employee employee);
		int Delete(int id);
	}
}
