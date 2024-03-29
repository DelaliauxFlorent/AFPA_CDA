﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using _2_GestionStocks.Models.DbModels;

#nullable disable

namespace _2_GestionStocks.Data
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Typesproduit> Typesproduits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;user=root;database=GestionStocks;port=3306;ssl mode=none");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(e => e.IdArticle)
                    .HasName("PRIMARY");

                entity.ToTable("articles");

                entity.HasIndex(e => e.IdCategorie, "FK_Articles_Categories");

                entity.Property(e => e.IdArticle).HasColumnType("int(11)");

                entity.Property(e => e.IdCategorie).HasColumnType("int(11)");

                entity.Property(e => e.LibelleArticle)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.QuantiteStockee).HasColumnType("int(11)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.IdCategorie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Articles_Categories");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategorie)
                    .HasName("PRIMARY");

                entity.ToTable("categories");

                entity.HasIndex(e => e.IdTypeProduit, "FK_Categories_TypesProduits");

                entity.Property(e => e.IdCategorie).HasColumnType("int(11)");

                entity.Property(e => e.IdTypeProduit).HasColumnType("int(11)");

                entity.Property(e => e.LibelleCategorie)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.TypeProduit)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.IdTypeProduit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Categories_TypesProduits");
            });

            modelBuilder.Entity<Typesproduit>(entity =>
            {
                entity.HasKey(e => e.IdTypeProduit)
                    .HasName("PRIMARY");

                entity.ToTable("typesproduits");

                entity.Property(e => e.IdTypeProduit).HasColumnType("int(11)");

                entity.Property(e => e.LibelleTypeProduit)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
