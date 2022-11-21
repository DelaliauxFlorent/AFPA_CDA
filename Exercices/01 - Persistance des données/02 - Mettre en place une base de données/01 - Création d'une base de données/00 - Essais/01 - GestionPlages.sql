CREATE DATABASE IF NOT EXISTS GestionPlages;
USE GestionPlages;

DROP TABLE IF EXISTS NatureTerrains;
CREATE TABLE NatureTerrains(
   idNatureTerrain INT AUTO_INCREMENT PRIMARY KEY,
   nomNatureTerrain VARCHAR(50)  NOT NULL
);

DROP TABLE IF EXISTS Departements;
CREATE TABLE Departements(
   idDep VARCHAR(50) PRIMARY KEY,
   nomDep VARCHAR(50)
);

DROP TABLE IF EXISTS Villes;
CREATE TABLE Villes(
   idVille INT AUTO_INCREMENT PRIMARY KEY,
   nomVille VARCHAR(50)  NOT NULL,
   codePostal SMALLINT NOT NULL,
   nbAnTouri SMALLINT NOT NULL,
   idDep VARCHAR(50)  NOT NULL
);

DROP TABLE IF EXISTS Plages;
CREATE TABLE Plages(
   idPlage INT AUTO_INCREMENT PRIMARY KEY,
   nomPlage VARCHAR(50)  NOT NULL,
   longPlage DECIMAL(6,3)   NOT NULL,
   idVille INT NOT NULL
);

DROP TABLE IF EXISTS compose;
CREATE TABLE compose(
   idPlage INT,
   idNatureTerrain INT,
   PRIMARY KEY(idPlage, idNatureTerrain)
);
