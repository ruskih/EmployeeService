namespace EmployeeService.BLL.Models
{
    public record EmployeeCreateModel
    {
        public string EmployeeName { get; set; }

        public string DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string CurrentAddress { get; set; }

        public string PermanentAddress { get; set; }

        public string City { get; set; }

        public string Nationality { get; set; }
    }
}
