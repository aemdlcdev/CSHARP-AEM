CREATE DATABASE  IF NOT EXISTS `tpv` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `tpv`;
-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: localhost    Database: tpv
-- ------------------------------------------------------
-- Server version	8.0.40

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `clientes`
--

DROP TABLE IF EXISTS `clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clientes` (
  `codcliente` int NOT NULL AUTO_INCREMENT,
  `email` varchar(45) NOT NULL,
  `cnombre` varchar(45) NOT NULL,
  `activo` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`codcliente`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientes`
--

LOCK TABLES `clientes` WRITE;
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` VALUES (4,'aestebandmdlc@gmail.com','Alejandro',0),(5,'josefv@gmail.com','Jose',1),(6,'lucimd@gmail.com','Lucia',0),(8,'juanlpz@hotmail.com','Juan',0),(11,'mariagrc@outlook.com','Maria',0),(12,'malosnchz@hotmail.com','Manolo',1),(13,'alvaroaem@gmail.com','Alvaro',0),(15,'pepe@gmail.com','pepe',1),(16,'marcos@hotmail.com','Marcos',1),(18,'saramfg@gmail.com','sara',1),(19,'angelsanch23@gmail.com','Angel',1),(20,'juliahm@gmail.com','Julia',1),(21,'pinki123@gmial.com','Pinki',0);
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productos`
--

DROP TABLE IF EXISTS `productos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productos` (
  `idproductos` int NOT NULL AUTO_INCREMENT,
  `pnombre` varchar(45) NOT NULL,
  `palergias` varchar(45) NOT NULL,
  `precio` double NOT NULL,
  `cantidad` int NOT NULL,
  `rutaimg` varchar(255) NOT NULL,
  PRIMARY KEY (`idproductos`),
  UNIQUE KEY `pnombre_UNIQUE` (`pnombre`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productos`
--

LOCK TABLES `productos` WRITE;
/*!40000 ALTER TABLE `productos` DISABLE KEYS */;
INSERT INTO `productos` VALUES (1,'nuggets','ejemplo',7.99,18,'/resources/nuggets.png'),(2,'pescado','ejemplo',9.99,25,'/resources/pescado.png'),(3,'ensalada','ejemplo',5,47,'/resources/ensalada.png'),(4,'patatas','ejemplo',3.8,56,'/resources/patatas.png'),(5,'ibericos','ejemplo',14,75,'/resources/ibericos.png'),(6,'tarta de queso','ejemplo',5,33,'/resources/tartaqueso.png'),(7,'flan','ejemplo',5,51,'/resources/flan.png'),(8,'natillas','ejemplo',4,39,'/resources/natillas.png'),(9,'gofres','ejemplo',4,29,'/resources/gofres.png'),(10,'helado','ejemplo',4,53,'/resources/helado.png'),(11,'refrescos','ejemplo',2.5,233,'/resources/refrescos.png'),(12,'cerveza','ejemplo',2.7,156,'/resources/cervezas.png'),(13,'vino','ejemplo',3.2,77,'/resources/vinos.png'),(14,'combinado','ejemplo',6.5,41,'/resources/licores.png'),(15,'agua','ejemplo',1.5,339,'/resources/agua.png');
/*!40000 ALTER TABLE `productos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rol`
--

DROP TABLE IF EXISTS `rol`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rol` (
  `idrol` int NOT NULL,
  `rol` varchar(45) NOT NULL,
  PRIMARY KEY (`idrol`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rol`
--

LOCK TABLES `rol` WRITE;
/*!40000 ALTER TABLE `rol` DISABLE KEYS */;
INSERT INTO `rol` VALUES (1,'jefe'),(2,'user'),(3,'admin');
/*!40000 ALTER TABLE `rol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ticket`
--

DROP TABLE IF EXISTS `ticket`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ticket` (
  `idticket` int NOT NULL AUTO_INCREMENT,
  `consumiciones` varchar(200) NOT NULL,
  `importe` double NOT NULL,
  `codcliente` int NOT NULL,
  PRIMARY KEY (`idticket`),
  KEY `codcliente_idx` (`codcliente`),
  CONSTRAINT `codcliente` FOREIGN KEY (`codcliente`) REFERENCES `clientes` (`codcliente`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ticket`
--

LOCK TABLES `ticket` WRITE;
/*!40000 ALTER TABLE `ticket` DISABLE KEYS */;
INSERT INTO `ticket` VALUES (11,'pescado\npatatas\n',13.49,4),(12,'nuggets\ngofres\ncerveza\n',13.69,8),(13,'nuggets\npatatas\ncombinado\ngofres\ntarta de queso\n',25.99,5),(34,'nuggets\nnatillas\nvino\n',15.19,18),(46,'pescado\nnuggets\nnuggets\ngofres\n',29.97,13),(47,'nuggets\npatatas\ncerveza\nensalada\n',19.49,4),(48,'patatas\n',3.8,21);
/*!40000 ALTER TABLE `ticket` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `idusuario` int NOT NULL AUTO_INCREMENT,
  `nusuario` varchar(45) NOT NULL,
  `password` varchar(355) NOT NULL,
  `idrol` int NOT NULL,
  PRIMARY KEY (`idusuario`),
  KEY `idrol_idx` (`idrol`),
  CONSTRAINT `idrol` FOREIGN KEY (`idrol`) REFERENCES `rol` (`idrol`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (4,'admin','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918',3),(25,'jefe','452b889d10df869834152618463e1c07ce88001a40c9fff5d4fdf300c65684c6',1),(26,'user','04f8996da763b7a969b1028ee3007569eaf3a635486ddab211d512c85b9df8fb',2),(29,'gema23','7b4ab4b3c2eed3d0dab81bf037d1debe70bc31f879dd0349cf2e49f949befaff',1),(30,'alvarito','b3a2c636555520c9afd783ea433bfc553deed9f793805c3a89fd618a7440ac0e',2);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-12-08 20:40:23
