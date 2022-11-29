DROP DATABASE IF EXISTS gestion_logements;

CREATE DATABASE gestion_logements DEFAULT CHARACTER SET utf8;

USE gestion_logements;

DROP TABLE IF EXISTS Communes;

CREATE TABLE Communes(
    idCommune INT AUTO_INCREMENT PRIMARY KEY,
    nomCommune VARCHAR(45) NOT NULL,
    distanceAgence DECIMAL(5, 3) NOT NULL,
    nombreHabitant INT NOT NULL
);

DROP TABLE IF EXISTS Individus;

CREATE TABLE Individus(
    idIndividu INT AUTO_INCREMENT PRIMARY KEY,
    nomIndividu VARCHAR(35) NOT NULL,
    prenomIndividu VARCHAR(30) NOT NULL,
    dateNaissanceIndividu DATE NOT NULL,
    telephoneIndividu VARCHAR(12) NOT NULL
);

DROP TABLE IF EXISTS Quartiers;

CREATE TABLE Quartiers(
    idQuartier INT AUTO_INCREMENT PRIMARY KEY,
    libelleQuartier VARCHAR(35) NOT NULL,
    idCommune INT NOT NULL
);

DROP TABLE IF EXISTS TypesLogements;

CREATE TABLE TypesLogements(
    idTypeLogement INT AUTO_INCREMENT PRIMARY KEY,
    libelleTypeLogement VARCHAR(25) NOT NULL,
    chargesForfaitairesLogement DECIMAL(19, 4) NOT NULL
);

DROP TABLE IF EXISTS Logements;

CREATE TABLE Logements(
    idLogement INT AUTO_INCREMENT PRIMARY KEY,
    numeroLogement VARCHAR(5) NOT NULL,
    rueLogement VARCHAR(60) NOT NULL,
    superficieLogement INT NOT NULL,
    loyerLogement DECIMAL(19, 4) NOT NULL,
    idTypeLogement INT NOT NULL,
    idQuartier INT NOT NULL
);

DROP TABLE IF EXISTS Possessions;

CREATE TABLE Possessions(
    idPossession INT AUTO_INCREMENT PRIMARY KEY,
    idIndividu INT,
    idLogement INT
);

--
-- constraintes clés étrangères
--
ALTER TABLE
    Quartiers
ADD
    CONSTRAINT FK_Quartiers_Communes FOREIGN KEY(idCommune) REFERENCES Communes(idCommune);

ALTER TABLE
    Logements
ADD
    CONSTRAINT FK_Logements_TypesLogements FOREIGN KEY(idTypeLogement) REFERENCES TypesLogements(idTypeLogement),
ADD
    CONSTRAINT FK_Logements_Quartiers FOREIGN KEY(idQuartier) REFERENCES Quartiers(idQuartier);

ALTER TABLE
    Possessions
ADD
    CONSTRAINT FK_Possessions_Individus FOREIGN KEY(idIndividu) REFERENCES Individus(idIndividu),
ADD
    CONSTRAINT FK_Possessions_Logements FOREIGN KEY(idLogement) REFERENCES Logements(idLogement);