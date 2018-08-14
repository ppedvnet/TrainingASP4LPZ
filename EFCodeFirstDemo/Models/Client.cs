namespace EFCodeFirstDemo.Models
{
    public class Client : Person
    {
        public string CustomerNumber { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}