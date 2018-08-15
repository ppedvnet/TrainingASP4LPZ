using System.ComponentModel.DataAnnotations;
using Snacklager.Logic.Enums;

namespace Snacklager.Web.Models
{
    public class SnackCreateVm
    {
        [Display(Name = "SnackArt", ResourceType = typeof(App_LocalResources.MainResx))]
        [Required]
        public SnackArtEnum SnackArt { get; set; } = SnackArtEnum.Apfel;

        [Display(Name = "SnackName", ResourceType = typeof(App_LocalResources.MainResx))]
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Display(Name = "Gewicht", ResourceType = typeof(App_LocalResources.MainResx))]
        public decimal GewichtProEinheit { get; set; }
    }
}