namespace APPITasks.Models
{
	public class Department
	{
        public int? Id { get; set; }
        public string? Name{ get; set; }
        public string? Manager{ get; set; }

        public virtual List<Employee> Employee { get; set; }
    }
}
