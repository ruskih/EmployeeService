using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeService.DAL.Entities
{
    [Table("Employee")]
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string CurrentAddress { get; set; }

        public string PermanentAddress { get; set; }

        public string City { get; set; }

        public string Nationality { get; set; }
    }
}
