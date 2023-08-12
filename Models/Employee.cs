using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPITasks.Models
{
	public class Employee
	{
        public int? Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [Range(3000,5000)]
        public double Salary { get; set; }

        [Required]
        [MaxLength(300)]
        public string? Adress { get; set; }

        [Required]
        [RegularExpression(@"^01[0-2]\d{1,8}$")]
        public string? Phone { get; set; }

        [ForeignKey("Department")]
        public int DeptID { get; set; }

        public Department Department { get; set; }
    }
}
