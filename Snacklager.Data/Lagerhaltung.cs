namespace Snacklager.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lagerhaltung")]
    public partial class Lagerhaltung : Entity
    {
        public int LagerId { get; set; }

        public int SnackId { get; set; }

        public int? Einheiten { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Haltbarkeit { get; set; }

        public virtual Lager Lager { get; set; }

        public virtual Snack Snack { get; set; }
    }
}
