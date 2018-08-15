namespace Snacklager.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lager")]
    public partial class Lager : Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lager()
        {
            Lagerhaltung = new HashSet<Lagerhaltung>();
        }

        [Required]
        public string Bezeichnung { get; set; }

        public int? Kapazitaet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lagerhaltung> Lagerhaltung { get; set; }
    }
}
