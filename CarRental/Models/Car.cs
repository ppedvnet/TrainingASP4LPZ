using System;

namespace CarRental.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CarProducer { get; set; }
        public DateTime? YearOfConstruction { get; set; }
        public double? Consumption { get; set; }
        public CarType CarType { get; set; }
    }
}