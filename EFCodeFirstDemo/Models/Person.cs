using System;

namespace EFCodeFirstDemo.Models
{
    public abstract class Person : Entity
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}