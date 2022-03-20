using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAcces
{
    public partial class JuegoMillonarioContext : DbContext
    {
        public JuegoMillonarioContext()
        {
        }

        public JuegoMillonarioContext(DbContextOptions<JuegoMillonarioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Juego> Juegos { get; set; }
        public virtual DbSet<Nivel> Nivels { get; set; }
        public virtual DbSet<Pregunta> Preguntas { get; set; }
        public virtual DbSet<PreguntasRespuesta> PreguntasRespuestas { get; set; }
        public virtual DbSet<Respuesta> Respuestas { get; set; }
        public virtual DbSet<RondaJuego> RondaJuegos { get; set; }
        public virtual DbSet<TipoFinalizacion> TipoFinalizacions { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-8NALKM2; Database=JuegoMillonario; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Juego>(entity =>
            {
                entity.HasKey(e => e.IdJuego);

                entity.Property(e => e.FechaCreacion).HasColumnType("smalldatetime");

                entity.Property(e => e.FechaFinalizacion).HasColumnType("smalldatetime");

                entity.HasOne(d => d.IdNivelAlcanzadoNavigation)
                    .WithMany(p => p.Juegos)
                    .HasForeignKey(d => d.IdNivelAlcanzado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Juegos_Nivel");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Juegos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Juegos_Usuarios");
            });

            modelBuilder.Entity<Nivel>(entity =>
            {
                entity.HasKey(e => e.IdNivel);

                entity.ToTable("Nivel");

                entity.Property(e => e.Descipcion)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Pregunta>(entity =>
            {
                entity.HasKey(e => e.IdPregunta);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdNivelNavigation)
                    .WithMany(p => p.Pregunta)
                    .HasForeignKey(d => d.IdNivel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Preguntas_Niveles");
            });

            modelBuilder.Entity<PreguntasRespuesta>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.IdPreguntaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPregunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PreguntasRespuestas_Preguntas");

                entity.HasOne(d => d.IdRespuestaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdRespuesta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PreguntasRespuestas_Respuestas");
            });

            modelBuilder.Entity<Respuesta>(entity =>
            {
                entity.HasKey(e => e.IdRespuesta);

                entity.Property(e => e.Descipcion)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<RondaJuego>(entity =>
            {
                entity.HasKey(e => e.IdRondaJuego);

                entity.ToTable("RondaJuego");

                entity.Property(e => e.FechaCreacion).HasColumnType("smalldatetime");

                entity.HasOne(d => d.IdJuegoNavigation)
                    .WithMany(p => p.RondaJuegos)
                    .HasForeignKey(d => d.IdJuego)
                    .HasConstraintName("FK_RondaJuego_Juego");

                entity.HasOne(d => d.IdPreguntaNavigation)
                    .WithMany(p => p.RondaJuegos)
                    .HasForeignKey(d => d.IdPregunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RondaJuego_Preguntas");
            });

            modelBuilder.Entity<TipoFinalizacion>(entity =>
            {
                entity.HasKey(e => e.IdTipoFinalizacion);

                entity.ToTable("TipoFinalizacion");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.FechaRegistro).HasColumnType("smalldatetime");

                entity.Property(e => e.Nick)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
