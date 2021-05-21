using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace AgendaMatic.Data
{
    public partial class AgendaMaticContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public AgendaMaticContext()
        {
        }

        public AgendaMaticContext(DbContextOptions<AgendaMaticContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<AmBloque> AmBloques { get; set; }
        public virtual DbSet<AmCitum> AmCita { get; set; }
        public virtual DbSet<AmLog> AmLogs { get; set; }
        public virtual DbSet<AmParticipante> AmParticipantes { get; set; }
        public virtual DbSet<AmUsuario> AmUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<AmBloque>(entity =>
            {
                entity.ToTable("AM_BLOQUE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bloque).HasColumnName("BLOQUE");

                entity.Property(e => e.Estado).HasColumnName("ESTADO");

                entity.Property(e => e.Hora).HasColumnName("HORA");

                entity.Property(e => e.Limite)
                    .IsUnicode(false)
                    .HasColumnName("LIMITE");
            });

            modelBuilder.Entity<AmCitum>(entity =>
            {
                entity.ToTable("AM_CITA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Estado).HasColumnName("ESTADO");

                entity.Property(e => e.Fecha).HasColumnName("FECHA");

                entity.Property(e => e.IdBloque).HasColumnName("ID_BLOQUE");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Nombre)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.HasOne(d => d.IdBloqueNavigation)
                    .WithMany(p => p.AmCita)
                    .HasForeignKey(d => d.IdBloque)
                    .HasConstraintName("FK_AM_CITA_AM_BLOQUE");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.AmCita)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_AM_CITA_AM_USUARIO");
            });

            modelBuilder.Entity<AmLog>(entity =>
            {
                entity.ToTable("AM_LOG");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fecha).HasColumnName("FECHA");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Mensaje)
                    .IsUnicode(false)
                    .HasColumnName("MENSAJE");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.AmLogs)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_AM_LOG_AM_USUARIO");
            });

            modelBuilder.Entity<AmUsuario>(entity =>
            {
                entity.ToTable("AM_USUARIO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Apellido)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDO");

                entity.Property(e => e.Contrasena)
                    .IsUnicode(false)
                    .HasColumnName("CONTRASENA");

                entity.Property(e => e.Correo)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.Estado).HasColumnName("ESTADO");

                entity.Property(e => e.Nombre)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
