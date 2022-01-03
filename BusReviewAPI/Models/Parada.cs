namespace BusReviewAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Parada")]
    public partial class Parada
    {
        public int ParadaId { get; set; }

        [Required]
        [StringLength(40)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(40)]
        public string Sector { get; set; }

        [Required]
        [StringLength(40)]
        public string Callep { get; set; }

        [Required]
        [StringLength(40)]
        public string Calles { get; set; }

        [Column(TypeName = "money")]
        public decimal? Costo { get; set; }
    }
}
