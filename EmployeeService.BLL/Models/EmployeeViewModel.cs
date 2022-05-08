namespace EmployeeService.BLL.Models
{
    public record EmployeeViewModel : EmployeeCreateModel
    {
        public int EmployeeId { get; set; }
    }
}
