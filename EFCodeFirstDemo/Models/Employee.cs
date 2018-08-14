using System.Collections.Generic;

namespace EFCodeFirstDemo.Models
{
    public class Employee : Person
    {
        public string Occupation { get; set; }

        public virtual HashSet<Client> Clients { get; set; }
        public virtual HashSet<Department> Departments { get; set; }
    }
}