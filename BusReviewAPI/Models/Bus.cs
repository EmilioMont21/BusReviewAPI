namespace BusReviewAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bus")]
    public partial class Bus
    {
        public int BusId { get; set; }

        [Required]
        [StringLength(10)]
        public string Placa { get; set; }

        [Required]
        [StringLength(40)]
        public string Nombres_Chofer { get; set; }

        [Required]
        [StringLength(40)]
        public string Nombres_Asistente { get; set; }

        [Required]
        [StringLength(60)]
        public string Cedula_Chofer { get; set; }

        [Required]
        [StringLength(60)]
        public string Cedula_Asistente { get; set; }

        [Required]
        [StringLength(20)]
        public string Marca { get; set; }

        [Required]
        [StringLength(40)]
        public string Sector { get; set; }

        [Required]
        [StringLength(40)]
        public string Cooperativa { get; set; }

        public bool Wifi { get; set; }

        public bool TV { get; set; }

        public bool Bano { get; set; }

        public bool Asientos_discapacitados { get; set; }
    }
}
