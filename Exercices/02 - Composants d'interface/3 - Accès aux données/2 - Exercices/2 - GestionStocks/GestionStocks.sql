DROP DATABASE IF EXISTS GestionStocks;
CREATE DATABASE GestionStocks;
ALTER DATABASE GestionStocks DEFAULT charset = UTF8;
USE GestionStocks;

--
-- Table TypesProduits
--
DROP TABLE IF EXISTS TypesProduits;
CREATE TABLE TypesProduits(
   IdTypeProduit INT AUTO_INCREMENT PRIMARY KEY,
   LibelleTypeProduit VARCHAR(100)  NOT NULL
) ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table Categories
--
DROP TABLE IF EXISTS Categories;
CREATE TABLE Categories(
   IdCategorie INT AUTO_INCREMENT PRIMARY KEY,
   LibelleCategorie VARCHAR(100)  NOT NULL,
   IdTypeProduit INT NOT NULL
) ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table Articles
--
DROP TABLE IF EXISTS Articles;
CREATE TABLE Articles(
   IdArticle INT AUTO_INCREMENT PRIMARY KEY,
   LibelleArticle VARCHAR(100)  NOT NULL,
   QuantiteStockee INT,
   IdCategorie INT NOT NULL
) ENGINE=InnoDB DEFAULT charset = UTF8;

ALTER TABLE Categories ADD CONSTRAINT FK_Categories_TypesProduits FOREIGN KEY(IdTypeProduit) REFERENCES TypesProduits(IdTypeProduit);
ALTER TABLE Articles ADD CONSTRAINT FK_Articles_Categories FOREIGN KEY(IdCategorie) REFERENCES Categories(IdCategorie);