DROP DATABASE IF EXISTS stagiaires_afpa;

CREATE DATABASE stagiaires_afpa DEFAULT CHARACTER SET utf8;

USE stagiaires_afpa;

--
-- Table Matieres
--
DROP TABLE IF EXISTS Matieres;

CREATE TABLE Matieres(
    idMatiere INT AUTO_INCREMENT PRIMARY KEY,
    nomMatiere VARCHAR(25) NOT NULL
) ENGINE=InnoDB;

--
-- Table Hebergements
--
DROP TABLE IF EXISTS Hebergements;

CREATE TABLE Hebergements(
    idHebergement INT AUTO_INCREMENT PRIMARY KEY,
    libelleHebergement VARCHAR(50) NOT NULL
) ENGINE=InnoDB;

--
-- Table Formateurs
--
DROP TABLE IF EXISTS Formateurs;

CREATE TABLE Formateurs(
    idFormateur INT AUTO_INCREMENT PRIMARY KEY,
    nomFormateur VARCHAR(25) NOT NULL,
    prenomFormateur VARCHAR(25) NOT NULL
) ENGINE=InnoDB;

--
-- Table Groupes
--
DROP TABLE IF EXISTS Groupes;

CREATE TABLE Groupes(
    idGroupe INT AUTO_INCREMENT PRIMARY KEY,
    libelleGroupe VARCHAR(50) NOT NULL
) ENGINE=InnoDB;

--
-- Table Formations
--
DROP TABLE IF EXISTS Formations;

CREATE TABLE Formations(
    idFormation INT AUTO_INCREMENT PRIMARY KEY,
    libelleFormation VARCHAR(50) NOT NULL,
    idGroupe INT NOT NULL
) ENGINE=InnoDB;

--
-- Table Stagiaires
--
DROP TABLE IF EXISTS Stagiaires;

CREATE TABLE Stagiaires(
    idStagiaire INT AUTO_INCREMENT PRIMARY KEY,
    nomStagiaire VARCHAR(25) NOT NULL,
    prenomStagiaire VARCHAR(25) NOT NULL,
    adresseStagiaire VARCHAR(50) NOT NULL,
    ville VARCHAR(25) NOT NULL,
    codePostal INT NOT NULL,
    telStagiaire VARCHAR(14) NOT NULL,
    dateEntree DATE NOT NULL,
    genreStagiaire VARCHAR(1) NOT NULL,
    dateNaissance DATE NOT NULL,
    idFormation INT NOT NULL,
    idFormateur INT NOT NULL,
    idHebergement INT NOT NULL
) ENGINE=InnoDB;

--
-- Table suivis
--
DROP TABLE IF EXISTS Suivis;

CREATE TABLE Suivis(
    idSuivis INT AUTO_INCREMENT PRIMARY KEY,
    idStagiaire INT,
    idMatiere INT,
    note FLOAT
) ENGINE=InnoDB;

--
-- Table Animations
--
DROP TABLE IF EXISTS Animations;

CREATE TABLE Animations(
    idAnimation INT AUTO_INCREMENT PRIMARY KEY,
    idFormateur INT,
    idFormation INT
) ENGINE=InnoDB;

--
-- Table Constitutions
--
DROP TABLE IF EXISTS Constitutions;

CREATE TABLE Constitutions(
    idConstitution INT AUTO_INCREMENT PRIMARY KEY,
    idMatiere INT,
    idFormation INT
) ENGINE=InnoDB;

--
-- Ajout des clés étrangères
--
ALTER TABLE
    Formations
ADD
    CONSTRAINT FK_Formations_Groupes FOREIGN KEY(idGroupe) REFERENCES Groupes(idGroupe);

ALTER TABLE
    Stagiaires
ADD
    CONSTRAINT FK_Stagiaires_Formations FOREIGN KEY(idFormation) REFERENCES Formations(idFormation),
ADD
    CONSTRAINT FK_Stagiaires_Formateurs FOREIGN KEY(idFormateur) REFERENCES Formateurs(idFormateur),
ADD
    CONSTRAINT FK_Stagiaires_Hebergements FOREIGN KEY(idHebergement) REFERENCES Hebergements(idHebergement);

ALTER TABLE
    Suivis
ADD
    CONSTRAINT FK_Suivis_Stagiaires FOREIGN KEY(idStagiaire) REFERENCES Stagiaires(idStagiaire),
ADD
    CONSTRAINT FK_Suivis_Matieres FOREIGN KEY(idMatiere) REFERENCES Matieres(idMatiere);

ALTER TABLE
    Animations
ADD
    CONSTRAINT FK_Animations_Formateurs FOREIGN KEY(idFormateur) REFERENCES Formateurs(idFormateur),
ADD
    CONSTRAINT FK_Animations_Formations FOREIGN KEY(idFormation) REFERENCES Formations(idFormation);

ALTER TABLE
    Constitutions
ADD
    CONSTRAINT FK_Constitutions_Matieres FOREIGN KEY(idMatiere) REFERENCES Matieres(idMatiere),
ADD
    CONSTRAINT FK_Constitutions_Formations FOREIGN KEY(idFormation) REFERENCES Formations(idFormation);