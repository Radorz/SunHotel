using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataBase.Models
{
    public partial class ba4cpg3zvekknrm1lhokContext : IdentityDbContext
    {
        public ba4cpg3zvekknrm1lhokContext()
        {
        }

        public ba4cpg3zvekknrm1lhokContext(DbContextOptions<ba4cpg3zvekknrm1lhokContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Edificio> Edificio { get; set; }
        public virtual DbSet<Habitacion> Habitacion { get; set; }
        public virtual DbSet<ImgHabitaciones> ImgHabitaciones { get; set; }
        public virtual DbSet<Pagos> Pagos { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<TipoHabitaciones> TipoHabitaciones { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=ba4cpg3zvekknrm1lhok-mysql.services.clever-cloud.com;port=3306;uid=upey5oip59x19afn;pwd=yGhQX4KRAPvZpGSkspwl;database=ba4cpg3zvekknrm1lhok;convertzerodatetime=True", x => x.ServerVersion("8.0.15-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Edificio>(entity =>
            {
                entity.HasKey(e => e.IdEdificio)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdEdificio)
                    .HasColumnName("id _Edificio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NumeroEdificio)
                    .HasColumnName("numero_Edificio")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Habitacion>(entity =>
            {
                entity.HasKey(e => e.IdHabitacion)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdHabitacion)
                    .HasColumnName("id_Habitacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEdificio)
                    .HasColumnName("id_edificio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTipoHabitacion)
                    .HasColumnName("id_tipo_habitacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NoHabitacion)
                    .HasColumnName("no_habitacion")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<ImgHabitaciones>(entity =>
            {
                entity.HasKey(e => e.IdImgHabitaciones)
                    .HasName("PRIMARY");

                entity.ToTable("img_habitaciones");

                entity.Property(e => e.IdImgHabitaciones)
                    .HasColumnName("id_img_habitaciones")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTipoHabitacion)
                    .HasColumnName("id_tipo_habitacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Pagos>(entity =>
            {
                entity.HasKey(e => e.IdPago)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdPago)
                    .HasColumnName("id_pago")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cantidadpagar)
                    .HasColumnName("cantidadpagar")
                    .HasColumnType("decimal(19,2)");

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Titular)
                    .HasColumnName("titular")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.IdReserva)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdReserva)
                    .HasColumnName("id_Reserva")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Adultos).HasColumnType("int(11)");

                entity.Property(e => e.Apellido)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Cedula)
                    .HasColumnType("varchar(16)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FechaLlegada)
                    .HasColumnName("Fecha_Llegada")
                    .HasColumnType("date");

                entity.Property(e => e.FechaPago)
                    .HasColumnName("Fecha_pago")
                    .HasColumnType("date");

                entity.Property(e => e.FechaSalida)
                    .HasColumnName("Fecha_Salida")
                    .HasColumnType("date");

                entity.Property(e => e.IdHabitacion)
                    .HasColumnName("Id_Habitacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPago)
                    .HasColumnName("id_pago")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTipoHabitacion)
                    .HasColumnName("Id_tipo_Habitacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Niños).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Telefono)
                    .HasColumnType("varchar(11)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<TipoHabitaciones>(entity =>
            {
                entity.HasKey(e => e.IdTipoHabitacion)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_habitaciones");

                entity.Property(e => e.IdTipoHabitacion)
                    .HasColumnName("id_tipo_habitacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CantCamas)
                    .HasColumnName("cant_camas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MaxHuespedes)
                    .HasColumnName("max_huespedes")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PrecioNoche)
                    .HasColumnName("precio_noche")
                    .HasColumnType("decimal(9,2)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("user");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_User")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
