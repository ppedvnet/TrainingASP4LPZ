using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snacklager.Data
{
    public abstract class Entity
    {
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Added { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Modified { get; set; }

        [StringLength(200)]
        public string ModifiedBy { get; set; }
    }
}
