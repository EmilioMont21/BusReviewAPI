namespace BusReviewAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(60)]
        public string Correo { get; set; }

        [Required]
        [StringLength(40)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(40)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(60)]
        public string Contrasena { get; set; }

        public DateTime? Fecha_Nacimiento { get; set; }

        public bool? Administrador { get; set; }
    }
}
