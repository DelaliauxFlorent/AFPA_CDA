DROP DATABASE IF EXISTS VisualisationRelations;
CREATE DATABASE VisualisationRelations;
ALTER DATABASE VisualisationRelations DEFAULT charset = UTF8;
USE VisualisationRelations;

--
-- Table Persons
--
DROP TABLE IF EXISTS Persons;
CREATE TABLE Persons(
   IdPerson INT AUTO_INCREMENT PRIMARY KEY,
   NamePerson VARCHAR(50)  NOT NULL,
   SurnamePerson VARCHAR(50)  NOT NULL
) ENGINE=InnoDB DEFAULT charset = UTF8;

INSERT INTO Persons(NamePerson, SurnamePerson) Values ("James","Bond");
INSERT INTO Persons(NamePerson, SurnamePerson) Values ("Titi","Titi");
INSERT INTO Persons(NamePerson, SurnamePerson) Values ("Tata","Toto");
INSERT INTO Persons(NamePerson, SurnamePerson) Values ("James","West");

--
-- Table Cities
--
DROP TABLE IF EXISTS Cities;
CREATE TABLE Cities(
   IdCity INT AUTO_INCREMENT PRIMARY KEY,
   NameCity VARCHAR(50)  NOT NULL,
   IdCountry INT NOT NULL
) ENGINE=InnoDB DEFAULT charset = UTF8;

INSERT INTO Cities (NameCity, IdCountry) VALUES ("Paris", 1);
INSERT INTO Cities (NameCity, IdCountry) VALUES ("Dunkerque", 1);
INSERT INTO Cities (NameCity, IdCountry) VALUES ("NewYork", 4);
INSERT INTO Cities (NameCity, IdCountry) VALUES ("Londres",3);
INSERT INTO Cities (NameCity, IdCountry) VALUES ("Rome", 5);
INSERT INTO Cities (NameCity, IdCountry) VALUES ("Bruxelle", 2);

--
-- Table Countries
--
DROP TABLE IF EXISTS Countries;
CREATE TABLE Countries(
   IdCountry INT AUTO_INCREMENT PRIMARY KEY,
   NameCountry VARCHAR(50)  NOT NULL
) ENGINE=InnoDB DEFAULT charset = UTF8;

INSERT INTO Countries(IdCountry, NameCountry) Values(1,"France");
INSERT INTO Countries(IdCountry, NameCountry) Values(2,"Belgique");
INSERT INTO Countries(IdCountry, NameCountry) Values(3,"Angleterre");
INSERT INTO Countries(IdCountry, NameCountry) Values(4,"USA");
INSERT INTO Countries(IdCountry, NameCountry) Values(5,"Italie");

--
-- Table Products
--
DROP TABLE IF EXISTS Products;
CREATE TABLE Products(
   IdProduct INT AUTO_INCREMENT PRIMARY KEY,
   NameProduct VARCHAR(50)  NOT NULL,
   PriceProduct INT NOT NULL
) ENGINE=InnoDB DEFAULT charset = UTF8;

INSERT INTO Products(IdProduct, NameProduct, PriceProduct) VALUES (1, "Stylo", 2);
INSERT INTO Products(IdProduct, NameProduct, PriceProduct) VALUES (2, "Ramette de Papier", 5);
INSERT INTO Products(IdProduct, NameProduct, PriceProduct) VALUES (3, "Classeur", 3.5);
INSERT INTO Products(IdProduct, NameProduct, PriceProduct) VALUES (4, "Cahier", 3);
INSERT INTO Products(IdProduct, NameProduct, PriceProduct) VALUES (5, "Calculatrice", 20);

--
-- Table Commands
--
DROP TABLE IF EXISTS Commands;
CREATE TABLE Commands(
   IdCommand INT AUTO_INCREMENT PRIMARY KEY,
   DeliveryAddressCommand VARCHAR(50)  NOT NULL
) ENGINE=InnoDB DEFAULT charset = UTF8;

INSERT INTO Commands(IdCommand, DeliveryAddressCommand) VALUES (1, "X1 Rue XXXX 59XXX XXXXXX");
INSERT INTO Commands(IdCommand, DeliveryAddressCommand) VALUES (2, "X2 Rue XXXX 59XXX XXXXXX");
INSERT INTO Commands(IdCommand, DeliveryAddressCommand) VALUES (3, "X3 Rue XXXX 59XXX XXXXXX");

--
-- Table Contents
--
DROP TABLE IF EXISTS Contents;
CREATE TABLE Contents(
   IdProduct INT NOT NULL,
   IdCommand INT NOT NULL,
   QuantityContent INT NOT NULL,
   PRIMARY KEY(IdProduct, IdCommand)
) ENGINE=InnoDB DEFAULT charset = UTF8;

INSERT INTO Contents(IdProduct, QuantityContent, IdCommand) Values (1, 5, 1);
INSERT INTO Contents(IdProduct, QuantityContent, IdCommand) Values (3, 1, 1);
INSERT INTO Contents(IdProduct, QuantityContent, IdCommand) Values (2, 1, 2);
INSERT INTO Contents(IdProduct, QuantityContent, IdCommand) Values (1, 30, 2);
INSERT INTO Contents(IdProduct, QuantityContent, IdCommand) Values (5, 1, 3);
INSERT INTO Contents(IdProduct, QuantityContent, IdCommand) Values (4, 2, 3);

--
-- Foreign Keys
--
ALTER TABLE Cities ADD CONSTRAINT FK_Cities_Countries FOREIGN KEY (IdCountry) REFERENCES Countries(IdCountry);
ALTER TABLE Contents ADD CONSTRAINT FK_Contents_Products FOREIGN KEY (IdProduct) REFERENCES Products(IdProduct);
ALTER TABLE Contents ADD CONSTRAINT FK_Contents_Commands FOREIGN KEY (IdCommand) REFERENCES Commands(IdCommand);
