-- MySQL dump 10.13  Distrib 5.7.36, for Win64 (x86_64)
--
-- Host: localhost    Database: boeufs_carottes
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
-- Current Database: `boeufs_carottes`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `boeufs_carottes` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `boeufs_carottes`;

--
-- Table structure for table `affectations`
--

DROP TABLE IF EXISTS `affectations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `affectations` (
  `idAffectation` int(11) NOT NULL AUTO_INCREMENT,
  `idCommissariat` int(11) DEFAULT NULL,
  `idService` int(11) DEFAULT NULL,
  `idPolicier` int(11) DEFAULT NULL,
  `dateAffectation` date NOT NULL,
  PRIMARY KEY (`idAffectation`),
  KEY `FK_Affectations_Commissariats` (`idCommissariat`),
  KEY `FK_Affectations_Services` (`idService`),
  KEY `FK_Affectations_Policiers` (`idPolicier`),
  CONSTRAINT `FK_Affectations_Commissariats` FOREIGN KEY (`idCommissariat`) REFERENCES `commissariats` (`idCommissariat`),
  CONSTRAINT `FK_Affectations_Policiers` FOREIGN KEY (`idPolicier`) REFERENCES `policiers` (`idPolicier`),
  CONSTRAINT `FK_Affectations_Services` FOREIGN KEY (`idService`) REFERENCES `services` (`idService`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `affectations`
--

LOCK TABLES `affectations` WRITE;
/*!40000 ALTER TABLE `affectations` DISABLE KEYS */;
/*!40000 ALTER TABLE `affectations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `blames`
--

DROP TABLE IF EXISTS `blames`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `blames` (
  `idBlame` int(11) NOT NULL AUTO_INCREMENT,
  `nomBlame` varchar(50) DEFAULT NULL,
  `dateCreation` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `dateModification` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`idBlame`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `blames`
--

LOCK TABLES `blames` WRITE;
/*!40000 ALTER TABLE `blames` DISABLE KEYS */;
INSERT INTO `blames` VALUES (1,'manque de respect','2022-11-21 16:40:33','2022-11-21 15:39:48'),(2,'coups et blessures','2022-11-21 16:40:33','2022-11-21 15:39:48'),(3,'manque de respect','2022-11-21 16:40:37','2022-11-21 15:39:48'),(4,'coups et blessures','2022-11-21 16:40:37','2022-11-21 15:39:48');
/*!40000 ALTER TABLE `blames` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `commissariats`
--

DROP TABLE IF EXISTS `commissariats`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `commissariats` (
  `idCommissariat` int(11) NOT NULL AUTO_INCREMENT,
  `nomCommissariat` varchar(50) DEFAULT NULL,
  `dateCreation` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `dateModification` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`idCommissariat`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `commissariats`
--

LOCK TABLES `commissariats` WRITE;
/*!40000 ALTER TABLE `commissariats` DISABLE KEYS */;
/*!40000 ALTER TABLE `commissariats` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grades`
--

DROP TABLE IF EXISTS `grades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `grades` (
  `idGrade` int(11) NOT NULL AUTO_INCREMENT,
  `nomGrade` varchar(50) DEFAULT NULL,
  `dateCreation` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `dateModification` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`idGrade`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grades`
--

LOCK TABLES `grades` WRITE;
/*!40000 ALTER TABLE `grades` DISABLE KEYS */;
/*!40000 ALTER TABLE `grades` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `localisations`
--

DROP TABLE IF EXISTS `localisations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `localisations` (
  `idLocalisation` int(11) NOT NULL AUTO_INCREMENT,
  `idVille` int(11) DEFAULT NULL,
  `idCommissariat` int(11) DEFAULT NULL,
  PRIMARY KEY (`idLocalisation`),
  KEY `FK_Localisations_Villes` (`idVille`),
  KEY `FK_Localisations_Commissariats` (`idCommissariat`),
  CONSTRAINT `FK_Localisations_Commissariats` FOREIGN KEY (`idCommissariat`) REFERENCES `commissariats` (`idCommissariat`),
  CONSTRAINT `FK_Localisations_Villes` FOREIGN KEY (`idVille`) REFERENCES `villes` (`idVille`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `localisations`
--

LOCK TABLES `localisations` WRITE;
/*!40000 ALTER TABLE `localisations` DISABLE KEYS */;
/*!40000 ALTER TABLE `localisations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `policiers`
--

DROP TABLE IF EXISTS `policiers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `policiers` (
  `idPolicier` int(11) NOT NULL AUTO_INCREMENT,
  `nomPolicier` varchar(50) DEFAULT NULL,
  `prenomPolicier` varchar(50) NOT NULL,
  `matriculePolicier` varchar(50) NOT NULL,
  `idGrade` int(11) NOT NULL,
  PRIMARY KEY (`idPolicier`),
  UNIQUE KEY `matriculePolicier` (`matriculePolicier`),
  KEY `FK_Policiers_Grades` (`idGrade`),
  CONSTRAINT `FK_Policiers_Grades` FOREIGN KEY (`idGrade`) REFERENCES `grades` (`idGrade`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `policiers`
--

LOCK TABLES `policiers` WRITE;
/*!40000 ALTER TABLE `policiers` DISABLE KEYS */;
/*!40000 ALTER TABLE `policiers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `punitions`
--

DROP TABLE IF EXISTS `punitions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `punitions` (
  `idPunition` int(11) NOT NULL AUTO_INCREMENT,
  `idBlame` int(11) DEFAULT NULL,
  `idPolicier` int(11) DEFAULT NULL,
  `dateBlame` date DEFAULT NULL,
  PRIMARY KEY (`idPunition`),
  KEY `FK_Punitions_Policiers` (`idPolicier`),
  KEY `FK_Punitions_Blames` (`idBlame`),
  CONSTRAINT `FK_Punitions_Blames` FOREIGN KEY (`idBlame`) REFERENCES `blames` (`idBlame`),
  CONSTRAINT `FK_Punitions_Policiers` FOREIGN KEY (`idPolicier`) REFERENCES `policiers` (`idPolicier`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `punitions`
--

LOCK TABLES `punitions` WRITE;
/*!40000 ALTER TABLE `punitions` DISABLE KEYS */;
/*!40000 ALTER TABLE `punitions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `services`
--

DROP TABLE IF EXISTS `services`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `services` (
  `idService` int(11) NOT NULL AUTO_INCREMENT,
  `nomService` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idService`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `services`
--

LOCK TABLES `services` WRITE;
/*!40000 ALTER TABLE `services` DISABLE KEYS */;
/*!40000 ALTER TABLE `services` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `villes`
--

DROP TABLE IF EXISTS `villes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `villes` (
  `idVille` int(11) NOT NULL AUTO_INCREMENT,
  `nomVille` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idVille`)
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
