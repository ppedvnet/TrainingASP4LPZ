namespace Snacklager.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Snack")]
    public partial class Snack : Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Snack()
        {
            Lagerhaltung = new HashSet<Lagerhaltung>();
            Zutaten = new HashSet<Zutaten>();
        }

        public int SnackArtId { get; set; }

        [Required]
        public string Name { get; set; }

        public double? GewichtProEinheit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lagerhaltung> Lagerhaltung { get; set; }

        public virtual SnackArt SnackArt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zutaten> Zutaten { get; set; }
    }
}
