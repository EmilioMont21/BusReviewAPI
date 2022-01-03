using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BusReviewAPI.Models
{
    public partial class BusReview : DbContext
    {
        public BusReview()
            : base("name=BusReview")
        {
        }

        public virtual DbSet<Bus> Bus { get; set; }
        public virtual DbSet<Parada> Parada { get; set; }
        public virtual DbSet<Reporte> Reporte { get; set; }
        public virtual DbSet<Resena> Resena { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bus>()
                .Property(e => e.Placa)
                .IsUnicode(false);

            modelBuilder.Entity<Bus>()
                .Property(e => e.Nombres_Chofer)
                .IsUnicode(false);

            modelBuilder.Entity<Bus>()
                .Property(e => e.Nombres_Asistente)
                .IsUnicode(false);

            modelBuilder.Entity<Bus>()
                .Property(e => e.Cedula_Chofer)
                .IsUnicode(false);

            modelBuilder.Entity<Bus>()
                .Property(e => e.Cedula_Asistente)
                .IsUnicode(false);

            modelBuilder.Entity<Bus>()
                .Property(e => e.Marca)
                .IsUnicode(false);

            modelBuilder.Entity<Bus>()
                .Property(e => e.Sector)
                .IsUnicode(false);

            modelBuilder.Entity<Bus>()
                .Property(e => e.Cooperativa)
                .IsUnicode(false);

            modelBuilder.Entity<Parada>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Parada>()
                .Property(e => e.Sector)
                .IsUnicode(false);

            modelBuilder.Entity<Parada>()
                .Property(e => e.Callep)
                .IsUnicode(false);

            modelBuilder.Entity<Parada>()
                .Property(e => e.Calles)
                .IsUnicode(false);

            modelBuilder.Entity<Parada>()
                .Property(e => e.Costo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Reporte>()
                .Property(e => e.Usuario)
                .IsUnicode(false);

            modelBuilder.Entity<Reporte>()
                .Property(e => e.Placa)
                .IsUnicode(false);

            modelBuilder.Entity<Reporte>()
                .Property(e => e.Nota)
                .IsUnicode(false);

            modelBuilder.Entity<Resena>()
                .Property(e => e.Usuario)
                .IsUnicode(false);

            modelBuilder.Entity<Resena>()
                .Property(e => e.Placa)
                .IsUnicode(false);

            modelBuilder.Entity<Resena>()
                .Property(e => e.Nota)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Contrasena)
                .IsUnicode(false);
        }
    }
}
