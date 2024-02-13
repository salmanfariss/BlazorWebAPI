using System.ComponentModel.DataAnnotations;

namespace CRUD_BlazorSample.Model
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }

        public float Salary { get; set; }
    }
}
