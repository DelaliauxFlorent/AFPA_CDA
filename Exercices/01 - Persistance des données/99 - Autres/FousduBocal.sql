DROP DATABASE IF EXISTS fou_du_bocal;

CREATE DATABASE fou_du_bocal;

ALTER DATABASE fou_du_bocal DEFAULT charset = UTF8;

USE fou_du_bocal;

--
-- Table Clubs
--
DROP TABLE IF EXISTS Clubs;

CREATE TABLE Clubs(
    idClub INT AUTO_INCREMENT PRIMARY KEY,
    nomClub VARCHAR(50) NOT NULL,
    horraireOuverture VARCHAR(5) NOT NULL,
    horraireFermeture VARCHAR(5) NOT NULL
) DEFAULT charset = UTF8;

--
-- Table Membres
--
DROP TABLE IF EXISTS Membres;

CREATE TABLE Membres(
    idMembre INT AUTO_INCREMENT PRIMARY KEY,
    prenomMembre VARCHAR(50) NOT NULL,
    nomMembre VARCHAR(50) NOT NULL
) DEFAULT charset = UTF8;

--
-- Table Visiteurs
--
DROP TABLE IF EXISTS Visiteurs;

CREATE TABLE Visiteurs(
    idVisiteur INT AUTO_INCREMENT PRIMARY KEY,
    ageVisiteur INT NOT NULL
) DEFAULT charset = UTF8;

--
-- Table Tarifs
--
DROP TABLE IF EXISTS Tarifs;

CREATE TABLE Tarifs(
    idTarif INT AUTO_INCREMENT PRIMARY KEY,
    ageDebutApplicationTarif SMALLINT NOT NULL,
    ageFinApplicationTarif SMALLINT NOT NULL,
    valeurTarif DECIMAL(19, 4) NOT NULL
) DEFAULT charset = UTF8;

--
-- Table Genres
--
DROP TABLE IF EXISTS Genres;

CREATE TABLE Genres(
    idGenre INT AUTO_INCREMENT PRIMARY KEY,
    libelleGenre VARCHAR(50) NOT NULL
) DEFAULT charset = UTF8;

--
-- Table RegimesAlimentaires
--
DROP TABLE IF EXISTS RegimesAlimentaires;

CREATE TABLE RegimesAlimentaires(
    idRegimeAlimentaire INT AUTO_INCREMENT PRIMARY KEY,
    libelleRegimeAlimentaire VARCHAR(50)
) DEFAULT charset = UTF8;

--
-- Table ZonesGeographiques
--
DROP TABLE IF EXISTS ZonesGeographiques;

CREATE TABLE ZonesGeographiques(
    idZoneGeographique INT AUTO_INCREMENT PRIMARY KEY,
    libelleZoneGeographique VARCHAR(50)
) DEFAULT charset = UTF8;

--
-- Table Salinites
--
DROP TABLE IF EXISTS Salinites;

CREATE TABLE Salinites(
    idSalinite INT AUTO_INCREMENT PRIMARY KEY,
    libelleSalinité VARCHAR(50) NOT NULL,
    valeurSalinite VARCHAR(50)
) DEFAULT charset = UTF8;

--
-- Table Pieces
--
DROP TABLE IF EXISTS Pieces;

CREATE TABLE Pieces(
    idPiece INT AUTO_INCREMENT PRIMARY KEY,
    nomPiece VARCHAR(50) NOT NULL,
    limiteAuxMembres BOOLEAN,
    idClub INT NOT NULL
) DEFAULT charset = UTF8;

--
-- Table Aquariums
--
DROP TABLE IF EXISTS Aquariums;

CREATE TABLE Aquariums(
    idAquarium INT AUTO_INCREMENT PRIMARY KEY,
    designationAquarium VARCHAR(50),
    idZoneGeographique INT NOT NULL,
    idSalinite INT NOT NULL,
    idPiece INT NOT NULL
) DEFAULT charset = UTF8;

--
-- Table Nourritures
--
DROP TABLE IF EXISTS Nourritures;

CREATE TABLE Nourritures(
    idNourriture INT AUTO_INCREMENT PRIMARY KEY,
    libelleNourriture VARCHAR(50) NOT NULL,
    quantiteStockNourriture DECIMAL(6, 2) NOT NULL
) DEFAULT charset = UTF8;

--
-- Table Ingredients
--
DROP TABLE IF EXISTS Ingredients;

CREATE TABLE Ingredients(
    idIngredient INT AUTO_INCREMENT PRIMARY KEY,
    nomIngredient VARCHAR(50) NOT NULL,
    quantiteStockIngredient DECIMAL(6, 2) NOT NULL
) DEFAULT charset = UTF8;

--
-- Table Bourses
--
DROP TABLE IF EXISTS Bourses;

CREATE TABLE Bourses(
    idBourse INT AUTO_INCREMENT PRIMARY KEY,
    anneeBourse SMALLINT NOT NULL UNIQUE,
    gainsBourse DECIMAL(19, 4) NOT NULL
) DEFAULT charset = UTF8;

--
-- Table Especes
--
DROP TABLE IF EXISTS Especes;

CREATE TABLE Especes(
    idEspece INT AUTO_INCREMENT PRIMARY KEY,
    descriptionEspece TEXT,
    temperatureMinSurvieEspece DECIMAL(4, 2) NOT NULL,
    temperatureMaxSurvieEspece DECIMAL(4, 2) NOT NULL,
    prixVenteIndividuEspece DECIMAL(19, 4) NOT NULL,
    idSalinite INT NOT NULL,
    idRegimeAlimentaire INT NOT NULL
) DEFAULT charset = UTF8;

--
-- Table Poissons
--
DROP TABLE IF EXISTS Poissons;

CREATE TABLE Poissons(
    idPoisson INT AUTO_INCREMENT PRIMARY KEY,
    nomPoisson VARCHAR(50) NOT NULL,
    dateNaissance DATE,
    idAquarium INT NOT NULL,
    idEspece INT NOT NULL
) DEFAULT charset = UTF8;

--
-- Table Visites
--
DROP TABLE IF EXISTS Visites;

CREATE TABLE Visites(
    idVisite INT AUTO_INCREMENT PRIMARY KEY,
    idClub INT,
    idVisiteur INT,
    idTarif INT,
    dateVisite DATE NOT NULL
) DEFAULT charset = UTF8;

--
-- Table Participations
--
DROP TABLE IF EXISTS Participations;

CREATE TABLE Participations(
    idParticipation INT AUTO_INCREMENT PRIMARY KEY,
    idClub INT,
    idMembre INT
) DEFAULT charset = UTF8;

--
-- Table Typages
--
DROP TABLE IF EXISTS Typages;

CREATE TABLE Typages(
    idTypage INT AUTO_INCREMENT PRIMARY KEY,
    idPoisson INT,
    idGenre INT,
    dateTypage DATE
) DEFAULT charset = UTF8;

--
-- Table Apparitions
--
DROP TABLE IF EXISTS Apparitions;

CREATE TABLE Apparitions(
    idApparition INT AUTO_INCREMENT PRIMARY KEY,
    idEspece INT,
    idZoneGeographique INT
) DEFAULT charset = UTF8;

--
-- Table Relations
--
DROP TABLE IF EXISTS Relations;

CREATE TABLE Relations(
    idRelations INT AUTO_INCREMENT PRIMARY KEY,
    idPoisson_parent INT,
    idPoisson_enfant INT
) DEFAULT charset = UTF8;

--
-- Table Nettoyages
--
DROP TABLE IF EXISTS Nettoyages;

CREATE TABLE Nettoyages(
    idNettoyages INT AUTO_INCREMENT PRIMARY KEY,
    idMembre INT,
    idAquarium INT,
    dateChangementEau DATE
) DEFAULT charset = UTF8;

--
-- Table Quarantaines
--
DROP TABLE IF EXISTS Quarantaines;

CREATE TABLE Quarantaines(
    idQuarantaines INT AUTO_INCREMENT PRIMARY KEY,
    idMembre INT,
    idPoisson INT,
    dateMiseEnQuarantaine DATE NOT NULL
) DEFAULT charset = UTF8;

--
-- Table StockNourritures
--
DROP TABLE IF EXISTS StockNourritures;

CREATE TABLE StockNourritures(
    idStockNourriture INT AUTO_INCREMENT PRIMARY KEY,
    idClub INT,
    idNourriture INT
) DEFAULT charset = UTF8;

--
-- Table StockIngredients
--
DROP TABLE IF EXISTS StockIngredients;

CREATE TABLE StockIngredients(
    idStockIngredients INT AUTO_INCREMENT PRIMARY KEY,
    idClub INT,
    idIngredient INT
) DEFAULT charset = UTF8;

--
-- Table Compositions
--
DROP TABLE IF EXISTS Compositions;

CREATE TABLE Compositions(
    idComposition INT AUTO_INCREMENT PRIMARY KEY,
    idNourriture INT,
    idIngredient INT
) DEFAULT charset = UTF8;

--
-- Table Organisations
--
DROP TABLE IF EXISTS Organisations;

CREATE TABLE Organisations(
    idOrganisation INT AUTO_INCREMENT PRIMARY KEY,
    idClub INT,
    idBourse INT
) DEFAULT charset = UTF8;

--
-- Clés étrangères
--
ALTER TABLE
    Pieces
ADD
    CONSTRAINT FK_Pieces_Clubs FOREIGN KEY(idClub) REFERENCES Clubs(idClub);

ALTER TABLE
    Aquariums
ADD
    CONSTRAINT FK_Aquariums_ZonesGeo FOREIGN KEY(idZoneGeographique) REFERENCES ZonesGeographiques(idZoneGeographique),
ADD
    CONSTRAINT FK_Aquariums_Salinites FOREIGN KEY(idSalinite) REFERENCES Salinites(idSalinite),
ADD
    CONSTRAINT FK_Aquariums_Pieces FOREIGN KEY(idPiece) REFERENCES Pieces(idPiece);

ALTER TABLE
    Especes
ADD
    CONSTRAINT FK_Especes_Salinites FOREIGN KEY(idSalinite) REFERENCES Salinites(idSalinite),
ADD
    CONSTRAINT FK_Especes_RegAli FOREIGN KEY(idRegimeAlimentaire) REFERENCES RegimesAlimentaires(idRegimeAlimentaire);

ALTER TABLE
    Poissons
ADD
    CONSTRAINT FK_Poissons_Aquariums FOREIGN KEY(idAquarium) REFERENCES Aquariums(idAquarium),
ADD
    CONSTRAINT FK_Poissons_Especes FOREIGN KEY(idEspece) REFERENCES Especes(idEspece);

ALTER TABLE
    Visites
ADD
    CONSTRAINT FK_Visites_Clubs FOREIGN KEY(idClub) REFERENCES Clubs(idClub),
ADD
    CONSTRAINT FK_Visites_Visiteurs FOREIGN KEY(idVisiteur) REFERENCES Visiteurs(idVisiteur),
ADD
    CONSTRAINT FK_Visites_Tarifs FOREIGN KEY(idTarif) REFERENCES Tarifs(idTarif);

ALTER TABLE
    Participations
ADD
    CONSTRAINT FK_Participations_Clubs FOREIGN KEY(idClub) REFERENCES Clubs(idClub),
ADD
    CONSTRAINT FK_Participations_Membres FOREIGN KEY(idMembre) REFERENCES Membres(idMembre);

ALTER TABLE
    Typages
ADD
    CONSTRAINT FK_Typages_Poissons FOREIGN KEY(idPoisson) REFERENCES Poissons(idPoisson),
ADD
    CONSTRAINT FK_Typages_Genres FOREIGN KEY(idGenre) REFERENCES Genres(idGenre);

ALTER TABLE
    Apparitions
ADD
    CONSTRAINT FK_Apparitions_Especes FOREIGN KEY(idEspece) REFERENCES Especes(idEspece),
ADD
    CONSTRAINT FK_Apparitions_ZoneGeo FOREIGN KEY(idZoneGeographique) REFERENCES ZonesGeographiques(idZoneGeographique);

ALTER TABLE
    Relations
ADD
    CONSTRAINT FK_Relations_PoisPar FOREIGN KEY(idPoisson_parent) REFERENCES Poissons(idPoisson),
ADD
    CONSTRAINT FK_Relations_PoisEnf FOREIGN KEY(idPoisson_enfant) REFERENCES Poissons(idPoisson);

ALTER TABLE
    Nettoyages
ADD
    CONSTRAINT FK_Nettoyages_Membres FOREIGN KEY(idMembre) REFERENCES Membres(idMembre),
ADD
    CONSTRAINT FK_Nettoyages_Aquariums FOREIGN KEY(idAquarium) REFERENCES Aquariums(idAquarium);

ALTER TABLE
    Quarantaines
ADD
    CONSTRAINT FK_Quarantaines_Membres FOREIGN KEY(idMembre) REFERENCES Membres(idMembre),
ADD
    CONSTRAINT FK_Quarantaines_Poissons FOREIGN KEY(idPoisson) REFERENCES Poissons(idPoisson);

ALTER TABLE
    StockNourritures
ADD
    CONSTRAINT FK_StockNourritures_Clubs FOREIGN KEY(idClub) REFERENCES Clubs(idClub),
ADD
    CONSTRAINT FK_StockNourritures_Nourritures FOREIGN KEY(idNourriture) REFERENCES Nourritures(idNourriture);

ALTER TABLE
    StockIngredients
ADD
    CONSTRAINT FK_StockIngredients_Clubs FOREIGN KEY(idClub) REFERENCES Clubs(idClub),
ADD
    CONSTRAINT FK_StockIngredients_Ingredients FOREIGN KEY(idIngredient) REFERENCES Ingredients(idIngredient);

ALTER TABLE
    Compositions
ADD
    CONSTRAINT FK_Compositions_Nourritures FOREIGN KEY(idNourriture) REFERENCES Nourritures(idNourriture),
ADD
    CONSTRAINT FK_Compositions_Ingredients FOREIGN KEY(idIngredient) REFERENCES Ingredients(idIngredient);

ALTER TABLE
    Organisations
ADD
    CONSTRAINT FK_Organisations_Clubs FOREIGN KEY(idClub) REFERENCES Clubs(idClub),
ADD
    CONSTRAINT FK_Organisations_Bourses FOREIGN KEY(idBourse) REFERENCES Bourses(idBourse);