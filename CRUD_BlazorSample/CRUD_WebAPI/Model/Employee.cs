using System.ComponentModel.DataAnnotations;

namespace CRUD_WebAPI
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Department { get; set; }

        public double Salary { get; set; }
    }
}
