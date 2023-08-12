using APPITasks.DTO;
using APPITasks.IRepos;
using APPITasks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APPITasks.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentController : ControllerBase
	{
		private readonly ApplicationDbContext context;
		private readonly IDepartmentRepository department;

		public DepartmentController(ApplicationDbContext _context, IDepartmentRepository _department)
		{
			context = _context;
			department = _department;
		}
		[HttpGet]
		public IActionResult getDeparments()
		{
			List<Department> departments = department.GetDepartments();
			return Ok(departments);
		}

		[HttpGet("{id:int}")]
		public IActionResult getDeparment(int id)
		{
			Department dept = department.GetDepartmentById(id);
			DepartmentWithEmployee deptDto = new DepartmentWithEmployee();

			deptDto.Id = id;
			deptDto.DeptName = dept.Name;
			deptDto.Manger = dept.Manager;
			foreach(var item in dept.Employee)
			{
				deptDto.EmployeesName.Add(item.Name);
			}
			return Ok(deptDto);
		}
	}
}
