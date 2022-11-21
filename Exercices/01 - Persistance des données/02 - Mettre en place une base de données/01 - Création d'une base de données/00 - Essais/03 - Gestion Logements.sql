CREATE DATABASE IF NOT EXISTS gestion_logements;
USE gestion_logements;

DROP TABLE IF EXISTS Communes;
CREATE TABLE Communes(
   idCommune INT AUTO_INCREMENT PRIMARY KEY,
   nomCommune VARCHAR(45) NOT NULL,
   distanceAgence DECIMAL(5,3) NOT NULL,
   nombreHabitant INT NOT NULL
);

DROP TABLE IF EXISTS Individus;
CREATE TABLE Individus(
   idIndividu INT AUTO_INCREMENT PRIMARY KEY,
   nomIndividu VARCHAR(35)  NOT NULL,
   prenomIndividu VARCHAR(30)  NOT NULL,
   dateNaissanceIndividu DATE NOT NULL,
   telephoneIndividu VARCHAR(12)  NOT NULL
);

DROP TABLE IF EXISTS Quartiers;
CREATE TABLE Quartiers(
   idQuartier INT AUTO_INCREMENT PRIMARY KEY,
   libelleQuartier VARCHAR(35)  NOT NULL,
   idCommune INT NOT NULL
);

DROP TABLE IF EXISTS TypesLogements;
CREATE TABLE TypesLogements(
   idTypeLogement INT AUTO_INCREMENT PRIMARY KEY,
   libelleTypeLogement VARCHAR(25)  NOT NULL,
   chargesForfaitairesLogement DECIMAL(19,4) NOT NULL
);

DROP TABLE IF EXISTS Logements;
CREATE TABLE Logements(
   idLogements INT AUTO_INCREMENT PRIMARY KEY,
   numeroLogement VARCHAR(5)  NOT NULL,
   rueLogement VARCHAR(60)  NOT NULL,
   superficieLogement INT NOT NULL,
   loyerLogement DECIMAL(19,4) NOT NULL,
   idTypeLogement INT NOT NULL,
   idQuartier INT NOT NULL
);

DROP TABLE IF EXISTS achete;
CREATE TABLE achete(
   idIndividu INT,
   idLogements INT,
   PRIMARY KEY(idIndividu, idLogements)
);
