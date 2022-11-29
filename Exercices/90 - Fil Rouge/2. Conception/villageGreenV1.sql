DROP DATABASE IF EXISTS villageGreenV1;

CREATE DATABASE villageGreenV1;

ALTER DATABASE villageGreenV1 DEFAULT charset = UTF8;

USE villageGreenV1;

--
-- Table Rubriques
--
DROP TABLE IF EXISTS Rubriques;

CREATE TABLE Rubriques(
    idRubrique INT AUTO_INCREMENT PRIMARY KEY,
    nomRubrique VARCHAR(50) NOT NULL,
    idRubrique_enfante INT NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Adresses
--
DROP TABLE IF EXISTS Adresses;

CREATE TABLE Adresses(
    idAdresse INT AUTO_INCREMENT PRIMARY KEY,
    mail VARCHAR(50),
    telephone VARCHAR(17),
    mobile VARCHAR(17),
    adresse VARCHAR(100) NOT NULL,
    complAdresse VARCHAR(50)
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Fournisseurs
--
DROP TABLE IF EXISTS Fournisseurs;

CREATE TABLE Fournisseurs(
    idFournisseur INT AUTO_INCREMENT PRIMARY KEY,
    nomFournisseur VARCHAR(50) NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Categories
--
DROP TABLE IF EXISTS Categories;

CREATE TABLE Categories(
    idCategorie INT AUTO_INCREMENT PRIMARY KEY,
    libelleCategorie VARCHAR(25) NOT NULL,
    coefCategorie DECIMAL(5, 2) NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table TVAs
--
DROP TABLE IF EXISTS TVAs;

CREATE TABLE TVAs(
    idTVA INT AUTO_INCREMENT PRIMARY KEY,
    tauxTVA DECIMAL(15, 2) NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Reglements
--
DROP TABLE IF EXISTS Reglements;

CREATE TABLE Reglements(
    idReglement INT AUTO_INCREMENT PRIMARY KEY,
    typeReglement VARCHAR(25) NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table StatusCommandes
--
DROP TABLE IF EXISTS StatusCommandes;

CREATE TABLE StatusCommandes(
    idStatus INT AUTO_INCREMENT PRIMARY KEY,
    libelleStatus VARCHAR(25) NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Produits
--
DROP TABLE IF EXISTS Produits;

CREATE TABLE Produits(
    idProduit INT AUTO_INCREMENT PRIMARY KEY,
    refProduit VARCHAR(6) NOT NULL,
    descProduit VARCHAR(50) NOT NULL,
    prixHTProduit DECIMAL(19, 4) NOT NULL,
    photoProduit VARCHAR(50) NOT NULL,
    stockProduit INT NOT NULL,
    idFournisseur INT NOT NULL,
    idRubrique INT
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Clients
--
DROP TABLE IF EXISTS Clients;

CREATE TABLE Clients(
    idClient INT AUTO_INCREMENT PRIMARY KEY,
    numClient INT NOT NULL,
    nomClient VARCHAR(25) NOT NULL,
    prenomClient VARCHAR(25) NOT NULL,
    coefClient DECIMAL(5, 2) NOT NULL,
    idCategorie INT NOT NULL,
    idAdresse INT NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Commandes
--
DROP TABLE IF EXISTS Commandes;

CREATE TABLE Commandes(
    idCommande INT AUTO_INCREMENT PRIMARY KEY,
    numCommande INT NOT NULL UNIQUE,
    dateCommande DATE NOT NULL,
    idAdresseLivr INT NOT NULL,
    idAdresseFact INT NOT NULL,
    idClient INT NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Utilisateurs
--
DROP TABLE IF EXISTS Utilisateurs;

CREATE TABLE Utilisateurs(
    idUtilisateur INT AUTO_INCREMENT PRIMARY KEY,
    nomUtilisateur VARCHAR(50) NOT NULL,
    mailUtilisateur VARCHAR(50) NOT NULL UNIQUE,
    motDePasseUtilisateur VARCHAR(50) NOT NULL,
    idClient INT UNIQUE
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table LignesCommandes
--
DROP TABLE IF EXISTS LignesCommandes;

CREATE TABLE LignesCommandes(
    idLigneCommande INT AUTO_INCREMENT PRIMARY KEY,
    idProduit INT,
    idCommande INT,
    qteProduit INT NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Livraisons
--
DROP TABLE IF EXISTS Livraisons;

CREATE TABLE Livraisons(
    idLivraison INT AUTO_INCREMENT PRIMARY KEY,
    idProduit INT,
    idCommande INT,
    qteLivraison INT NOT NULL,
    dateLivraison DATE NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Paiements
--
DROP TABLE IF EXISTS Paiements;

CREATE TABLE Paiements(
    idPaiement INT AUTO_INCREMENT PRIMARY KEY,
    idCommande INT,
    idReglement INT,
    montantPaiement DECIMAL(19, 4) NOT NULL,
    datePaiement DATE NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table HistoriqueStatusCommandes
--
DROP TABLE IF EXISTS HistoriqueStatusCommandes;

CREATE TABLE HistoriqueStatusCommandes(
    idHistStatCom INT AUTO_INCREMENT PRIMARY KEY,
    idCommande INT,
    idStatus INT,
    dateStatusCommande DATE
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table ApplicationsTVA
--
DROP TABLE IF EXISTS ApplicationsTVA;

CREATE TABLE ApplicationsTVA(
    idApplicationTVA INT AUTO_INCREMENT PRIMARY KEY,
    idProduit INT,
    idTVA INT,
    dateValiditeTVA DATE NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Clés Étrangères
--
ALTER TABLE
    Rubriques
ADD
    CONSTRAINT FK_Rubriques_Enfantes FOREIGN KEY(idRubrique_enfante) REFERENCES Rubriques(idRubrique);

ALTER TABLE
    Produits
ADD
    CONSTRAINT FK_Produits_Fournisseurs FOREIGN KEY(idFournisseur) REFERENCES Fournisseurs(idFournisseur),
ADD
    CONSTRAINT FK_Produits_Rubriques FOREIGN KEY(idRubrique) REFERENCES Rubriques(idRubrique);

ALTER TABLE
    Clients
ADD
    CONSTRAINT FK_Clients_Categories FOREIGN KEY(idCategorie) REFERENCES Categories(idCategorie),
ADD
    CONSTRAINT FK_Clients_Adresses FOREIGN KEY(idAdresse) REFERENCES Adresses(idAdresse);

ALTER TABLE
    Commandes
ADD
    CONSTRAINT FK_Commandes_Adresses FOREIGN KEY(idAdresseLivr) REFERENCES Adresses(idAdresse),
ADD
    CONSTRAINT FK_Commandes_Adresses FOREIGN KEY(idAdresseFact) REFERENCES Adresses(idAdresse),
ADD
    CONSTRAINT FK_Commandes_Clients FOREIGN KEY(idClient) REFERENCES Clients(idClient);

ALTER TABLE
    Utilisateurs
ADD
    CONSTRAINT FK_Utilisateurs_Clients FOREIGN KEY(idClient) REFERENCES Clients(idClient);

ALTER TABLE
    LignesCommandes
ADD
    CONSTRAINT FK_LignesCommandes_Produits FOREIGN KEY(idProduit) REFERENCES Produits(idProduit),
ADD
    CONSTRAINT FK_LignesCommandes_Commandes FOREIGN KEY(idCommande) REFERENCES Commandes(idCommande);

ALTER TABLE
    Livraisons
ADD
    CONSTRAINT FK_Livraisons_Produits FOREIGN KEY(idProduit) REFERENCES Produits(idProduit),
ADD
    CONSTRAINT FK_Livraisons_Commandes FOREIGN KEY(idcommande) REFERENCES Commandes(idcommande);

ALTER TABLE
    Paiements
ADD
    CONSTRAINT FK_Paiements_Commandes FOREIGN KEY(idCommande) REFERENCES Commandes(idCommande),
ADD
    CONSTRAINT FK_Paiements_Reglements FOREIGN KEY(idReglement) REFERENCES Reglements(idReglement);

ALTER TABLE
    HistoriqueStatusCommandes
ADD
    CONSTRAINT FK_HistoriqueStatusCommandes_Commandes FOREIGN KEY(idCommande) REFERENCES Commandes(idCommande),
ADD
    CONSTRAINT FK_HistoriqueStatusCommandes_StatusCommandes FOREIGN KEY(idStatus) REFERENCES StatusCommandes(idStatus);

ALTER TABLE
    ApplicationsTVA
ADD
    CONSTRAINT FK_ApplicationsTVA_Produits FOREIGN KEY(idProduit) REFERENCES Produits(idProduit),
ADD
    CONSTRAINT FK_ApllicationsTVA_TVAs FOREIGN KEY(idTVA) REFERENCES TVAs(idTVA);