using APPITasks.Models;

namespace APPITasks.DTO
{
	public class DepartmentWithEmployee
	{
        public int Id { get; set; }
        public string? DeptName { get; set; }
        public string? Manger { get; set; }
        public List<string> EmployeesName { get; set; } = new List<string>();

    }
}
