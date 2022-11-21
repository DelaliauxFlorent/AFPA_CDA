DROP DATABASE IF EXISTS boeufs_carottes;

CREATE DATABASE boeufs_carottes DEFAULT CHARACTER SET utf8;

USE boeufs_carottes;

--
-- Table Blames
--
DROP TABLE IF EXISTS Blames;

CREATE TABLE Blames(
    idBlame INT AUTO_INCREMENT PRIMARY KEY,
    nomBlame VARCHAR(50)
) ENGINE = InnoB;

--
-- Table Grades
--
DROP TABLE IF EXISTS Grades;

CREATE TABLE Grades(
    idGrade INT AUTO_INCREMENT PRIMARY KEY,
    nomGrade VARCHAR(50)
) ENGINE = InnoB;

--
-- Table Villes
--
DROP TABLE IF EXISTS Villes;

CREATE TABLE Villes(
    idVille INT AUTO_INCREMENT PRIMARY KEY,
    nomVille VARCHAR(50)
) ENGINE = InnoB;

--
-- Table Commissariats
--
DROP TABLE IF EXISTS Commissariats;

CREATE TABLE Commissariats(
    idCommissariat INT AUTO_INCREMENT PRIMARY KEY,
    nomCommissariat VARCHAR(50)
) ENGINE = InnoB;

--
-- Table Services
--
DROP TABLE IF EXISTS Services;

CREATE TABLE Services(
    idService INT AUTO_INCREMENT PRIMARY KEY,
    nomService VARCHAR(50)
) ENGINE = InnoB;

--
-- Table Policiers
--
DROP TABLE IF EXISTS Policiers;

CREATE TABLE Policiers(
    idPolicier INT AUTO_INCREMENT PRIMARY KEY,
    nomPolicier VARCHAR(50),
    prenomPolicier VARCHAR(50) NOT NULL,
    matriculePolicier VARCHAR(50) NOT NULL UNIQUE,
    idGrade INT NOT NULL
) ENGINE = InnoB;

--
-- Table Localisation
--
DROP TABLE IF EXISTS Localisations;

CREATE TABLE Localisations(
    idLocalisation INT AUTO_INCREMENT PRIMARY KEY,
    idVille INT,
    idCommissariat INT
) ENGINE = InnoB;

--
-- Table Affectation
--
DROP TABLE IF EXISTS Affectations;

CREATE TABLE Affectations(
    idAffectation INT AUTO_INCREMENT PRIMARY KEY,
    idCommissariat INT,
    idService INT,
    idPolicier INT,
    dateAffectation DATE NOT NULL
) ENGINE = InnoB;

--
-- Table Punition
--
DROP TABLE IF EXISTS Punitions;

CREATE TABLE Punitions(
    idPunition INT AUTO_INCREMENT PRIMARY KEY,
    idBlame INT,
    idPolicier INT,
    dateBlame DATE
) ENGINE = InnoB;

--
-- constraintes clés étrangères
--
ALTER TABLE
    Policiers
ADD
    CONSTRAINT FK_Policiers_Grades FOREIGN KEY(idGrade) REFERENCES Grades(idGrade);

ALTER TABLE
    Localisations
ADD
    CONSTRAINT FK_Localisations_Villes FOREIGN KEY(idVille) REFERENCES Villes(idVille),
ADD
    CONSTRAINT FK_Localisations_Commissariats FOREIGN KEY(idCommissariat) REFERENCES Commissariats(idCommissariat);

ALTER TABLE
    Affectations
ADD
    CONSTRAINT FK_Affectations_Commissariats FOREIGN KEY(idCommissariat) REFERENCES Commissariats(idCommissariat),
ADD
    CONSTRAINT FK_Affectations_Services FOREIGN KEY(idService) REFERENCES Services(idService);

ALTER TABLE
    Affectations
ADD
    CONSTRAINT FK_Affectations_Policiers FOREIGN KEY(idPolicier) REFERENCES Policiers(idPolicier);

ALTER TABLE
    Punitions
ADD
    CONSTRAINT FK_Punitions_Policiers FOREIGN KEY(idPolicier) REFERENCES Policiers(idPolicier),
ADD
    CONSTRAINT FK_Punitions_Blames FOREIGN KEY(idBlame) REFERENCES Blames(idBlame);

    