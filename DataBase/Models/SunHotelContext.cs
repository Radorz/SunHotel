using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataBase.Models
{
    public partial class SunHotelContext : IdentityDbContext<IdentityUser>
    {
        public SunHotelContext()
        {
        }

        public SunHotelContext(DbContextOptions<SunHotelContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SunHotel;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.Entity<Pagos>(entity =>
            {
                entity.Property(e => e.Cantidadpagar).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<TipoHabitaciones>(entity =>
            {
                entity.Property(e => e.PrecioNoche).HasColumnType("decimal(18,2)");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<Pagos> Pagos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Edificio> Edificios { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<ImgHabitaciones> ImgHabitaciones { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<TipoHabitaciones> TipoHabitaciones { get; set; }
    }
}
