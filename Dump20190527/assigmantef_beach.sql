CREATE DATABASE  IF NOT EXISTS `assigmantef` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `assigmantef`;
-- MySQL dump 10.13  Distrib 8.0.16, for Win64 (x86_64)
--
-- Host: localhost    Database: assigmantef
-- ------------------------------------------------------
-- Server version	8.0.16

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `beach`
--

DROP TABLE IF EXISTS `beach`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `beach` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Name` longtext,
  `NameFr` longtext,
  `Address` longtext,
  `AddressFr` longtext,
  `BeachType` longtext,
  `Accessible` longtext,
  `Open` longtext,
  `Notes` longtext,
  `ModifiedDate` longtext,
  `CreatedDate` longtext,
  `Link` longtext,
  `LinkFr` longtext,
  `LinkLabel` longtext,
  `LinkLab1` longtext,
  `LinkDescr` longtext,
  `LinkDes1` longtext,
  `GeometryId` bigint(20) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Beach_GeometryId` (`GeometryId`),
  CONSTRAINT `FK_Beach_Geometry_GeometryId` FOREIGN KEY (`GeometryId`) REFERENCES `geometry` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=36114 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `beach`
--

LOCK TABLES `beach` WRITE;
/*!40000 ALTER TABLE `beach` DISABLE KEYS */;
INSERT INTO `beach` VALUES (36110,'Petrie Island Beach','Plage de l\'île Petrie','777 Trim Rd.','777, ch. Trim','Plage','','','','2014/09/29',NULL,'http://ottawa.ca/en/taxonomy/term/2639','http://ottawa.ca/fr/taxonomy/term/2639','Beaches','Plages','','',3),(36111,'Westboro Beach','Plage Westboro','234 Atlantis Ave.','234, av. Atlantis','Plage','','','','2014/09/29',NULL,'http://ottawa.ca/en/taxonomy/term/2639','http://ottawa.ca/fr/taxonomy/term/2639','Beaches','Plages','','',1),(36112,'Mooney\'s Bay Beach','Plage de Mooney’s Bay','2960 Riverside Dr.','2960, prom. Riverside','Plage','','','','2014/09/29',NULL,'http://ottawa.ca/en/taxonomy/term/2639','http://ottawa.ca/fr/taxonomy/term/2639','Beaches','Plages','','',4),(36113,'Britannia Beach','Plage Britannia','102 Greenview Rd.','102, ch. Greenview','Plage','','','','2014/09/29',NULL,'http://ottawa.ca/en/taxonomy/term/2639','http://ottawa.ca/fr/taxonomy/term/2639','Beaches','Plages','','',2);
/*!40000 ALTER TABLE `beach` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-05-27  1:28:42
