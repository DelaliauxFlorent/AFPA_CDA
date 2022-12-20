using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace _1._5_BaseToModel_FilRouge.Models.DbModels
{
    public partial class villagegreenv2Context : DbContext
    {
        public villagegreenv2Context()
        {
        }

        public villagegreenv2Context(DbContextOptions<villagegreenv2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Adress> Adresses { get; set; }
        public virtual DbSet<Applicationstva> Applicationstvas { get; set; }
        public virtual DbSet<Approvision> Approvisions { get; set; }
        public virtual DbSet<Categoriesclient> Categoriesclients { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Commande> Commandes { get; set; }
        public virtual DbSet<Etatscommande> Etatscommandes { get; set; }
        public virtual DbSet<Fournisseur> Fournisseurs { get; set; }
        public virtual DbSet<Histoetatcom> Histoetatcoms { get; set; }
        public virtual DbSet<Lignescommande> Lignescommandes { get; set; }
        public virtual DbSet<Livraison> Livraisons { get; set; }
        public virtual DbSet<Paiement> Paiements { get; set; }
        public virtual DbSet<Pay> Pays { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }
        public virtual DbSet<Reglement> Reglements { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Rubrique> Rubriques { get; set; }
        public virtual DbSet<Tva> Tvas { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
        public virtual DbSet<Ville> Villes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Name=Default");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adress>(entity =>
            {
                entity.HasKey(e => e.IdAdresse)
                    .HasName("PRIMARY");

                entity.ToTable("adresses");

                entity.HasIndex(e => e.IdVille, "FK_Adresses_Villes");

                entity.Property(e => e.IdAdresse)
                    .HasColumnType("int(11)")
                    .HasColumnName("idAdresse");

                entity.Property(e => e.Adresse)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("adresse");

                entity.Property(e => e.ComplementAdresse)
                    .HasMaxLength(50)
                    .HasColumnName("complementAdresse");

                entity.Property(e => e.EmailAdresse)
                    .HasMaxLength(150)
                    .HasColumnName("emailAdresse");

                entity.Property(e => e.IdVille)
                    .HasColumnType("int(11)")
                    .HasColumnName("idVille");

                entity.Property(e => e.Province)
                    .HasMaxLength(50)
                    .HasColumnName("province");

                entity.Property(e => e.TelFixe)
                    .HasMaxLength(12)
                    .HasColumnName("telFixe");

                entity.Property(e => e.TelMobile)
                    .HasMaxLength(12)
                    .HasColumnName("telMobile");

                entity.HasOne(d => d.IdVilleNavigation)
                    .WithMany(p => p.Adresses)
                    .HasForeignKey(d => d.IdVille)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Adresses_Villes");
            });

            modelBuilder.Entity<Applicationstva>(entity =>
            {
                entity.HasKey(e => e.IdApplicationTva)
                    .HasName("PRIMARY");

                entity.ToTable("applicationstva");

                entity.HasIndex(e => e.IdProduit, "FK_ApplicationsTVA_Produits");

                entity.HasIndex(e => e.IdTva, "FK_ApplicationsTVA_TVAs");

                entity.Property(e => e.IdApplicationTva)
                    .HasColumnType("int(11)")
                    .HasColumnName("idApplicationTVA");

                entity.Property(e => e.DateTva)
                    .HasColumnType("date")
                    .HasColumnName("dateTVA");

                entity.Property(e => e.IdProduit)
                    .HasColumnType("int(11)")
                    .HasColumnName("idProduit");

                entity.Property(e => e.IdTva)
                    .HasColumnType("int(11)")
                    .HasColumnName("idTVA");

                entity.HasOne(d => d.IdProduitNavigation)
                    .WithMany(p => p.Applicationstvas)
                    .HasForeignKey(d => d.IdProduit)
                    .HasConstraintName("FK_ApplicationsTVA_Produits");

                entity.HasOne(d => d.IdTvaNavigation)
                    .WithMany(p => p.Applicationstvas)
                    .HasForeignKey(d => d.IdTva)
                    .HasConstraintName("FK_ApplicationsTVA_TVAs");
            });

            modelBuilder.Entity<Approvision>(entity =>
            {
                entity.HasKey(e => e.IdApprovision)
                    .HasName("PRIMARY");

                entity.ToTable("approvisions");

                entity.HasIndex(e => e.IdFournisseur, "FK_Approvisions_Fournisseurs");

                entity.HasIndex(e => e.IdProduit, "FK_Approvisions_Produits");

                entity.Property(e => e.IdApprovision)
                    .HasColumnType("int(11)")
                    .HasColumnName("idApprovision");

                entity.Property(e => e.IdFournisseur)
                    .HasColumnType("int(11)")
                    .HasColumnName("idFournisseur");

                entity.Property(e => e.IdProduit)
                    .HasColumnType("int(11)")
                    .HasColumnName("idProduit");

                entity.Property(e => e.RefFournisseur)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("refFournisseur");

                entity.HasOne(d => d.IdFournisseurNavigation)
                    .WithMany(p => p.Approvisions)
                    .HasForeignKey(d => d.IdFournisseur)
                    .HasConstraintName("FK_Approvisions_Fournisseurs");

                entity.HasOne(d => d.IdProduitNavigation)
                    .WithMany(p => p.Approvisions)
                    .HasForeignKey(d => d.IdProduit)
                    .HasConstraintName("FK_Approvisions_Produits");
            });

            modelBuilder.Entity<Categoriesclient>(entity =>
            {
                entity.HasKey(e => e.IdCategorieClient)
                    .HasName("PRIMARY");

                entity.ToTable("categoriesclients");

                entity.Property(e => e.IdCategorieClient)
                    .HasColumnType("int(11)")
                    .HasColumnName("idCategorieClient");

                entity.Property(e => e.CoefCategClient)
                    .HasColumnType("int(11)")
                    .HasColumnName("coefCategClient");

                entity.Property(e => e.InfoReglement)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("infoReglement");

                entity.Property(e => e.LibelleCategClient)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("libelleCategClient");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("clients");

                entity.HasIndex(e => e.IdAdresse, "FK_Clients_Adresses");

                entity.HasIndex(e => e.IdCategorieClient, "FK_Clients_CategoriesClients");

                entity.HasIndex(e => e.RefClient, "refClient")
                    .IsUnique();

                entity.Property(e => e.IdUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("idUser");

                entity.Property(e => e.CoefClient)
                    .HasColumnType("int(11)")
                    .HasColumnName("coefClient");

                entity.Property(e => e.IdAdresse)
                    .HasColumnType("int(11)")
                    .HasColumnName("idAdresse");

                entity.Property(e => e.IdCategorieClient)
                    .HasColumnType("int(11)")
                    .HasColumnName("idCategorieClient");

                entity.Property(e => e.RefClient)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("refClient");

                entity.HasOne(d => d.IdAdresseNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.IdAdresse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clients_Adresses");

                entity.HasOne(d => d.IdCategorieClientNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.IdCategorieClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clients_CategoriesClients");
            });

            modelBuilder.Entity<Commande>(entity =>
            {
                entity.HasKey(e => e.IdCommande)
                    .HasName("PRIMARY");

                entity.ToTable("commandes");

                entity.HasIndex(e => e.IdUser, "FK_Commandes_Clients");

                entity.HasIndex(e => e.NumeroCommande, "numeroCommande")
                    .IsUnique();

                entity.Property(e => e.IdCommande)
                    .HasColumnType("int(11)")
                    .HasColumnName("idCommande");

                entity.Property(e => e.DateCommande)
                    .HasColumnType("date")
                    .HasColumnName("dateCommande");

                entity.Property(e => e.IdUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("idUser");

                entity.Property(e => e.NumeroCommande)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("numeroCommande");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Commandes_Clients");
            });

            modelBuilder.Entity<Etatscommande>(entity =>
            {
                entity.HasKey(e => e.IdEtatCommande)
                    .HasName("PRIMARY");

                entity.ToTable("etatscommande");

                entity.Property(e => e.IdEtatCommande).HasColumnType("int(11)");

                entity.Property(e => e.LibelleEtatCommande)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("libelleEtatCommande");
            });

            modelBuilder.Entity<Fournisseur>(entity =>
            {
                entity.HasKey(e => e.IdFournisseur)
                    .HasName("PRIMARY");

                entity.ToTable("fournisseurs");

                entity.Property(e => e.IdFournisseur)
                    .HasColumnType("int(11)")
                    .HasColumnName("idFournisseur");

                entity.Property(e => e.NomFournisseur)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("nomFournisseur");
            });

            modelBuilder.Entity<Histoetatcom>(entity =>
            {
                entity.HasKey(e => e.IdHistoEtatCom)
                    .HasName("PRIMARY");

                entity.ToTable("histoetatcom");

                entity.HasIndex(e => e.IdCommande, "FK_HistoEtatCom_Commandes");

                entity.HasIndex(e => e.IdEtatCommande, "FK_HistoEtatCom_EtatsCommande");

                entity.Property(e => e.IdHistoEtatCom)
                    .HasColumnType("int(11)")
                    .HasColumnName("idHistoEtatCom");

                entity.Property(e => e.DateEtatCommande)
                    .HasColumnType("date")
                    .HasColumnName("dateEtatCommande");

                entity.Property(e => e.IdCommande)
                    .HasColumnType("int(11)")
                    .HasColumnName("idCommande");

                entity.Property(e => e.IdEtatCommande).HasColumnType("int(11)");

                entity.HasOne(d => d.IdCommandeNavigation)
                    .WithMany(p => p.Histoetatcoms)
                    .HasForeignKey(d => d.IdCommande)
                    .HasConstraintName("FK_HistoEtatCom_Commandes");

                entity.HasOne(d => d.IdEtatCommandeNavigation)
                    .WithMany(p => p.Histoetatcoms)
                    .HasForeignKey(d => d.IdEtatCommande)
                    .HasConstraintName("FK_HistoEtatCom_EtatsCommande");
            });

            modelBuilder.Entity<Lignescommande>(entity =>
            {
                entity.HasKey(e => e.IdLigneCommande)
                    .HasName("PRIMARY");

                entity.ToTable("lignescommande");

                entity.HasIndex(e => e.IdCommande, "FK_LignesCommande_Commandes");

                entity.HasIndex(e => e.IdProduit, "FK_LignesCommande_Produits");

                entity.Property(e => e.IdLigneCommande)
                    .HasColumnType("int(11)")
                    .HasColumnName("idLigneCommande");

                entity.Property(e => e.IdCommande)
                    .HasColumnType("int(11)")
                    .HasColumnName("idCommande");

                entity.Property(e => e.IdProduit)
                    .HasColumnType("int(11)")
                    .HasColumnName("idProduit");

                entity.Property(e => e.QuantiteProduit)
                    .HasColumnType("int(11)")
                    .HasColumnName("quantiteProduit");

                entity.HasOne(d => d.IdCommandeNavigation)
                    .WithMany(p => p.Lignescommandes)
                    .HasForeignKey(d => d.IdCommande)
                    .HasConstraintName("FK_LignesCommande_Commandes");

                entity.HasOne(d => d.IdProduitNavigation)
                    .WithMany(p => p.Lignescommandes)
                    .HasForeignKey(d => d.IdProduit)
                    .HasConstraintName("FK_LignesCommande_Produits");
            });

            modelBuilder.Entity<Livraison>(entity =>
            {
                entity.HasKey(e => e.IdLivraison)
                    .HasName("PRIMARY");

                entity.ToTable("livraisons");

                entity.HasIndex(e => e.IdAdresse, "FK_Livraisons_Adresses");

                entity.HasIndex(e => e.IdCommande, "FK_Livraisons_Commandes");

                entity.Property(e => e.IdLivraison)
                    .HasColumnType("int(11)")
                    .HasColumnName("idLivraison");

                entity.Property(e => e.DateLivraison)
                    .HasColumnType("date")
                    .HasColumnName("dateLivraison");

                entity.Property(e => e.IdAdresse)
                    .HasColumnType("int(11)")
                    .HasColumnName("idAdresse");

                entity.Property(e => e.IdCommande)
                    .HasColumnType("int(11)")
                    .HasColumnName("idCommande");

                entity.Property(e => e.QuantiteLivraison)
                    .HasColumnType("int(11)")
                    .HasColumnName("quantiteLivraison");

                entity.HasOne(d => d.IdAdresseNavigation)
                    .WithMany(p => p.Livraisons)
                    .HasForeignKey(d => d.IdAdresse)
                    .HasConstraintName("FK_Livraisons_Adresses");

                entity.HasOne(d => d.IdCommandeNavigation)
                    .WithMany(p => p.Livraisons)
                    .HasForeignKey(d => d.IdCommande)
                    .HasConstraintName("FK_Livraisons_Commandes");
            });

            modelBuilder.Entity<Paiement>(entity =>
            {
                entity.HasKey(e => e.IdPaiement)
                    .HasName("PRIMARY");

                entity.ToTable("paiements");

                entity.HasIndex(e => e.IdCommande, "FK_PAiements_Commandes");

                entity.HasIndex(e => e.IdReglement, "FK_Paiements_Reglements");

                entity.Property(e => e.IdPaiement)
                    .HasColumnType("int(11)")
                    .HasColumnName("idPaiement");

                entity.Property(e => e.DatePaiement)
                    .HasColumnType("date")
                    .HasColumnName("datePaiement");

                entity.Property(e => e.IdCommande)
                    .HasColumnType("int(11)")
                    .HasColumnName("idCommande");

                entity.Property(e => e.IdReglement)
                    .HasColumnType("int(11)")
                    .HasColumnName("idReglement");

                entity.Property(e => e.MontantPaiement)
                    .HasColumnType("decimal(19,4)")
                    .HasColumnName("montantPaiement");

                entity.HasOne(d => d.IdCommandeNavigation)
                    .WithMany(p => p.Paiements)
                    .HasForeignKey(d => d.IdCommande)
                    .HasConstraintName("FK_PAiements_Commandes");

                entity.HasOne(d => d.IdReglementNavigation)
                    .WithMany(p => p.Paiements)
                    .HasForeignKey(d => d.IdReglement)
                    .HasConstraintName("FK_Paiements_Reglements");
            });

            modelBuilder.Entity<Pay>(entity =>
            {
                entity.HasKey(e => e.IdPays)
                    .HasName("PRIMARY");

                entity.ToTable("pays");

                entity.Property(e => e.IdPays)
                    .HasColumnType("int(11)")
                    .HasColumnName("idPays");

                entity.Property(e => e.NomPays)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nomPays");
            });

            modelBuilder.Entity<Produit>(entity =>
            {
                entity.HasKey(e => e.IdProduit)
                    .HasName("PRIMARY");

                entity.ToTable("produits");

                entity.HasIndex(e => e.IdRubrique, "FK_Produits_Rubriques");

                entity.Property(e => e.IdProduit)
                    .HasColumnType("int(11)")
                    .HasColumnName("idProduit");

                entity.Property(e => e.DescProduit).HasColumnName("descProduit");

                entity.Property(e => e.IdRubrique)
                    .HasColumnType("int(11)")
                    .HasColumnName("idRubrique");

                entity.Property(e => e.LibelleProduit)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("libelleProduit");

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("photo");

                entity.Property(e => e.PrixHorsTaxe)
                    .HasColumnType("decimal(19,4)")
                    .HasColumnName("prixHorsTaxe");

                entity.Property(e => e.RefProduit)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("refProduit");

                entity.Property(e => e.Stock)
                    .HasColumnType("int(11)")
                    .HasColumnName("stock");

                entity.HasOne(d => d.IdRubriqueNavigation)
                    .WithMany(p => p.Produits)
                    .HasForeignKey(d => d.IdRubrique)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produits_Rubriques");
            });

            modelBuilder.Entity<Reglement>(entity =>
            {
                entity.HasKey(e => e.IdReglement)
                    .HasName("PRIMARY");

                entity.ToTable("reglements");

                entity.Property(e => e.IdReglement)
                    .HasColumnType("int(11)")
                    .HasColumnName("idReglement");

                entity.Property(e => e.TypePaiement)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("typePaiement");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PRIMARY");

                entity.ToTable("roles");

                entity.Property(e => e.IdRole)
                    .HasColumnType("int(11)")
                    .HasColumnName("idRole");

                entity.Property(e => e.LibelleRole)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("libelleRole");
            });

            modelBuilder.Entity<Rubrique>(entity =>
            {
                entity.HasKey(e => e.IdRubrique)
                    .HasName("PRIMARY");

                entity.ToTable("rubriques");

                entity.HasIndex(e => e.IdRubriqueParente, "FK_Rubriques_Selfs");

                entity.Property(e => e.IdRubrique)
                    .HasColumnType("int(11)")
                    .HasColumnName("idRubrique");

                entity.Property(e => e.IdRubriqueParente)
                    .HasColumnType("int(11)")
                    .HasColumnName("idRubriqueParente");

                entity.Property(e => e.LibelleRubrique)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("libelleRubrique");

                entity.HasOne(d => d.IdRubriqueParenteNavigation)
                    .WithMany(p => p.InverseIdRubriqueParenteNavigation)
                    .HasForeignKey(d => d.IdRubriqueParente)
                    .HasConstraintName("FK_Rubriques_Selfs");
            });

            modelBuilder.Entity<Tva>(entity =>
            {
                entity.HasKey(e => e.IdTva)
                    .HasName("PRIMARY");

                entity.ToTable("tvas");

                entity.Property(e => e.IdTva)
                    .HasColumnType("int(11)")
                    .HasColumnName("idTVA");

                entity.Property(e => e.TauxTva)
                    .HasColumnType("int(11)")
                    .HasColumnName("tauxTVA");
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("utilisateurs");

                entity.HasIndex(e => e.IdRole, "FK_Utilisateurs_Roles");

                entity.HasIndex(e => e.EmailUser, "emailUser")
                    .IsUnique();

                entity.Property(e => e.IdUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("idUser");

                entity.Property(e => e.EmailUser)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("emailUser");

                entity.Property(e => e.IdRole)
                    .HasColumnType("int(11)")
                    .HasColumnName("idRole");

                entity.Property(e => e.MdpUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("mdpUser");

                entity.Property(e => e.NomUser)
                    .HasMaxLength(150)
                    .HasColumnName("nomUser");

                entity.Property(e => e.PrenomUser)
                    .HasMaxLength(150)
                    .HasColumnName("prenomUser");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Utilisateurs)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Utilisateurs_Roles");
            });

            modelBuilder.Entity<Ville>(entity =>
            {
                entity.HasKey(e => e.IdVille)
                    .HasName("PRIMARY");

                entity.ToTable("villes");

                entity.HasIndex(e => e.IdPays, "FK_Villes_Pays");

                entity.Property(e => e.IdVille)
                    .HasColumnType("int(11)")
                    .HasColumnName("idVille");

                entity.Property(e => e.CodePostal)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("codePostal");

                entity.Property(e => e.IdPays)
                    .HasColumnType("int(11)")
                    .HasColumnName("idPays");

                entity.Property(e => e.LibelleVille)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("libelleVille");

                entity.HasOne(d => d.IdPaysNavigation)
                    .WithMany(p => p.Villes)
                    .HasForeignKey(d => d.IdPays)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Villes_Pays");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
