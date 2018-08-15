namespace Snacklager.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Zutaten")]
    public partial class Zutaten : Entity
    {
        public int SnackId { get; set; }

        [Required]
        public string Name { get; set; }

        public bool? IstVegan { get; set; }

        public bool? IstVegetarisch { get; set; }

        public bool? IstNuss { get; set; }

        public virtual Snack Snack { get; set; }
    }
}
