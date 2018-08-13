using System;
using System.ComponentModel.DataAnnotations;
using System.Web.ModelBinding;

namespace CarRental.Models
{
    public class CarVm
    {
        public int Id { get; set; }

        [Display(Name = "Fahrzeug Name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "Hersteller Name")]
        public string Producer { get; set; }

        [Display(Name = "Baujahr")]
        public DateTime? YearOfConstruction { get; set; }

        [Display(Name = "Verbrauch")]
        public double? Consumption { get; set; }

        [Display(Name = "Fahrzeug Typ")]
        public CarType CarType { get; set; } = CarType.Limosine;

        [Display(Name = "Alter")]
        [BindNever]
        public int Age { get; set; }
    }
}