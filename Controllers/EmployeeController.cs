using APPITasks.IRepos;
using APPITasks.Models;
using APPITasks.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APPITasks.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeRepository employee;
		private readonly ApplicationDbContext context;


		public EmployeeController(ApplicationDbContext _context,IEmployeeRepository _employee)
        {
			context = _context;
			employee = _employee;
		}
		[HttpGet]
		public IActionResult GetAllEmployees()
		{
			List<Employee> employees =  employee.GetAll();
			return Ok(employees);
		}
		[HttpGet("{id:int}")]
		public IActionResult GetById(int id)
		{
			Employee emp = employee.GetById(id);
			return Ok(emp);
		}

		[HttpPost(Name = "Create")]
		public IActionResult Insert(Employee employee)
		{
			if(ModelState.IsValid)
			{
				context.Employees.Add(employee);
				context.SaveChanges();

				string url =  Url.Link("Create", new { id = employee.Id });
				return Created(url,employee);
			}
			return BadRequest(ModelState);
		}

		[HttpPut]
		public IActionResult Update(int id,Employee emp)
		{
			if (ModelState.IsValid)
			{
				employee.Update(id,emp);
				context.SaveChanges();

				return StatusCode(204,"Employee Updated");
			}
			return BadRequest(ModelState);
		}

		[HttpDelete("{id:int}")]
		public IActionResult Delelte(int id)
		{
			int x = employee.Delete(id);
			if(x == 1)
			{
				return StatusCode(204, "Employee removed");
			}
			return BadRequest();
		}
	}
}
