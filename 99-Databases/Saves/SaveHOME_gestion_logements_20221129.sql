-- MySQL dump 10.13  Distrib 5.7.36, for Win64 (x86_64)
--
-- Host: localhost    Database: gestion_logements
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
-- Current Database: `gestion_logements`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `gestion_logements` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `gestion_logements`;

--
-- Table structure for table `achete`
--

DROP TABLE IF EXISTS `achete`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `achete` (
  `idIndividu` int(11) NOT NULL,
  `idLogements` int(11) NOT NULL,
  PRIMARY KEY (`idIndividu`,`idLogements`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `achete`
--

LOCK TABLES `achete` WRITE;
/*!40000 ALTER TABLE `achete` DISABLE KEYS */;
/*!40000 ALTER TABLE `achete` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `communes`
--

DROP TABLE IF EXISTS `communes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `communes` (
  `idCommune` int(11) NOT NULL AUTO_INCREMENT,
  `nomCommune` varchar(45) NOT NULL,
  `distanceAgence` decimal(5,3) NOT NULL,
  `nombreHabitant` int(11) NOT NULL,
  PRIMARY KEY (`idCommune`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `communes`
--

LOCK TABLES `communes` WRITE;
/*!40000 ALTER TABLE `communes` DISABLE KEYS */;
/*!40000 ALTER TABLE `communes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `individus`
--

DROP TABLE IF EXISTS `individus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `individus` (
  `idIndividu` int(11) NOT NULL AUTO_INCREMENT,
  `nomIndividu` varchar(35) NOT NULL,
  `prenomIndividu` varchar(30) NOT NULL,
  `dateNaissanceIndividu` date NOT NULL,
  `telephoneIndividu` varchar(12) NOT NULL,
  PRIMARY KEY (`idIndividu`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `individus`
--

LOCK TABLES `individus` WRITE;
/*!40000 ALTER TABLE `individus` DISABLE KEYS */;
/*!40000 ALTER TABLE `individus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `logements`
--

DROP TABLE IF EXISTS `logements`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `logements` (
  `idLogements` int(11) NOT NULL AUTO_INCREMENT,
  `numeroLogement` varchar(5) NOT NULL,
  `rueLogement` varchar(60) NOT NULL,
  `superficieLogement` int(11) NOT NULL,
  `loyerLogement` decimal(19,4) NOT NULL,
  `idTypeLogement` int(11) NOT NULL,
  `idQuartier` int(11) NOT NULL,
  PRIMARY KEY (`idLogements`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `logements`
--

LOCK TABLES `logements` WRITE;
/*!40000 ALTER TABLE `logements` DISABLE KEYS */;
/*!40000 ALTER TABLE `logements` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `quartiers`
--

DROP TABLE IF EXISTS `quartiers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `quartiers` (
  `idQuartier` int(11) NOT NULL AUTO_INCREMENT,
  `libelleQuartier` varchar(35) NOT NULL,
  `idCommune` int(11) NOT NULL,
  PRIMARY KEY (`idQuartier`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `quartiers`
--

LOCK TABLES `quartiers` WRITE;
/*!40000 ALTER TABLE `quartiers` DISABLE KEYS */;
/*!40000 ALTER TABLE `quartiers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `typeslogements`
--

DROP TABLE IF EXISTS `typeslogements`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `typeslogements` (
  `idTypeLogement` int(11) NOT NULL AUTO_INCREMENT,
  `libelleTypeLogement` varchar(25) NOT NULL,
  `chargesForfaitairesLogement` decimal(19,4) NOT NULL,
  PRIMARY KEY (`idTypeLogement`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `typeslogements`
--

LOCK TABLES `typeslogements` WRITE;
/*!40000 ALTER TABLE `typeslogements` DISABLE KEYS */;
/*!40000 ALTER TABLE `typeslogements` ENABLE KEYS */;
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
