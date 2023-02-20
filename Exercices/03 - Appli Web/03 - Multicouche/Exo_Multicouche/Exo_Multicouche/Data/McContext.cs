using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Exo_Multicouche.Data.Models;

#nullable disable

namespace Exo_Multicouche.Data
{
    public partial class McContext : DbContext
    {
        public McContext()
        {
        }

        public McContext(DbContextOptions<McContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CodesValide> CodesValides { get; set; }
        public virtual DbSet<Synthese> Syntheses { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Name=Default");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CodesValide>(entity =>
            {
                entity.HasKey(e => e.IdCodeValide)
                    .HasName("PRIMARY");

                entity.ToTable("codesValides");

                entity.HasIndex(e => e.CodeValide, "codeValide")
                    .IsUnique();

                entity.Property(e => e.IdCodeValide)
                    .HasColumnType("int(11)")
                    .HasColumnName("idCodeValide");

                entity.Property(e => e.CodeValide)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("codeValide");

                entity.Property(e => e.Utilise).HasColumnName("utilise");
            });

            modelBuilder.Entity<Synthese>(entity =>
            {
                entity.HasKey(e => e.IdSynthese)
                    .HasName("PRIMARY");

                entity.ToTable("syntheses");

                entity.Property(e => e.IdSynthese)
                    .HasColumnType("int(11)")
                    .HasColumnName("idSynthese");

                entity.Property(e => e.Nombre)
                    .HasColumnType("int(11)")
                    .HasColumnName("nombre");

                entity.Property(e => e.Reponse)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("reponse");
            });

            modelBuilder.Entity<Vote>(entity =>
            {
                entity.HasKey(e => e.IdVote)
                    .HasName("PRIMARY");

                entity.ToTable("votes");

                entity.HasIndex(e => e.IdCodeValide, "FK_Votes_CodesValide");

                entity.Property(e => e.IdVote)
                    .HasColumnType("int(11)")
                    .HasColumnName("idVote");

                entity.Property(e => e.ChoixVote)
                    .HasMaxLength(50)
                    .HasColumnName("choixVote");

                entity.Property(e => e.IdCodeValide)
                    .HasColumnType("int(11)")
                    .HasColumnName("idCodeValide");

                entity.HasOne(d => d.CodesValide)
                    .WithMany(p => p.Votes)
                    .HasForeignKey(d => d.IdCodeValide)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Votes_CodesValide");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
