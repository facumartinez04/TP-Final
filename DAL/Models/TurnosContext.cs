using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public partial class TurnosContext : DbContext
    {
        public TurnosContext()
            : base("name=TurnosDB")
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Horas> Horas { get; set; }
        public virtual DbSet<LogIn> LogIn { get; set; }
        public virtual DbSet<Peluquero> Peluquero { get; set; }
        public virtual DbSet<Turnos> Turnos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property(e => e.NOMBRE_APELLIDO)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.TELEFONO)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.contraseña)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<LogIn>()
                .Property(e => e.Usuario)
                .IsUnicode(false);

            modelBuilder.Entity<LogIn>()
                .Property(e => e.Contraseña)
                .IsUnicode(false);

            modelBuilder.Entity<Peluquero>()
                .Property(e => e.NOMBRE_APELLIDO)
                .IsUnicode(false);

            modelBuilder.Entity<Peluquero>()
                .Property(e => e.TELEFONO)
                .IsUnicode(false);

            modelBuilder.Entity<Turnos>()
                .Property(e => e.ESTADO)
                .IsUnicode(false);

            modelBuilder.Entity<Turnos>()
                .Property(e => e.SERVICIO)
                .IsUnicode(false);

          

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.contraseña)
                .IsUnicode(false);
        }
    }
}
