using APPITasks.Models;

namespace APPITasks.IRepos
{
	public interface IDepartmentRepository
	{
		List<Department> GetDepartments();
		Department GetDepartmentById(int id);
	}
}
