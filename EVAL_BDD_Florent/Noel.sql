DROP DATABASE IF EXISTS LivraisonsNoel;

CREATE DATABASE LivraisonsNoel;

ALTER DATABASE LivraisonsNoel DEFAULT charset = UTF8;

USE LivraisonsNoel;

--
-- Table Pays
--
DROP TABLE IF EXISTS Pays;

CREATE TABLE Pays(
    idPays VARCHAR(50) PRIMARY KEY,
    nomPays VARCHAR(50) NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Voeus
--
DROP TABLE IF EXISTS Voeus;

CREATE TABLE Voeus(
    idVoeu INT AUTO_INCREMENT PRIMARY KEY,
    libelleVoeu VARCHAR(50) NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Genres
--
DROP TABLE IF EXISTS Genres;

CREATE TABLE Genres(
    idGenre INT AUTO_INCREMENT PRIMARY KEY,
    libelleGenre VARCHAR(50) NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Villes
--
DROP TABLE IF EXISTS Villes;

CREATE TABLE Villes(
    idVille INT AUTO_INCREMENT PRIMARY KEY,
    nomVille VARCHAR(50) NOT NULL,
    codePostal VARCHAR(5),
    idPays VARCHAR(50) NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Adresses
--
DROP TABLE IF EXISTS Adresses;

CREATE TABLE Adresses(
    idAdresse INT AUTO_INCREMENT PRIMARY KEY,
    adresse VARCHAR(150) NOT NULL,
    complAdresse VARCHAR(50),
    idVille INT NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Enfants
--
DROP TABLE IF EXISTS Enfants;

CREATE TABLE Enfants(
    idEnfant INT AUTO_INCREMENT PRIMARY KEY,
    nomEnfant VARCHAR(50) NOT NULL,
    prenomEnfant VARCHAR(50) NOT NULL,
    prctSagesse DECIMAL(5, 2) NOT NULL,
    idGenre INT NOT NULL,
    idVoeu INT NOT NULL,
    idAdresse INT NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Cadeaus
--
DROP TABLE IF EXISTS Cadeaus;

CREATE TABLE Cadeaus(
    idCadeau INT AUTO_INCREMENT PRIMARY KEY,
    designationCadeau VARCHAR(50) NOT NULL,
    idTournee INT NOT NULL,
    idEnfant INT NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Lutins
--
DROP TABLE IF EXISTS Lutins;

CREATE TABLE Lutins(
    idLutin INT AUTO_INCREMENT PRIMARY KEY,
    nomLutin VARCHAR(50) NOT NULL,
    prenomLutin VARCHAR(50) NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Traineaus
--
DROP TABLE IF EXISTS Traineaus;

CREATE TABLE Traineaus(
    idTraineau INT AUTO_INCREMENT PRIMARY KEY,
    tailleTraineau TINYINT NOT NULL,
    dateMES DATE NOT NULL,
    dateDernierEntretien DATE NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Tournees
--
DROP TABLE IF EXISTS Tournees;

CREATE TABLE Tournees(
    idTournee INT AUTO_INCREMENT PRIMARY KEY,
    heureDepart TIME NOT NULL,
    idLutin INT NOT NULL,
    idTraineau INT NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Rennes
--
DROP TABLE IF EXISTS Rennes;

CREATE TABLE Rennes(
    nomRenne VARCHAR(50) PRIMARY KEY,
    dateNaissance DATE NOT NULL,
    idGenre INT NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Supervisions
--
DROP TABLE IF EXISTS Supervisions;

CREATE TABLE Supervisions(
    idSupervision INT AUTO_INCREMENT PRIMARY KEY,
    idLutin INT,
    idTraineau INT,
    dateDebutSprvsion DATE NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Table Affectations
--
DROP TABLE IF EXISTS Affectations;

CREATE TABLE Affectations(
    idAffectation INT AUTO_INCREMENT PRIMARY KEY,
    idTournee INT,
    nomRenne VARCHAR(50)
) ENGINE = InnoDB DEFAULT charset = UTF8;

--
-- Clés Étrangères
--
ALTER TABLE
    Tournees
ADD
    CONSTRAINT FK_Tournees_Lutins FOREIGN KEY(idLutin) REFERENCES Lutins(idLutin),
ADD
    CONSTRAINT FK_Tournees_Traineaus FOREIGN KEY(idTraineau) REFERENCES Traineaus(idTraineau);

ALTER TABLE
    Villes
ADD
    CONSTRAINT FK_Villes_Pays FOREIGN KEY(idPays) REFERENCES Pays(idPays);

ALTER TABLE
    Rennes
ADD
    CONSTRAINT FK_Rennes_Genres FOREIGN KEY(idGenre) REFERENCES Genres(idGenre);

ALTER TABLE
    Adresses
ADD
    CONSTRAINT FK_Adresses_Villes FOREIGN KEY(idVille) REFERENCES Villes(idVille);

ALTER TABLE
    Enfants
ADD
    CONSTRAINT FK_Enfants_Genres FOREIGN KEY(idGenre) REFERENCES Genres(idGenre),
ADD
    CONSTRAINT FK_Enfants_Voeus FOREIGN KEY(idVoeu) REFERENCES Voeus(idVoeu),
ADD
    CONSTRAINT FK_Enfants_Adresses FOREIGN KEY(idAdresse) REFERENCES Adresses(idAdresse);

ALTER TABLE
    Cadeaus
ADD
    CONSTRAINT FK_Cadeaus_Tournees FOREIGN KEY(idTournee) REFERENCES Tournees(idTournee),
ADD
    CONSTRAINT FK_Cadeaus_Enfants FOREIGN KEY(idEnfant) REFERENCES Enfants(idEnfant);

ALTER TABLE
    Supervisions
ADD
    CONSTRAINT FK_Supervisions_Lutins FOREIGN KEY(idLutin) REFERENCES Lutins(idLutin),
ADD
    CONSTRAINT FK_Supervisions_Traineaus FOREIGN KEY(idTraineau) REFERENCES Traineaus(idTraineau);

ALTER TABLE
    Affectations
ADD
    CONSTRAINT FK_Affectations_Tournees FOREIGN KEY(idTournee) REFERENCES Tournees(idTournee),
ADD
    CONSTRAINT FK_Affectations_Rennes FOREIGN KEY(nomRenne) REFERENCES Rennes(nomRenne);