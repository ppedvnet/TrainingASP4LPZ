using Snacklager.Logic.Enums;
using System.ComponentModel.DataAnnotations;

namespace Snacklager.Web.Models
{
    public class SnackDisplayVm
    {
        [Display(Name = "Snack Art")]
        public SnackArtEnum SnackArt { get; set; }

        [Display(Name = "Snack Name")]
        public string Name { get; set; }

        [Display(Name = "Gewicht pro Einheit")]
        public double? GewichtProEinheit { get; set; }
    }
}