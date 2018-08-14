using System.Collections.Generic;

namespace EFCodeFirstDemo.Models
{
    public class Department : Entity
    {
        public string Description { get; set; }

        public virtual HashSet<Employee> Employees { get; set; }
    }
}