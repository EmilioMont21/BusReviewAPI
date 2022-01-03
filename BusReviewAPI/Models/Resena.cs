namespace BusReviewAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Resena")]
    public partial class Resena
    {
        public int ResenaId { get; set; }

        [StringLength(20)]
        public string Usuario { get; set; }

        [StringLength(20)]
        public string Placa { get; set; }

        public int? Calificacion { get; set; }

        [Column(TypeName = "text")]
        public string Nota { get; set; }
    }
}
