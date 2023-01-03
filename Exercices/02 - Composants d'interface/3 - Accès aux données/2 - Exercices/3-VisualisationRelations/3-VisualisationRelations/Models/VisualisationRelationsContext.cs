using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace _3_VisualisationRelations.Models
{
    public partial class VisualisationRelationsContext : DbContext
    {
        public VisualisationRelationsContext()
        {
        }

        public VisualisationRelationsContext(DbContextOptions<VisualisationRelationsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Command> Commands { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Name=Default");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.IdCity)
                    .HasName("PRIMARY");

                entity.ToTable("cities");

                entity.HasIndex(e => e.IdCountry, "FK_Cities_Countries");

                entity.Property(e => e.IdCity).HasColumnType("int(11)");

                entity.Property(e => e.IdCountry).HasColumnType("int(11)");

                entity.Property(e => e.NameCity)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.IdCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cities_Countries");
            });

            modelBuilder.Entity<Command>(entity =>
            {
                entity.HasKey(e => e.IdCommand)
                    .HasName("PRIMARY");

                entity.ToTable("commands");

                entity.Property(e => e.IdCommand).HasColumnType("int(11)");

                entity.Property(e => e.DeliveryAddressCommand)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Content>(entity =>
            {
                entity.HasKey(e => e.IdContent)
                    .HasName("PRIMARY");

                entity.ToTable("contents");

                entity.HasIndex(e => e.IdCommand, "FK_Contents_Commands");

                entity.HasIndex(e => e.IdProduct, "FK_Contents_Products");

                entity.Property(e => e.IdContent).HasColumnType("int(11)");

                entity.Property(e => e.IdCommand).HasColumnType("int(11)");

                entity.Property(e => e.IdProduct).HasColumnType("int(11)");

                entity.Property(e => e.QuantityContent).HasColumnType("int(11)");

                entity.HasOne(d => d.Command)
                    .WithMany(p => p.Contents)
                    .HasForeignKey(d => d.IdCommand)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contents_Commands");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Contents)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contents_Products");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.IdCountry)
                    .HasName("PRIMARY");

                entity.ToTable("countries");

                entity.Property(e => e.IdCountry).HasColumnType("int(11)");

                entity.Property(e => e.NameCountry)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.IdPerson)
                    .HasName("PRIMARY");

                entity.ToTable("persons");

                entity.Property(e => e.IdPerson).HasColumnType("int(11)");

                entity.Property(e => e.NamePerson)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SurnamePerson)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PRIMARY");

                entity.ToTable("products");

                entity.Property(e => e.IdProduct).HasColumnType("int(11)");

                entity.Property(e => e.NameProduct)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PriceProduct).HasColumnType("int(11)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
