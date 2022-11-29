DROP DATABASE IF EXISTS villageGreenV2;

CREATE DATABASE villageGreenV2;

ALTER DATABASE villageGreenV2 DEFAULT charset = UTF8;

USE villageGreenV2;

--
-- Table Rubriques
--
DROP TABLE IF EXISTS Rubriques;

CREATE TABLE Rubriques(
    idRubrique INT AUTO_INCREMENT PRIMARY KEY,
    libelleRubrique VARCHAR(150) NOT NULL,
    idRubriqueParente INT
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Fournisseurs
--
DROP TABLE IF EXISTS Fournisseurs;

CREATE TABLE Fournisseurs(
    idFournisseur INT AUTO_INCREMENT PRIMARY KEY,
    nomFournisseur VARCHAR(150) NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table CategoriesClients
--
DROP TABLE IF EXISTS CategoriesClients;

CREATE TABLE CategoriesClients(
    idCategorieClient INT AUTO_INCREMENT PRIMARY KEY,
    libelleCategClient VARCHAR(150) NOT NULL,
    infoReglement VARCHAR(50) NOT NULL,
    coefCategClient INT NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Reglements
--
DROP TABLE IF EXISTS Reglements;

CREATE TABLE Reglements(
    idReglement INT AUTO_INCREMENT PRIMARY KEY,
    typePaiement VARCHAR(50) NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table TVAs
--
DROP TABLE IF EXISTS TVAs;

CREATE TABLE TVAs(
    idTVA INT AUTO_INCREMENT PRIMARY KEY,
    tauxTVA INT NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Roles
--
DROP TABLE IF EXISTS Roles;

CREATE TABLE Roles(
    idRole INT AUTO_INCREMENT PRIMARY KEY,
    libelleRole VARCHAR(50) NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Pays
--
DROP TABLE IF EXISTS Pays;

CREATE TABLE Pays(
    idPays INT AUTO_INCREMENT PRIMARY KEY,
    nomPays VARCHAR(50) NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table EtatsCommande
--
DROP TABLE IF EXISTS EtatsCommande;

CREATE TABLE EtatsCommande(
    IdEtatCommande INT AUTO_INCREMENT PRIMARY KEY,
    libelleEtatCommande VARCHAR(50) NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Produits
--
DROP TABLE IF EXISTS Produits;

CREATE TABLE Produits(
    idProduit INT AUTO_INCREMENT PRIMARY KEY,
    libelleProduit VARCHAR(150) NOT NULL,
    descProduit TEXT,
    refProduit VARCHAR(5) NOT NULL,
    prixHorsTaxe DECIMAL(19, 4) NOT NULL,
    photo VARCHAR(150) NOT NULL,
    stock INT NOT NULL,
    idRubrique INT NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Villes
--
DROP TABLE IF EXISTS Villes;

CREATE TABLE Villes(
    idVille INT AUTO_INCREMENT PRIMARY KEY,
    libelleVille VARCHAR(150) NOT NULL,
    codePostal VARCHAR(6) NOT NULL,
    idPays INT NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Adresses
--
DROP TABLE IF EXISTS Adresses;

CREATE TABLE Adresses(
    idAdresse INT AUTO_INCREMENT PRIMARY KEY,
    emailAdresse VARCHAR(150),
    telMobile VARCHAR(12),
    telFixe VARCHAR(12),
    adresse VARCHAR(50) NOT NULL,
    province VARCHAR(50),
    complementAdresse VARCHAR(50),
    idVille INT NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Utilisateurs
--
DROP TABLE IF EXISTS Utilisateurs;

CREATE TABLE Utilisateurs(
    idUser INT AUTO_INCREMENT PRIMARY KEY,
    nomUser VARCHAR(150),
    prenomUser VARCHAR(150),
    emailUser VARCHAR(150) NOT NULL UNIQUE,
    mdpUser VARCHAR(50) NOT NULL,
    idRole INT NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Clients
--
DROP TABLE IF EXISTS Clients;

CREATE TABLE Clients(
    idUser INT AUTO_INCREMENT PRIMARY KEY,
    refClient VARCHAR(5) NOT NULL UNIQUE,
    coefClient INT NOT NULL,
    idAdresse INT NOT NULL,
    idCategorieClient INT NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Commandes
--
DROP TABLE IF EXISTS Commandes;

CREATE TABLE Commandes(
    idCommande INT AUTO_INCREMENT PRIMARY KEY,
    numeroCommande VARCHAR(10) NOT NULL UNIQUE,
    dateCommande DATE NOT NULL,
    idUser INT NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Approvisions
--
DROP TABLE IF EXISTS Approvisions;

CREATE TABLE Approvisions(
    idApprovision INT AUTO_INCREMENT PRIMARY KEY,
    idProduit INT,
    idFournisseur INT,
    refFournisseur VARCHAR(150) NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table ApplicationsTVA
--
DROP TABLE IF EXISTS ApplicationsTVA;

CREATE TABLE ApplicationsTVA(
    idApplicationTVA INT AUTO_INCREMENT PRIMARY KEY,
    idProduit INT,
    idTVA INT,
    dateTVA DATE NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table LignesCommande
--
DROP TABLE IF EXISTS LignesCommande;

CREATE TABLE LignesCommande(
    idLigneCommande INT AUTO_INCREMENT PRIMARY KEY,
    idProduit INT,
    idCommande INT,
    quantiteProduit INT NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Paiements
--
DROP TABLE IF EXISTS Paiements;

CREATE TABLE Paiements(
    idPaiement INT AUTO_INCREMENT PRIMARY KEY,
    idReglement INT,
    idCommande INT,
    datePaiement DATE NOT NULL,
    montantPaiement DECIMAL(19, 4) NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table HistoEtatSCom
--
DROP TABLE IF EXISTS HistoEtatCom;

CREATE TABLE HistoEtatCom(
    idHistoEtatCom INT AUTO_INCREMENT PRIMARY KEY,
    idCommande INT,
    IdEtatCommande INT,
    dateEtatCommande DATE NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Livraisons
--
DROP TABLE IF EXISTS Livraisons;

CREATE TABLE Livraisons(
    idLivraison INT AUTO_INCREMENT PRIMARY KEY,
    idAdresse INT,
    idCommande INT,
    quantiteLivraison INT NOT NULL,
    dateLivraison DATE NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Clés Étrangères
--
ALTER TABLE
    Rubriques
ADD
    CONSTRAINT FK_Rubriques_Selfs FOREIGN KEY(idRubriqueParente) REFERENCES Rubriques(idRubrique);

ALTER TABLE
    Produits
ADD
    CONSTRAINT FK_Produits_Rubriques FOREIGN KEY(idRubrique) REFERENCES Rubriques(idRubrique);

ALTER TABLE
    Villes
ADD
    CONSTRAINT FK_Villes_Pays FOREIGN KEY(idPays) REFERENCES Pays(idPays);

ALTER TABLE
    Adresses
ADD
    CONSTRAINT FK_Adresses_Villes FOREIGN KEY(idVille) REFERENCES Villes(idVille);

ALTER TABLE
    Utilisateurs
ADD
    CONSTRAINT FK_Utilisateurs_Roles FOREIGN KEY(idRole) REFERENCES Roles(idRole);

ALTER TABLE
    Clients
ADD
    CONSTRAINT FK_Clients_Adresses FOREIGN KEY(idAdresse) REFERENCES Adresses(idAdresse),
ADD
    CONSTRAINT FK_Clients_CategoriesClients FOREIGN KEY(idCategorieClient) REFERENCES CategoriesClients(idCategorieClient);

ALTER TABLE
    Commandes
ADD
    CONSTRAINT FK_Commandes_Clients FOREIGN KEY(idUser) REFERENCES Clients(idUser);

ALTER TABLE
    Approvisions
ADD
    CONSTRAINT FK_Approvisions_Produits FOREIGN KEY(idProduit) REFERENCES Produits(idProduit),
ADD
    CONSTRAINT FK_Approvisions_Fournisseurs FOREIGN KEY(idFournisseur) REFERENCES Fournisseurs(idFournisseur);

ALTER TABLE
    ApplicationsTVA
ADD
    CONSTRAINT FK_ApplicationsTVA_Produits FOREIGN KEY(idProduit) REFERENCES Produits(idProduit),
ADD
    CONSTRAINT FK_ApplicationsTVA_TVAs FOREIGN KEY(idTVA) REFERENCES TVAs(idTVA);

ALTER TABLE
    LignesCommande
ADD
    CONSTRAINT FK_LignesCommande_Produits FOREIGN KEY(idProduit) REFERENCES Produits(idProduit),
ADD
    CONSTRAINT FK_LignesCommande_Commandes FOREIGN KEY(idCommande) REFERENCES Commandes(idCommande);

ALTER TABLE
    Paiements
ADD
    CONSTRAINT FK_Paiements_Reglements FOREIGN KEY(idReglement) REFERENCES Reglements(idReglement),
ADD
    CONSTRAINT FK_PAiements_Commandes FOREIGN KEY(idCommande) REFERENCES Commandes(idCommande);

ALTER TABLE
    HistoEtatCom
ADD
    CONSTRAINT FK_HistoEtatCom_Commandes FOREIGN KEY(idCommande) REFERENCES Commandes(idCommande),
ADD
    CONSTRAINT FK_HistoEtatCom_EtatsCommande FOREIGN KEY(idEtatCommande) REFERENCES EtatsCommande(idEtatCommande);

ALTER TABLE
    Livraisons
ADD
    CONSTRAINT FK_Livraisons_Adresses FOREIGN KEY(idAdresse) REFERENCES Adresses(idAdresse),
ADD
    CONSTRAINT FK_Livraisons_Commandes FOREIGN KEY(idCommande) REFERENCES Commandes(idCommande);