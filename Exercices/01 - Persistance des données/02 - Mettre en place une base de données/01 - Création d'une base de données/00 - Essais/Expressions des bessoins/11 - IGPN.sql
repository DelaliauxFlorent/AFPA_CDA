CREATE DATABASE IF NOT EXISTS boeufs_carottes;
USE boeufs_carottes;

CREATE TABLE Blames(
   idBlame COUNTER,
   nomBlame VARCHAR(50),
   PRIMARY KEY(idBlame)
);

CREATE TABLE Grades(
   idGrade COUNTER,
   nomGrade VARCHAR(50),
   PRIMARY KEY(idGrade)
);

CREATE TABLE Villes(
   idVille COUNTER,
   nomVille VARCHAR(50),
   PRIMARY KEY(idVille)
);

CREATE TABLE Commissariats(
   idCommissariat COUNTER,
   nomCommissariat VARCHAR(50),
   PRIMARY KEY(idCommissariat)
);

CREATE TABLE Services(
   idService COUNTER,
   nomService VARCHAR(50),
   PRIMARY KEY(idService)
);

CREATE TABLE Policiers(
   idPolicier COUNTER,
   nomPolicier VARCHAR(50),
   prenomPolicier VARCHAR(50) NOT NULL,
   matriculePolicier VARCHAR(50) NOT NULL,
   idGrade INT NOT NULL,
   PRIMARY KEY(idPolicier),
   UNIQUE(matriculePolicier),
   FOREIGN KEY(idGrade) REFERENCES Grades(idGrade)
);

CREATE TABLE Héberge(
   idVille INT,
   idCommissariat INT,
   PRIMARY KEY(idVille, idCommissariat),
   FOREIGN KEY(idVille) REFERENCES Villes(idVille),
   FOREIGN KEY(idCommissariat) REFERENCES Commissariats(idCommissariat)
);

CREATE TABLE Affecté(
   idCommissariat INT,
   idService INT,
   idPolicier INT,
   dateAffectation DATE NOT NULL,
   PRIMARY KEY(idCommissariat, idService, idPolicier),
   FOREIGN KEY(idCommissariat) REFERENCES Commissariats(idCommissariat),
   FOREIGN KEY(idService) REFERENCES Services(idService),
   FOREIGN KEY(idPolicier) REFERENCES Policiers(idPolicier)
);

CREATE TABLE Obtenu(
   idBlame INT,
   idPolicier INT,
   dateBlame DATE,
   PRIMARY KEY(idBlame, idPolicier),
   FOREIGN KEY(idBlame) REFERENCES Blames(idBlame),
   FOREIGN KEY(idPolicier) REFERENCES Policiers(idPolicier)
);
