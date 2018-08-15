using System.ComponentModel.DataAnnotations;
using Snacklager.Logic.Enums;

namespace Snacklager.Web.Models
{
    public class SnackCreateVm
    {
        [Display(Name = "Snack Art")]
        [Required]
        public SnackArtEnum SnackArt { get; set; } = SnackArtEnum.Apfel;

        [Display(Name = "Snack Name")]
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Display(Name = "Gewicht pro Einheit")]
        public decimal GewichtProEinheit { get; set; }
    }
}