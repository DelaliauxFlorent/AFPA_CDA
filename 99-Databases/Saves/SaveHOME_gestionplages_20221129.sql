-- MySQL dump 10.13  Distrib 5.7.36, for Win64 (x86_64)
--
-- Host: localhost    Database: gestionplages
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
-- Current Database: `gestionplages`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `gestionplages` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `gestionplages`;

--
-- Table structure for table `compositions`
--

DROP TABLE IF EXISTS `compositions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `compositions` (
  `idComposition` int(11) NOT NULL AUTO_INCREMENT,
  `idPlage` int(11) DEFAULT NULL,
  `idNatureTerrain` int(11) DEFAULT NULL,
  PRIMARY KEY (`idComposition`),
  KEY `FK_Compositions_Plages` (`idPlage`),
  KEY `FK_Compositions_NatureTerrains` (`idNatureTerrain`),
  CONSTRAINT `FK_Compositions_NatureTerrains` FOREIGN KEY (`idNatureTerrain`) REFERENCES `natureterrains` (`idNatureTerrain`),
  CONSTRAINT `FK_Compositions_Plages` FOREIGN KEY (`idPlage`) REFERENCES `plages` (`idPlage`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `compositions`
--

LOCK TABLES `compositions` WRITE;
/*!40000 ALTER TABLE `compositions` DISABLE KEYS */;
/*!40000 ALTER TABLE `compositions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `departements`
--

DROP TABLE IF EXISTS `departements`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `departements` (
  `idDep` varchar(50) NOT NULL,
  `nomDep` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idDep`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departements`
--

LOCK TABLES `departements` WRITE;
/*!40000 ALTER TABLE `departements` DISABLE KEYS */;
/*!40000 ALTER TABLE `departements` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `natureterrains`
--

DROP TABLE IF EXISTS `natureterrains`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `natureterrains` (
  `idNatureTerrain` int(11) NOT NULL AUTO_INCREMENT,
  `nomNatureTerrain` varchar(50) NOT NULL,
  PRIMARY KEY (`idNatureTerrain`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `natureterrains`
--

LOCK TABLES `natureterrains` WRITE;
/*!40000 ALTER TABLE `natureterrains` DISABLE KEYS */;
/*!40000 ALTER TABLE `natureterrains` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `plages`
--

DROP TABLE IF EXISTS `plages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `plages` (
  `idPlage` int(11) NOT NULL AUTO_INCREMENT,
  `nomPlage` varchar(50) NOT NULL,
  `longPlage` decimal(6,3) NOT NULL,
  `idVille` int(11) NOT NULL,
  PRIMARY KEY (`idPlage`),
  KEY `FK_Plages_Villes` (`idVille`),
  CONSTRAINT `FK_Plages_Villes` FOREIGN KEY (`idVille`) REFERENCES `villes` (`idVille`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `plages`
--

LOCK TABLES `plages` WRITE;
/*!40000 ALTER TABLE `plages` DISABLE KEYS */;
/*!40000 ALTER TABLE `plages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `villes`
--

DROP TABLE IF EXISTS `villes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `villes` (
  `idVille` int(11) NOT NULL AUTO_INCREMENT,
  `nomVille` varchar(50) NOT NULL,
  `codePostal` smallint(6) NOT NULL,
  `nbAnTouri` smallint(6) NOT NULL,
  `idDep` varchar(50) NOT NULL,
  PRIMARY KEY (`idVille`),
  KEY `FK_Villes_Departements` (`idDep`),
  CONSTRAINT `FK_Villes_Departements` FOREIGN KEY (`idDep`) REFERENCES `departements` (`idDep`)
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

-- Dump completed on 2022-11-29 18:23:09
