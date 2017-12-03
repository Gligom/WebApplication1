using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class PreAnalizeContext : DbContext
    {
        public virtual DbSet<Analize> Analize { get; set; }
        public virtual DbSet<AnalizeEvaluari> AnalizeEvaluari { get; set; }
        public virtual DbSet<EvaluariPacienti> EvaluariPacienti { get; set; }
        public virtual DbSet<Laboratoare> Laboratoare { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<ProfileAnalize> ProfileAnalize { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=.;Database=PreAnalize;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Analize>(entity =>
            {
                entity.HasKey(e => e.AnalizaId);

                entity.ToTable("analize");

                entity.Property(e => e.AnalizaId).HasColumnName("analizaID");

                entity.Property(e => e.LaboratorId).HasColumnName("laboratorID");

                entity.Property(e => e.NumeAnaliza)
                    .IsRequired()
                    .HasColumnName("numeAnaliza")
                    .HasMaxLength(200);

                entity.HasOne(d => d.Laborator)
                    .WithMany(p => p.Analize)
                    .HasForeignKey(d => d.LaboratorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_analize_laboratoare");
            });

            modelBuilder.Entity<AnalizeEvaluari>(entity =>
            {
                entity.ToTable("analize_evaluari");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AnalizaId).HasColumnName("analizaID");

                entity.Property(e => e.EvaluareId).HasColumnName("evaluareID");

                entity.HasOne(d => d.Analiza)
                    .WithMany(p => p.AnalizeEvaluari)
                    .HasForeignKey(d => d.AnalizaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_analize_evaluari_analize");

                entity.HasOne(d => d.Evaluare)
                    .WithMany(p => p.AnalizeEvaluari)
                    .HasForeignKey(d => d.EvaluareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_analize_evaluari_evaluariPacienti");
            });

            modelBuilder.Entity<EvaluariPacienti>(entity =>
            {
                entity.HasKey(e => e.EvaluareId);

                entity.ToTable("evaluariPacienti");

                entity.Property(e => e.EvaluareId).HasColumnName("evaluareId");

                entity.Property(e => e.DataEvaluare).HasColumnName("dataEvaluare");

                entity.Property(e => e.DataNasterii)
                    .HasColumnName("dataNasterii")
                    .HasColumnType("date");

                entity.Property(e => e.NumePacient)
                    .IsRequired()
                    .HasColumnName("numePacient")
                    .HasMaxLength(200);

                entity.Property(e => e.Observatii).HasColumnName("observatii");

                entity.Property(e => e.PrenumePacient)
                    .IsRequired()
                    .HasColumnName("prenumePacient")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Laboratoare>(entity =>
            {
                entity.HasKey(e => e.LaboratorId);

                entity.ToTable("laboratoare");

                entity.Property(e => e.LaboratorId).HasColumnName("laboratorID");

                entity.Property(e => e.NumeLaborator)
                    .HasColumnName("numeLaborator")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasKey(e => e.ProfilId);

                entity.ToTable("profile");

                entity.Property(e => e.ProfilId).HasColumnName("profilID");

                entity.Property(e => e.ProfilNume)
                    .IsRequired()
                    .HasColumnName("profilNume")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<ProfileAnalize>(entity =>
            {
                entity.HasKey(e => new { e.ProfilId, e.AnalizaId });

                entity.ToTable("profile_analize");

                entity.Property(e => e.ProfilId).HasColumnName("profilID");

                entity.Property(e => e.AnalizaId).HasColumnName("analizaID");

                entity.HasOne(d => d.Analiza)
                    .WithMany(p => p.ProfileAnalize)
                    .HasForeignKey(d => d.AnalizaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_profile_analize_analize");

                entity.HasOne(d => d.Profil)
                    .WithMany(p => p.ProfileAnalize)
                    .HasForeignKey(d => d.ProfilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_profile_analize_profile");
            });
        }
    }
}
