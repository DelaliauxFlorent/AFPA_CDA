using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace _1_BaseToModel.Models.DbModels
{
    public partial class personneContext : DbContext
    {
        public personneContext()
        {
        }

        public personneContext(DbContextOptions<personneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Personne> Personnes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Name=Default");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personne>(entity =>
            {
                entity.ToTable("personnes");

                entity.HasIndex(e => e.Prenom, "prenom_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Adresse)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("adresse");

                entity.Property(e => e.CodePostal)
                    .HasColumnType("int(11)")
                    .HasColumnName("codePostal");

                entity.Property(e => e.Nom)
                    .HasMaxLength(45)
                    .HasColumnName("nom");

                entity.Property(e => e.Prenom)
                    .HasMaxLength(20)
                    .HasColumnName("prenom");

                entity.Property(e => e.Ville)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("ville");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
