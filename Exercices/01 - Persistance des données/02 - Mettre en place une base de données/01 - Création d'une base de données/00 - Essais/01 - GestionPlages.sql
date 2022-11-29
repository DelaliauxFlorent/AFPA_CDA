DROP DATABASE IF EXISTS GestionPlages;

CREATE DATABASE GestionPlages DEFAULT CHARACTER SET utf8;

USE GestionPlages;

DROP TABLE IF EXISTS NatureTerrains;

CREATE TABLE NatureTerrains(
   idNatureTerrain INT AUTO_INCREMENT PRIMARY KEY,
   nomNatureTerrain VARCHAR(50) NOT NULL
);

DROP TABLE IF EXISTS Departements;

CREATE TABLE Departements(
   idDep VARCHAR(50) PRIMARY KEY,
   nomDep VARCHAR(50)
);

DROP TABLE IF EXISTS Villes;

CREATE TABLE Villes(
   idVille INT AUTO_INCREMENT PRIMARY KEY,
   nomVille VARCHAR(50) NOT NULL,
   codePostal SMALLINT NOT NULL,
   nbAnTouri SMALLINT NOT NULL,
   idDep VARCHAR(50) NOT NULL
);

DROP TABLE IF EXISTS Plages;

CREATE TABLE Plages(
   idPlage INT AUTO_INCREMENT PRIMARY KEY,
   nomPlage VARCHAR(50) NOT NULL,
   longPlage DECIMAL(6, 3) NOT NULL,
   idVille INT NOT NULL
);

DROP TABLE IF EXISTS Compositions;

CREATE TABLE Compositions(
   idComposition INT AUTO_INCREMENT PRIMARY KEY,
   idPlage INT,
   idNatureTerrain INT
);

--
-- constraintes clés étrangères
--
ALTER TABLE
   Villes
ADD
   CONSTRAINT FK_Villes_Departements FOREIGN KEY(idDep) REFERENCES Departements(idDep);

ALTER TABLE
   Plages
ADD
   CONSTRAINT FK_Plages_Villes FOREIGN KEY(idVille) REFERENCES Villes(idVille);

ALTER TABLE
   Compositions
ADD
   CONSTRAINT FK_Compositions_Plages FOREIGN KEY(idPlage) REFERENCES Plages(idPlage),
ADD
   CONSTRAINT FK_Compositions_NatureTerrains FOREIGN KEY(idNatureTerrain) REFERENCES NatureTerrains(idNatureTerrain);