namespace BusReviewAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reporte")]
    public partial class Reporte
    {
        public int ReporteId { get; set; }

        [StringLength(20)]
        public string Usuario { get; set; }

        [StringLength(20)]
        public string Placa { get; set; }

        public bool Mala_Conduccion { get; set; }

        public bool Acoso { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Nota { get; set; }
    }
}
