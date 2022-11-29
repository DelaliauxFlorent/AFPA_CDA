-- MySQL dump 10.13  Distrib 5.7.36, for Win64 (x86_64)
--
-- Host: localhost    Database: villagegreenv2
-- ------------------------------------------------------
-- Server version	5.7.36

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `villagegreenv2`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `villagegreenv2` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `villagegreenv2`;

--
-- Table structure for table `adresses`
--

DROP TABLE IF EXISTS `adresses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `adresses` (
  `idAdresse` int(11) NOT NULL AUTO_INCREMENT,
  `emailAdresse` varchar(150) DEFAULT NULL,
  `telMobile` varchar(12) DEFAULT NULL,
  `telFixe` varchar(12) DEFAULT NULL,
  `adresse` varchar(50) NOT NULL,
  `province` varchar(50) DEFAULT NULL,
  `complementAdresse` varchar(50) DEFAULT NULL,
  `idVille` int(11) NOT NULL,
  PRIMARY KEY (`idAdresse`),
  KEY `FK_Adresses_Villes` (`idVille`),
  CONSTRAINT `FK_Adresses_Villes` FOREIGN KEY (`idVille`) REFERENCES `villes` (`idVille`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `adresses`
--

LOCK TABLES `adresses` WRITE;
/*!40000 ALTER TABLE `adresses` DISABLE KEYS */;
/*!40000 ALTER TABLE `adresses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `applicationstva`
--

DROP TABLE IF EXISTS `applicationstva`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `applicationstva` (
  `idApplicationTVA` int(11) NOT NULL AUTO_INCREMENT,
  `idProduit` int(11) DEFAULT NULL,
  `idTVA` int(11) DEFAULT NULL,
  `dateTVA` date NOT NULL,
  PRIMARY KEY (`idApplicationTVA`),
  KEY `FK_ApplicationsTVA_Produits` (`idProduit`),
  KEY `FK_ApplicationsTVA_TVAs` (`idTVA`),
  CONSTRAINT `FK_ApplicationsTVA_Produits` FOREIGN KEY (`idProduit`) REFERENCES `produits` (`idProduit`),
  CONSTRAINT `FK_ApplicationsTVA_TVAs` FOREIGN KEY (`idTVA`) REFERENCES `tvas` (`idTVA`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `applicationstva`
--

LOCK TABLES `applicationstva` WRITE;
/*!40000 ALTER TABLE `applicationstva` DISABLE KEYS */;
/*!40000 ALTER TABLE `applicationstva` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `approvisions`
--

DROP TABLE IF EXISTS `approvisions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `approvisions` (
  `idApprovision` int(11) NOT NULL AUTO_INCREMENT,
  `idProduit` int(11) DEFAULT NULL,
  `idFournisseur` int(11) DEFAULT NULL,
  `refFournisseur` varchar(150) NOT NULL,
  PRIMARY KEY (`idApprovision`),
  KEY `FK_Approvisions_Produits` (`idProduit`),
  KEY `FK_Approvisions_Fournisseurs` (`idFournisseur`),
  CONSTRAINT `FK_Approvisions_Fournisseurs` FOREIGN KEY (`idFournisseur`) REFERENCES `fournisseurs` (`idFournisseur`),
  CONSTRAINT `FK_Approvisions_Produits` FOREIGN KEY (`idProduit`) REFERENCES `produits` (`idProduit`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `approvisions`
--

LOCK TABLES `approvisions` WRITE;
/*!40000 ALTER TABLE `approvisions` DISABLE KEYS */;
/*!40000 ALTER TABLE `approvisions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categoriesclients`
--

DROP TABLE IF EXISTS `categoriesclients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `categoriesclients` (
  `idCategorieClient` int(11) NOT NULL AUTO_INCREMENT,
  `libelleCategClient` varchar(150) NOT NULL,
  `infoReglement` varchar(50) NOT NULL,
  `coefCategClient` int(11) NOT NULL,
  PRIMARY KEY (`idCategorieClient`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoriesclients`
--

LOCK TABLES `categoriesclients` WRITE;
/*!40000 ALTER TABLE `categoriesclients` DISABLE KEYS */;
/*!40000 ALTER TABLE `categoriesclients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clients`
--

DROP TABLE IF EXISTS `clients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clients` (
  `idUser` int(11) NOT NULL AUTO_INCREMENT,
  `refClient` varchar(5) NOT NULL,
  `coefClient` int(11) NOT NULL,
  `idAdresse` int(11) NOT NULL,
  `idCategorieClient` int(11) NOT NULL,
  PRIMARY KEY (`idUser`),
  UNIQUE KEY `refClient` (`refClient`),
  KEY `FK_Clients_Adresses` (`idAdresse`),
  KEY `FK_Clients_CategoriesClients` (`idCategorieClient`),
  CONSTRAINT `FK_Clients_Adresses` FOREIGN KEY (`idAdresse`) REFERENCES `adresses` (`idAdresse`),
  CONSTRAINT `FK_Clients_CategoriesClients` FOREIGN KEY (`idCategorieClient`) REFERENCES `categoriesclients` (`idCategorieClient`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

LOCK TABLES `clients` WRITE;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `commandes`
--

DROP TABLE IF EXISTS `commandes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `commandes` (
  `idCommande` int(11) NOT NULL AUTO_INCREMENT,
  `numeroCommande` varchar(10) NOT NULL,
  `dateCommande` date NOT NULL,
  `idUser` int(11) NOT NULL,
  PRIMARY KEY (`idCommande`),
  UNIQUE KEY `numeroCommande` (`numeroCommande`),
  KEY `FK_Commandes_Clients` (`idUser`),
  CONSTRAINT `FK_Commandes_Clients` FOREIGN KEY (`idUser`) REFERENCES `clients` (`idUser`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `commandes`
--

LOCK TABLES `commandes` WRITE;
/*!40000 ALTER TABLE `commandes` DISABLE KEYS */;
/*!40000 ALTER TABLE `commandes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `etatscommande`
--

DROP TABLE IF EXISTS `etatscommande`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `etatscommande` (
  `IdEtatCommande` int(11) NOT NULL AUTO_INCREMENT,
  `libelleEtatCommande` varchar(50) NOT NULL,
  PRIMARY KEY (`IdEtatCommande`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `etatscommande`
--

LOCK TABLES `etatscommande` WRITE;
/*!40000 ALTER TABLE `etatscommande` DISABLE KEYS */;
/*!40000 ALTER TABLE `etatscommande` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fournisseurs`
--

DROP TABLE IF EXISTS `fournisseurs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fournisseurs` (
  `idFournisseur` int(11) NOT NULL AUTO_INCREMENT,
  `nomFournisseur` varchar(150) NOT NULL,
  PRIMARY KEY (`idFournisseur`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fournisseurs`
--

LOCK TABLES `fournisseurs` WRITE;
/*!40000 ALTER TABLE `fournisseurs` DISABLE KEYS */;
/*!40000 ALTER TABLE `fournisseurs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `histoetatcom`
--

DROP TABLE IF EXISTS `histoetatcom`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `histoetatcom` (
  `idHistoEtatCom` int(11) NOT NULL AUTO_INCREMENT,
  `idCommande` int(11) DEFAULT NULL,
  `IdEtatCommande` int(11) DEFAULT NULL,
  `dateEtatCommande` date NOT NULL,
  PRIMARY KEY (`idHistoEtatCom`),
  KEY `FK_HistoEtatCom_Commandes` (`idCommande`),
  KEY `FK_HistoEtatCom_EtatsCommande` (`IdEtatCommande`),
  CONSTRAINT `FK_HistoEtatCom_Commandes` FOREIGN KEY (`idCommande`) REFERENCES `commandes` (`idCommande`),
  CONSTRAINT `FK_HistoEtatCom_EtatsCommande` FOREIGN KEY (`IdEtatCommande`) REFERENCES `etatscommande` (`IdEtatCommande`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `histoetatcom`
--

LOCK TABLES `histoetatcom` WRITE;
/*!40000 ALTER TABLE `histoetatcom` DISABLE KEYS */;
/*!40000 ALTER TABLE `histoetatcom` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lignescommande`
--

DROP TABLE IF EXISTS `lignescommande`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `lignescommande` (
  `idLigneCommande` int(11) NOT NULL AUTO_INCREMENT,
  `idProduit` int(11) DEFAULT NULL,
  `idCommande` int(11) DEFAULT NULL,
  `quantiteProduit` int(11) NOT NULL,
  PRIMARY KEY (`idLigneCommande`),
  KEY `FK_LignesCommande_Produits` (`idProduit`),
  KEY `FK_LignesCommande_Commandes` (`idCommande`),
  CONSTRAINT `FK_LignesCommande_Commandes` FOREIGN KEY (`idCommande`) REFERENCES `commandes` (`idCommande`),
  CONSTRAINT `FK_LignesCommande_Produits` FOREIGN KEY (`idProduit`) REFERENCES `produits` (`idProduit`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lignescommande`
--

LOCK TABLES `lignescommande` WRITE;
/*!40000 ALTER TABLE `lignescommande` DISABLE KEYS */;
/*!40000 ALTER TABLE `lignescommande` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `livraisons`
--

DROP TABLE IF EXISTS `livraisons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `livraisons` (
  `idLivraison` int(11) NOT NULL AUTO_INCREMENT,
  `idAdresse` int(11) DEFAULT NULL,
  `idCommande` int(11) DEFAULT NULL,
  `quantiteLivraison` int(11) NOT NULL,
  `dateLivraison` date NOT NULL,
  PRIMARY KEY (`idLivraison`),
  KEY `FK_Livraisons_Adresses` (`idAdresse`),
  KEY `FK_Livraisons_Commandes` (`idCommande`),
  CONSTRAINT `FK_Livraisons_Adresses` FOREIGN KEY (`idAdresse`) REFERENCES `adresses` (`idAdresse`),
  CONSTRAINT `FK_Livraisons_Commandes` FOREIGN KEY (`idCommande`) REFERENCES `commandes` (`idCommande`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `livraisons`
--

LOCK TABLES `livraisons` WRITE;
/*!40000 ALTER TABLE `livraisons` DISABLE KEYS */;
/*!40000 ALTER TABLE `livraisons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `paiements`
--

DROP TABLE IF EXISTS `paiements`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `paiements` (
  `idPaiement` int(11) NOT NULL AUTO_INCREMENT,
  `idReglement` int(11) DEFAULT NULL,
  `idCommande` int(11) DEFAULT NULL,
  `datePaiement` date NOT NULL,
  `montantPaiement` decimal(19,4) NOT NULL,
  PRIMARY KEY (`idPaiement`),
  KEY `FK_Paiements_Reglements` (`idReglement`),
  KEY `FK_PAiements_Commandes` (`idCommande`),
  CONSTRAINT `FK_PAiements_Commandes` FOREIGN KEY (`idCommande`) REFERENCES `commandes` (`idCommande`),
  CONSTRAINT `FK_Paiements_Reglements` FOREIGN KEY (`idReglement`) REFERENCES `reglements` (`idReglement`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paiements`
--

LOCK TABLES `paiements` WRITE;
/*!40000 ALTER TABLE `paiements` DISABLE KEYS */;
/*!40000 ALTER TABLE `paiements` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pays`
--

DROP TABLE IF EXISTS `pays`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pays` (
  `idPays` int(11) NOT NULL AUTO_INCREMENT,
  `nomPays` varchar(50) NOT NULL,
  PRIMARY KEY (`idPays`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pays`
--

LOCK TABLES `pays` WRITE;
/*!40000 ALTER TABLE `pays` DISABLE KEYS */;
/*!40000 ALTER TABLE `pays` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `produits`
--

DROP TABLE IF EXISTS `produits`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `produits` (
  `idProduit` int(11) NOT NULL AUTO_INCREMENT,
  `libelleProduit` varchar(150) NOT NULL,
  `descProduit` text,
  `refProduit` varchar(5) NOT NULL,
  `prixHorsTaxe` decimal(19,4) NOT NULL,
  `photo` varchar(150) NOT NULL,
  `stock` int(11) NOT NULL,
  `idRubrique` int(11) NOT NULL,
  PRIMARY KEY (`idProduit`),
  KEY `FK_Produits_Rubriques` (`idRubrique`),
  CONSTRAINT `FK_Produits_Rubriques` FOREIGN KEY (`idRubrique`) REFERENCES `rubriques` (`idRubrique`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `produits`
--

LOCK TABLES `produits` WRITE;
/*!40000 ALTER TABLE `produits` DISABLE KEYS */;
/*!40000 ALTER TABLE `produits` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reglements`
--

DROP TABLE IF EXISTS `reglements`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reglements` (
  `idReglement` int(11) NOT NULL AUTO_INCREMENT,
  `typePaiement` varchar(50) NOT NULL,
  PRIMARY KEY (`idReglement`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reglements`
--

LOCK TABLES `reglements` WRITE;
/*!40000 ALTER TABLE `reglements` DISABLE KEYS */;
/*!40000 ALTER TABLE `reglements` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `roles` (
  `idRole` int(11) NOT NULL AUTO_INCREMENT,
  `libelleRole` varchar(50) NOT NULL,
  PRIMARY KEY (`idRole`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rubriques`
--

DROP TABLE IF EXISTS `rubriques`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rubriques` (
  `idRubrique` int(11) NOT NULL AUTO_INCREMENT,
  `libelleRubrique` varchar(150) NOT NULL,
  `idRubriqueParente` int(11) DEFAULT NULL,
  PRIMARY KEY (`idRubrique`),
  KEY `FK_Rubriques_Selfs` (`idRubriqueParente`),
  CONSTRAINT `FK_Rubriques_Selfs` FOREIGN KEY (`idRubriqueParente`) REFERENCES `rubriques` (`idRubrique`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rubriques`
--

LOCK TABLES `rubriques` WRITE;
/*!40000 ALTER TABLE `rubriques` DISABLE KEYS */;
/*!40000 ALTER TABLE `rubriques` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tvas`
--

DROP TABLE IF EXISTS `tvas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tvas` (
  `idTVA` int(11) NOT NULL AUTO_INCREMENT,
  `tauxTVA` int(11) NOT NULL,
  PRIMARY KEY (`idTVA`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tvas`
--

LOCK TABLES `tvas` WRITE;
/*!40000 ALTER TABLE `tvas` DISABLE KEYS */;
/*!40000 ALTER TABLE `tvas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `utilisateurs`
--

DROP TABLE IF EXISTS `utilisateurs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `utilisateurs` (
  `idUser` int(11) NOT NULL AUTO_INCREMENT,
  `nomUser` varchar(150) DEFAULT NULL,
  `prenomUser` varchar(150) DEFAULT NULL,
  `emailUser` varchar(150) NOT NULL,
  `mdpUser` varchar(50) NOT NULL,
  `idRole` int(11) NOT NULL,
  PRIMARY KEY (`idUser`),
  UNIQUE KEY `emailUser` (`emailUser`),
  KEY `FK_Utilisateurs_Roles` (`idRole`),
  CONSTRAINT `FK_Utilisateurs_Roles` FOREIGN KEY (`idRole`) REFERENCES `roles` (`idRole`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utilisateurs`
--

LOCK TABLES `utilisateurs` WRITE;
/*!40000 ALTER TABLE `utilisateurs` DISABLE KEYS */;
/*!40000 ALTER TABLE `utilisateurs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `villes`
--

DROP TABLE IF EXISTS `villes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `villes` (
  `idVille` int(11) NOT NULL AUTO_INCREMENT,
  `libelleVille` varchar(150) NOT NULL,
  `codePostal` varchar(6) NOT NULL,
  `idPays` int(11) NOT NULL,
  PRIMARY KEY (`idVille`),
  KEY `FK_Villes_Pays` (`idPays`),
  CONSTRAINT `FK_Villes_Pays` FOREIGN KEY (`idPays`) REFERENCES `pays` (`idPays`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `villes`
--

LOCK TABLES `villes` WRITE;
/*!40000 ALTER TABLE `villes` DISABLE KEYS */;
/*!40000 ALTER TABLE `villes` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-11-29 18:23:10
