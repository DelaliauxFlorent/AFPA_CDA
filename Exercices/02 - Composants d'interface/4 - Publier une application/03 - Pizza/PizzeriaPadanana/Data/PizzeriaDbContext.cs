using System;
using Microsoft.EntityFrameworkCore;
using PizzeriaPadanana.Data.POCOs;

#nullable disable

namespace PizzeriaPadanana.Data
{
    public partial class PizzeriaDbContext : DbContext
    {
        public PizzeriaDbContext()
        {
        }

        public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accompagnement> Accompagnements { get; set; }
        public virtual DbSet<Adress> Adresses { get; set; }
        public virtual DbSet<Commande> Commandes { get; set; }
        public virtual DbSet<Composition> Compositions { get; set; }
        public virtual DbSet<Compte> Comptes { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Itemsmenu> Itemsmenus { get; set; }
        public virtual DbSet<Lignescommande> Lignescommandes { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Seuilfidelite> Seuilfidelites { get; set; }
        public virtual DbSet<Statut> Statuts { get; set; }
        public virtual DbSet<Taillepizza> Taillepizzas { get; set; }
        public virtual DbSet<Typeaccompagnement> Typeaccompagnements { get; set; }
        public virtual DbSet<Typeingredient> Typeingredients { get; set; }
        public virtual DbSet<Typepizza> Typepizzas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=STA6400874;user=1401;password=1401;database=PizzaPadananas;port=3306;ssl mode=none");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accompagnement>(entity =>
            {
                entity.HasKey(e => e.IdAccompagnement)
                    .HasName("PRIMARY");

                entity.ToTable("accompagnements");

                entity.HasIndex(e => e.IdTypeAccompagnement, "FK_Accompagnements_TypeAccompagnements");

                entity.Property(e => e.IdAccompagnement)
                    .HasColumnType("int(11)")
                    .HasColumnName("idAccompagnement");

                entity.Property(e => e.Actif)
                    .HasColumnName("actif")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IdTypeAccompagnement)
                    .HasColumnType("int(11)")
                    .HasColumnName("idTypeAccompagnement");

                entity.Property(e => e.ImageAccompagnement)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("imageAccompagnement");

                entity.Property(e => e.MesureAccompagnement)
                    .HasColumnType("decimal(4,2)")
                    .HasColumnName("mesureAccompagnement");

                entity.Property(e => e.NomAccompagnement)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nomAccompagnement");

                entity.Property(e => e.PrixAccompagnement)
                    .HasColumnType("decimal(4,2)")
                    .HasColumnName("prixAccompagnement");

                entity.HasOne(d => d.IdTypeAccompagnementNavigation)
                    .WithMany(p => p.Accompagnements)
                    .HasForeignKey(d => d.IdTypeAccompagnement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accompagnements_TypeAccompagnements");
            });

            modelBuilder.Entity<Adress>(entity =>
            {
                entity.HasKey(e => e.IdAdresse)
                    .HasName("PRIMARY");

                entity.ToTable("adresses");

                entity.HasIndex(e => e.IdCompte, "FK_Adresses_Comptes");

                entity.Property(e => e.IdAdresse)
                    .HasColumnType("int(11)")
                    .HasColumnName("idAdresse");

                entity.Property(e => e.Adresse)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CdPost)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("cdPost");

                entity.Property(e => e.ComplementAdresse)
                    .HasMaxLength(100)
                    .HasColumnName("complementAdresse");

                entity.Property(e => e.IdCompte)
                    .HasColumnType("int(11)")
                    .HasColumnName("idCompte");

                entity.Property(e => e.Ville)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdCompteNavigation)
                    .WithMany(p => p.Adresses)
                    .HasForeignKey(d => d.IdCompte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Adresses_Comptes");
            });

            modelBuilder.Entity<Commande>(entity =>
            {
                entity.HasKey(e => e.IdCommande)
                    .HasName("PRIMARY");

                entity.ToTable("commandes");

                entity.HasIndex(e => e.IdCompte, "FK_Commandes_Comptes");

                entity.HasIndex(e => e.IdSeuilFidelite, "FK_Commandes_SeuilFidelites");

                entity.HasIndex(e => e.IdStatut, "FK_Commandes_Statuts");

                entity.Property(e => e.IdCommande)
                    .HasColumnType("int(11)")
                    .HasColumnName("idCommande");

                entity.Property(e => e.DateCommande).HasColumnName("dateCommande");

                entity.Property(e => e.IdCompte)
                    .HasColumnType("int(11)")
                    .HasColumnName("idCompte");

                entity.Property(e => e.IdSeuilFidelite)
                    .HasColumnType("int(11)")
                    .HasColumnName("idSeuilFidelite")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IdStatut)
                    .HasColumnType("int(11)")
                    .HasColumnName("idStatut")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.NumCommande)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("numCommande");

                entity.Property(e => e.PayementCommande).HasColumnName("payementCommande");

                entity.HasOne(d => d.IdCompteNavigation)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.IdCompte)
                    .HasConstraintName("FK_Commandes_Comptes");

                entity.HasOne(d => d.IdSeuilFideliteNavigation)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.IdSeuilFidelite)
                    .HasConstraintName("FK_Commandes_SeuilFidelites");

                entity.HasOne(d => d.IdStatutNavigation)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.IdStatut)
                    .HasConstraintName("FK_Commandes_Statuts");
            });

            modelBuilder.Entity<Composition>(entity =>
            {
                entity.HasKey(e => e.IdCompositions)
                    .HasName("PRIMARY");

                entity.ToTable("compositions");

                entity.HasIndex(e => e.IdIngredient, "FK_Compositions_Ingredients");

                entity.HasIndex(e => e.IdTypePizza, "FK_Compositions_TypePizzas");

                entity.Property(e => e.IdCompositions)
                    .HasColumnType("int(11)")
                    .HasColumnName("idCompositions");

                entity.Property(e => e.IdIngredient)
                    .HasColumnType("int(11)")
                    .HasColumnName("idIngredient");

                entity.Property(e => e.IdTypePizza)
                    .HasColumnType("int(11)")
                    .HasColumnName("idTypePizza");

                entity.HasOne(d => d.IdIngredientNavigation)
                    .WithMany(p => p.Compositions)
                    .HasForeignKey(d => d.IdIngredient)
                    .HasConstraintName("FK_Compositions_Ingredients");

                entity.HasOne(d => d.IdTypePizzaNavigation)
                    .WithMany(p => p.Compositions)
                    .HasForeignKey(d => d.IdTypePizza)
                    .HasConstraintName("FK_Compositions_TypePizzas");
            });

            modelBuilder.Entity<Compte>(entity =>
            {
                entity.HasKey(e => e.IdCompte)
                    .HasName("PRIMARY");

                entity.ToTable("comptes");

                entity.HasIndex(e => e.IdRole, "FK_Comptes_Roles");

                entity.Property(e => e.IdCompte)
                    .HasColumnType("int(11)")
                    .HasColumnName("idCompte");

                entity.Property(e => e.IdRole)
                    .HasColumnType("int(11)")
                    .HasColumnName("idRole");

                entity.Property(e => e.Identifiant)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("identifiant");

                entity.Property(e => e.Mdp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("mdp");

                entity.Property(e => e.NiveauFidelite)
                    .HasColumnType("int(11)")
                    .HasColumnName("niveauFidelite")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nom");

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("prenom");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Comptes)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comptes_Roles");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => e.IdIngredient)
                    .HasName("PRIMARY");

                entity.ToTable("ingredients");

                entity.Property(e => e.IdIngredient)
                    .HasColumnType("int(11)")
                    .HasColumnName("idIngredient");

                entity.Property(e => e.Actif)
                    .HasColumnName("actif")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IdTypeIngredient)
                    .HasColumnType("int(11)")
                    .HasColumnName("idTypeIngredient");

                entity.Property(e => e.ImageIngredient)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("imageIngredient");

                entity.Property(e => e.NomIngredient)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nomIngredient");

                entity.HasIndex(e => e.IdTypeIngredient, "FK_Ingredients_TypeIngredients");

                entity.HasOne(d => d.IdTypeIngredientNavigation)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.IdTypeIngredient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingredients_TypeIngredients");
            });

            modelBuilder.Entity<Itemsmenu>(entity =>
            {
                entity.HasKey(e => e.IdItemsMenus)
                    .HasName("PRIMARY");

                entity.ToTable("itemsmenus");

                entity.HasIndex(e => e.IdAccompagnement, "FK_ItemsMenus_Accompagnements");

                entity.HasIndex(e => e.IdMenu, "FK_ItemsMenus_Menus");

                entity.HasIndex(e => e.IdTypePizza, "FK_ItemsMenus_TypePizzas");

                entity.Property(e => e.IdItemsMenus)
                    .HasColumnType("int(11)")
                    .HasColumnName("idItemsMenus");

                entity.Property(e => e.IdAccompagnement)
                    .HasColumnType("int(11)")
                    .HasColumnName("idAccompagnement");

                entity.Property(e => e.IdMenu)
                    .HasColumnType("int(11)")
                    .HasColumnName("idMenu");

                entity.Property(e => e.IdTypePizza)
                    .HasColumnType("int(11)")
                    .HasColumnName("idTypePizza");

                entity.Property(e => e.QteItem)
                    .HasColumnType("int(11)")
                    .HasColumnName("qteItem");

                entity.HasOne(d => d.IdAccompagnementNavigation)
                    .WithMany(p => p.Itemsmenus)
                    .HasForeignKey(d => d.IdAccompagnement)
                    .HasConstraintName("FK_ItemsMenus_Accompagnements");

                entity.HasOne(d => d.IdMenuNavigation)
                    .WithMany(p => p.Itemsmenus)
                    .HasForeignKey(d => d.IdMenu)
                    .HasConstraintName("FK_ItemsMenus_Menus");

                entity.HasOne(d => d.IdTypePizzaNavigation)
                    .WithMany(p => p.Itemsmenus)
                    .HasForeignKey(d => d.IdTypePizza)
                    .HasConstraintName("FK_ItemsMenus_TypePizzas");
            });

            modelBuilder.Entity<Lignescommande>(entity =>
            {
                entity.HasKey(e => e.IdLignesCommandes)
                    .HasName("PRIMARY");

                entity.ToTable("lignescommandes");

                entity.HasIndex(e => e.IdAccompagnement, "FK_LignesCommandes_Accompagnements");

                entity.HasIndex(e => e.IdCommande, "FK_LignesCommandes_Commandes");

                entity.HasIndex(e => e.IdMenu, "FK_LignesCommandes_Menus");

                entity.HasIndex(e => e.IdPizza, "FK_LignesCommandes_Pizzas");

                entity.Property(e => e.IdLignesCommandes)
                    .HasColumnType("int(11)")
                    .HasColumnName("idLignesCommandes");

                entity.Property(e => e.IdAccompagnement)
                    .HasColumnType("int(11)")
                    .HasColumnName("idAccompagnement");

                entity.Property(e => e.IdCommande)
                    .HasColumnType("int(11)")
                    .HasColumnName("idCommande");

                entity.Property(e => e.IdMenu)
                    .HasColumnType("int(11)")
                    .HasColumnName("idMenu");

                entity.Property(e => e.IdPizza)
                    .HasColumnType("int(11)")
                    .HasColumnName("idPizza");

                entity.HasOne(d => d.IdAccompagnementNavigation)
                    .WithMany(p => p.Lignescommandes)
                    .HasForeignKey(d => d.IdAccompagnement)
                    .HasConstraintName("FK_LignesCommandes_Accompagnements");

                entity.HasOne(d => d.IdCommandeNavigation)
                    .WithMany(p => p.Lignescommandes)
                    .HasForeignKey(d => d.IdCommande)
                    .HasConstraintName("FK_LignesCommandes_Commandes");

                entity.HasOne(d => d.IdMenuNavigation)
                    .WithMany(p => p.Lignescommandes)
                    .HasForeignKey(d => d.IdMenu)
                    .HasConstraintName("FK_LignesCommandes_Menus");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.Lignescommandes)
                    .HasForeignKey(d => d.IdPizza)
                    .HasConstraintName("FK_LignesCommandes_Pizzas");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdMenu)
                    .HasName("PRIMARY");

                entity.ToTable("menus");

                entity.HasIndex(e => e.IdTaillePizza, "FK_Menus_TaillePizzas");

                entity.Property(e => e.IdMenu)
                    .HasColumnType("int(11)")
                    .HasColumnName("idMenu");

                entity.Property(e => e.Actif)
                    .HasColumnName("actif")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IdTaillePizza)
                    .HasColumnType("int(11)")
                    .HasColumnName("idTaillePizza");

                entity.Property(e => e.ImageMenu)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("imageMenu");

                entity.Property(e => e.NomMenu)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nomMenu");

                entity.Property(e => e.ReductionMenu)
                    .HasColumnType("decimal(4,2)")
                    .HasColumnName("reductionMenu");

                entity.HasOne(d => d.IdTaillePizzaNavigation)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.IdTaillePizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Menus_TaillePizzas");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("PRIMARY");

                entity.ToTable("pizzas");

                entity.HasIndex(e => e.IdTaillePizza, "FK_Pizzas_TaillePizzas");

                entity.HasIndex(e => e.IdTypePizza, "FK_Pizzas_TypePizzas");

                entity.Property(e => e.IdPizza)
                    .HasColumnType("int(11)")
                    .HasColumnName("idPizza");

                entity.Property(e => e.Actif)
                    .HasColumnName("actif")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IdTaillePizza)
                    .HasColumnType("int(11)")
                    .HasColumnName("idTaillePizza");

                entity.Property(e => e.IdTypePizza)
                    .HasColumnType("int(11)")
                    .HasColumnName("idTypePizza");

                entity.HasOne(d => d.IdTaillePizzaNavigation)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.IdTaillePizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizzas_TaillePizzas");

                entity.HasOne(d => d.IdTypePizzaNavigation)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.IdTypePizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizzas_TypePizzas");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PRIMARY");

                entity.ToTable("roles");

                entity.Property(e => e.IdRole)
                    .HasColumnType("int(11)")
                    .HasColumnName("idRole");

                entity.Property(e => e.NiveauAcreditation)
                    .HasColumnType("int(11)")
                    .HasColumnName("niveauAcreditation");

                entity.Property(e => e.NomRole)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nomRole");
            });

            modelBuilder.Entity<Seuilfidelite>(entity =>
            {
                entity.HasKey(e => e.IdSeuilFidelite)
                    .HasName("PRIMARY");

                entity.ToTable("seuilfidelites");

                entity.Property(e => e.IdSeuilFidelite)
                    .HasColumnType("int(11)")
                    .HasColumnName("idSeuilFidelite");

                entity.Property(e => e.MaxSeuil)
                    .HasColumnType("int(11)")
                    .HasColumnName("maxSeuil");

                entity.Property(e => e.MontantFidelite)
                    .HasColumnType("int(11)")
                    .HasColumnName("montantFidelite");
            });

            modelBuilder.Entity<Statut>(entity =>
            {
                entity.HasKey(e => e.IdStatut)
                    .HasName("PRIMARY");

                entity.ToTable("statuts");

                entity.Property(e => e.IdStatut)
                    .HasColumnType("int(11)")
                    .HasColumnName("idStatut");

                entity.Property(e => e.NomStatut)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nomStatut");
            });

            modelBuilder.Entity<Taillepizza>(entity =>
            {
                entity.HasKey(e => e.IdTaillePizza)
                    .HasName("PRIMARY");

                entity.ToTable("taillepizzas");

                entity.Property(e => e.IdTaillePizza)
                    .HasColumnType("int(11)")
                    .HasColumnName("idTaillePizza");

                entity.Property(e => e.MultiplicateurPrixPizza)
                    .HasColumnType("decimal(4,2)")
                    .HasColumnName("multiplicateurPrixPizza");

                entity.Property(e => e.ValeurTaillePizza)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("valeurTaillePizza");
            });

            modelBuilder.Entity<Typeaccompagnement>(entity =>
            {
                entity.HasKey(e => e.IdTypeAccompagnement)
                    .HasName("PRIMARY");

                entity.ToTable("typeaccompagnements");

                entity.Property(e => e.IdTypeAccompagnement)
                    .HasColumnType("int(11)")
                    .HasColumnName("idTypeAccompagnement");

                entity.Property(e => e.Actif)
                    .HasColumnName("actif")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.NomTypeAccompagnement)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nomTypeAccompagnement");
            });

            modelBuilder.Entity<Typeingredient>(entity =>
            {
                entity.HasKey(e => e.IdTypeIngredient)
                    .HasName("PRIMARY");

                entity.ToTable("typeingredients");

                entity.Property(e => e.IdTypeIngredient)
                    .HasColumnType("int(11)")
                    .HasColumnName("idTypeIngredient");

                entity.Property(e => e.NomTypeIngredient)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nomTypeIngredient");

                entity.Property(e => e.PrixTypeIngredient)
                    .HasColumnType("decimal(4,2)")
                    .HasColumnName("prixTypeIngredient");
            });

            modelBuilder.Entity<Typepizza>(entity =>
            {
                entity.HasKey(e => e.IdTypePizza)
                    .HasName("PRIMARY");

                entity.ToTable("typepizzas");

                entity.Property(e => e.IdTypePizza)
                    .HasColumnType("int(11)")
                    .HasColumnName("idTypePizza");

                entity.Property(e => e.Actif)
                    .HasColumnName("actif")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ImagePizza)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("imagePizza");

                entity.Property(e => e.NomTypePizza)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nomTypePizza");

                entity.Property(e => e.PrixBaseTypePizza)
                    .HasColumnType("decimal(4,2)")
                    .HasColumnName("prixBaseTypePizza");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
