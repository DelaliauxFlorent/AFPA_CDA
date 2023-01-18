DROP DATABASE IF EXISTS PizzaPadananas;
CREATE DATABASE PizzaPadananas;
ALTER DATABASE PizzaPadananas DEFAULT charset = UTF8;
USE PizzaPadananas;

--
-- Table TypePizzas
--
DROP TABLE IF EXISTS TypePizzas;
CREATE TABLE TypePizzas(
   idTypePizza INT AUTO_INCREMENT PRIMARY KEY,
   nomTypePizza VARCHAR(50)  NOT NULL,
   prixBaseTypePizza DECIMAL(4,2)   NOT NULL,
   imagePizza VARCHAR(50)  NOT NULL,
   actif BOOLEAN DEFAULT 1
) ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table Ingredients
--
DROP TABLE IF EXISTS Ingredients;
CREATE TABLE Ingredients(
   idIngredient INT AUTO_INCREMENT PRIMARY KEY,
   nomIngredient VARCHAR(50)  NOT NULL,
   imageIngredient VARCHAR(50)  NOT NULL,
   actif BOOLEAN DEFAULT 1,
   idTypeIngredient INT NOT NULL
) ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table TypeIngredients
--
DROP TABLE IF EXISTS TypeIngredients;
CREATE TABLE TypeIngredients(
   idTypeIngredient INT AUTO_INCREMENT PRIMARY KEY,
   nomTypeIngredient VARCHAR(50)  NOT NULL,
   prixTypeIngredient DECIMAL(4,2)   NOT NULL
) ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table TaillePizzas
--
DROP TABLE IF EXISTS TaillePizzas;
CREATE TABLE TaillePizzas(
   idTaillePizza INT AUTO_INCREMENT PRIMARY KEY,
   valeurTaillePizza VARCHAR(50) NOT NULL,
   multiplicateurPrixPizza DECIMAL(4,2)   NOT NULL
) ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table Menus
--
DROP TABLE IF EXISTS Menus;
CREATE TABLE Menus(
   idMenu INT AUTO_INCREMENT PRIMARY KEY,
   nomMenu VARCHAR(50)  NOT NULL,
   reductionMenu DECIMAL(4,2)   NOT NULL,
   imageMenu VARCHAR(50)  NOT NULL,
   idTaillePizza INT NOT NULL,
   actif BOOLEAN DEFAULT 1
) ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table Statuts
--
DROP TABLE IF EXISTS Statuts;
CREATE TABLE Statuts(
   idStatut INT AUTO_INCREMENT PRIMARY KEY,
   nomStatut VARCHAR(50)  NOT NULL
) ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table Roles
--
DROP TABLE IF EXISTS Roles;
CREATE TABLE Roles(
   idRole INT AUTO_INCREMENT PRIMARY KEY,
   nomRole VARCHAR(50)  NOT NULL,
   niveauAcreditation INT
) ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table SeuilFidelites
--
DROP TABLE IF EXISTS SeuilFidelites;
CREATE TABLE SeuilFidelites(
   idSeuilFidelite INT AUTO_INCREMENT PRIMARY KEY,
   maxSeuil INT NOT NULL,
   montantFidelite INT NOT NULL
) ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table TypeAccompagnements
--
DROP TABLE IF EXISTS TypeAccompagnements;
CREATE TABLE TypeAccompagnements(
   idTypeAccompagnement INT AUTO_INCREMENT PRIMARY KEY,
   nomTypeAccompagnement VARCHAR(50)  NOT NULL,
   actif BOOLEAN DEFAULT 1
) ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table Pizzas
--
DROP TABLE IF EXISTS Pizzas;
CREATE TABLE Pizzas(
   idPizza INT AUTO_INCREMENT PRIMARY KEY,
   idTaillePizza INT NOT NULL,
   idTypePizza INT NOT NULL,
   actif BOOLEAN DEFAULT 1
) ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table Accompagnements
--
DROP TABLE IF EXISTS Accompagnements;
CREATE TABLE Accompagnements(
   idAccompagnement INT AUTO_INCREMENT PRIMARY KEY,
   nomAccompagnement VARCHAR(50)  NOT NULL,
   prixAccompagnement DECIMAL(4,2)   NOT NULL,
   mesureAccompagnement DECIMAL(4,2)  ,
   imageAccompagnement VARCHAR(50)  NOT NULL,
   idTypeAccompagnement INT NOT NULL,
   actif BOOLEAN DEFAULT 1
) ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table Comptes
--
DROP TABLE IF EXISTS Comptes;
CREATE TABLE Comptes(
   idCompte INT AUTO_INCREMENT PRIMARY KEY,
   identifiant VARCHAR(50)  NOT NULL,
   mdp VARCHAR(50)  NOT NULL,
   nom VARCHAR(50)  NOT NULL,
   prenom VARCHAR(50)  NOT NULL,
   niveauFidelite INT DEFAULT 0,
   idRole INT NOT NULL DEFAULT 3
) ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table Adresses
--
DROP TABLE IF EXISTS Adresses;
CREATE TABLE Adresses(
   idAdresse INT AUTO_INCREMENT PRIMARY KEY,
   Adresse VARCHAR(50)  NOT NULL,
   complementAdresse VARCHAR(100) ,
   cdPost VARCHAR(5)  NOT NULL,
   Ville VARCHAR(50)  NOT NULL,
   idCompte INT NOT NULL
) ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table Commandes
--
DROP TABLE IF EXISTS Commandes;
CREATE TABLE Commandes(
   idCommande INT AUTO_INCREMENT PRIMARY KEY,
   numCommande VARCHAR(50)  NOT NULL,
   dateCommande DATETIME NOT NULL,
   payementCommande BOOLEAN NOT NULL,
   idSeuilFidelite INT DEFAULT 1,
   idCompte INT,
   idStatut INT DEFAULT 1
) ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table Compositions
--
DROP TABLE IF EXISTS Compositions;
CREATE TABLE Compositions(
   idCompositions INT AUTO_INCREMENT PRIMARY KEY,
   idTypePizza INT,
   idIngredient INT
) ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table LignesCommandes
--
DROP TABLE IF EXISTS LignesCommandes;
CREATE TABLE LignesCommandes(
   idLignesCommandes INT AUTO_INCREMENT PRIMARY KEY,
   idAccompagnement INT,
   idMenu INT,
   idCommande INT,
   idPizza INT
) ENGINE=InnoDB DEFAULT charset = UTF8;

--
-- Table ItemsMenus
--
DROP TABLE IF EXISTS ItemsMenus;
CREATE TABLE ItemsMenus(
   idItemsMenus INT AUTO_INCREMENT PRIMARY KEY,
   idTypePizza INT,
   idAccompagnement INT,
   idMenu INT,
   qteItem INT NOT NULL
) ENGINE=InnoDB DEFAULT charset = UTF8;
