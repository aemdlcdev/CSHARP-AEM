-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: localhost    Database: mydb
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
-- Table structure for table `cargo`
--

DROP TABLE IF EXISTS `cargo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cargo` (
  `idcargo` int NOT NULL AUTO_INCREMENT,
  `cnombre` varchar(45) NOT NULL,
  PRIMARY KEY (`idcargo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cargo`
--

LOCK TABLES `cargo` WRITE;
/*!40000 ALTER TABLE `cargo` DISABLE KEYS */;
/*!40000 ALTER TABLE `cargo` ENABLE KEYS */;
UNLOCK TABLES;

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
  PRIMARY KEY (`codcliente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientes`
--

LOCK TABLES `clientes` WRITE;
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empleado`
--

DROP TABLE IF EXISTS `empleado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `empleado` (
  `IDEMPLEADO` int NOT NULL AUTO_INCREMENT,
  `NOMBREEMP` varchar(64) NOT NULL,
  `APELLIDOSEMP` varchar(128) NOT NULL,
  `CSR` float NOT NULL,
  `IDUSUARIO` int NOT NULL,
  `IDROL` int NOT NULL,
  PRIMARY KEY (`IDEMPLEADO`),
  KEY `fk_EMPLEADO_ROL1_idx` (`IDROL`),
  KEY `fk_EMPLEADO_USUARIO_idx` (`IDUSUARIO`),
  CONSTRAINT `fk_EMPLEADO_ROL1` FOREIGN KEY (`IDROL`) REFERENCES `rol` (`IDROL`),
  CONSTRAINT `fk_EMPLEADO_USUARIO` FOREIGN KEY (`IDUSUARIO`) REFERENCES `usuario` (`IDUSUARIO`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empleado`
--

LOCK TABLES `empleado` WRITE;
/*!40000 ALTER TABLE `empleado` DISABLE KEYS */;
INSERT INTO `empleado` VALUES (17,'aemdlcdev21','8ded225eabb7f602923e05d5b329164f53f1a8b1997ac5228b8ff24636dc8171',35,4,3);
/*!40000 ALTER TABLE `empleado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `factura`
--

DROP TABLE IF EXISTS `factura`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `factura` (
  `IDFACTURA` int NOT NULL,
  `NUMFACTURA` varchar(16) NOT NULL,
  `DESCFACTURA` varchar(1024) NOT NULL,
  `IMPORTE` float NOT NULL,
  `IDPROYECTO` int NOT NULL,
  PRIMARY KEY (`IDFACTURA`),
  KEY `fk_FACTURA_PROYECTO1_idx` (`IDPROYECTO`),
  CONSTRAINT `fk_FACTURA_PROYECTO1` FOREIGN KEY (`IDPROYECTO`) REFERENCES `proyecto` (`IDPROYECTO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura`
--

LOCK TABLES `factura` WRITE;
/*!40000 ALTER TABLE `factura` DISABLE KEYS */;
/*!40000 ALTER TABLE `factura` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pasajero`
--

DROP TABLE IF EXISTS `pasajero`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pasajero` (
  `idpasajero` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  `apellidos` varchar(45) NOT NULL,
  `edad` int NOT NULL,
  `fec_nac` varchar(45) NOT NULL,
  `idcargo` int NOT NULL,
  PRIMARY KEY (`idpasajero`),
  KEY `idcargo_idx` (`idcargo`),
  CONSTRAINT `idcargo` FOREIGN KEY (`idcargo`) REFERENCES `cargo` (`idcargo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pasajero`
--

LOCK TABLES `pasajero` WRITE;
/*!40000 ALTER TABLE `pasajero` DISABLE KEYS */;
/*!40000 ALTER TABLE `pasajero` ENABLE KEYS */;
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
  PRIMARY KEY (`idproductos`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productos`
--

LOCK TABLES `productos` WRITE;
/*!40000 ALTER TABLE `productos` DISABLE KEYS */;
/*!40000 ALTER TABLE `productos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proyecto`
--

DROP TABLE IF EXISTS `proyecto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `proyecto` (
  `IDPROYECTO` int NOT NULL AUTO_INCREMENT,
  `CODIGOPY` varchar(36) NOT NULL,
  `NOMBREPROY` varchar(32) NOT NULL,
  `DESCPROY` varchar(1024) NOT NULL,
  `PRESUPUESTO` float NOT NULL,
  `FEC_INICIO` varchar(45) DEFAULT NULL,
  `FEC_FIN` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`IDPROYECTO`)
) ENGINE=InnoDB AUTO_INCREMENT=574 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proyecto`
--

LOCK TABLES `proyecto` WRITE;
/*!40000 ALTER TABLE `proyecto` DISABLE KEYS */;
INSERT INTO `proyecto` VALUES (373,'MTR0naturgy24','pepeee','',0,'06/03/2025 10:44:19','27/04/2025 10:44:19'),(374,'MTR1SAP24','SAP','',0,'29/01/2025 10:44:19','28/02/2025 10:44:19'),(375,'MTR2mutuaMadrileña24','mutuaMadrileña','',0,'18/01/2025 10:44:19','04/02/2025 10:44:19'),(376,'MTR3SAP24','SAP','',0,'08/02/2025 10:44:19','03/05/2025 10:44:19'),(377,'MTR4naturgy24','naturgy','',0,'12/04/2025 10:44:19','04/05/2025 10:44:19'),(378,'MTR5velneo24','velneo','',0,'05/08/2025 10:44:19','13/02/2025 10:44:19'),(379,'MTR6santander24','santander','',0,'10/03/2025 10:44:19','04/03/2025 10:44:19'),(380,'MTR7velneo24','velneo','',0,'14/03/2025 10:44:19','05/04/2025 10:44:19'),(381,'MTR8allegro24','allegro','',0,'14/07/2025 10:44:19','15/04/2025 10:44:19'),(382,'MTR9velneo24','velneo','',0,'29/05/2025 10:44:19','09/01/2025 10:44:19'),(383,'MTR10naturgy24','naturgy','',0,'08/07/2025 10:44:19','12/02/2025 10:44:19'),(384,'MTR11mutuaMadrileña24','mutuaMadrileña','',0,'18/08/2025 10:44:19','28/03/2025 10:44:19'),(385,'MTR12mutuaMadrileña24','mutuaMadrileña','',0,'28/02/2025 10:44:19','14/04/2025 10:44:19'),(386,'MTR13SAP24','SAP','',0,'11/06/2025 10:44:19','26/12/2024 10:44:19'),(387,'MTR14santander24','santander','',0,'02/07/2025 10:44:19','07/05/2025 10:44:19'),(388,'MTR15santander24','santander','',0,'16/05/2025 10:44:19','10/04/2025 10:44:19'),(389,'MTR16allegro24','allegro','',0,'14/03/2025 10:44:19','09/04/2025 10:44:19'),(390,'MTR17velneo24','velneo','',0,'13/04/2025 10:44:19','26/02/2025 10:44:19'),(391,'MTR18velneo24','velneo','',0,'17/01/2025 10:44:19','11/05/2025 10:44:19'),(392,'MTR19mutuaMadrileña24','mutuaMadrileña','',0,'06/08/2025 10:44:19','29/01/2025 10:44:19'),(393,'MTR7velneo24','velneo','',0,'14/03/2025 10:44:19','05/04/2025 10:44:19'),(394,'MTR0naturgy25','naturgy','',0,'13/08/2025 9:02:57','24/04/2025 9:02:57'),(395,'MTR1santander25','santander','',0,'07/10/2025 9:02:57','03/04/2025 9:02:57'),(396,'MTR2naturgy25','naturgy','',0,'06/04/2025 9:02:57','06/05/2025 9:02:57'),(397,'MTR3SAP25','SAP','',0,'10/04/2025 9:02:57','25/02/2025 9:02:57'),(398,'MTR4allegro25','allegro','',0,'15/05/2025 9:02:57','27/04/2025 9:02:57'),(399,'MTR5naturgy25','naturgy','',0,'24/05/2025 9:02:57','07/07/2025 9:02:57'),(400,'MTR6santander25','santander','',0,'14/10/2025 9:02:57','28/02/2025 9:02:57'),(401,'MTR7santander25','santander','',0,'09/09/2025 9:02:57','05/04/2025 9:02:57'),(402,'MTR8mutuaMadrileña25','mutuaMadrileña','',0,'03/10/2025 9:02:57','24/02/2025 9:02:57'),(403,'MTR9mutuaMadrileña25','mutuaMadrileña','',0,'15/04/2025 9:02:57','06/04/2025 9:02:57'),(404,'MTR10allegro25','allegro','',0,'17/08/2025 9:02:57','04/06/2025 9:02:57'),(405,'MTR11naturgy25','naturgy','',0,'07/07/2025 9:02:57','03/07/2025 9:02:57'),(406,'MTR12santander25','santander','',0,'27/03/2025 9:02:57','05/06/2025 9:02:57'),(407,'MTR13santander25','santander','',0,'06/09/2025 9:02:57','05/06/2025 9:02:57'),(408,'MTR14santander25','santander','',0,'14/07/2025 9:02:57','08/04/2025 9:02:57'),(409,'MTR15naturgy25','naturgy','',0,'16/04/2025 9:02:57','24/05/2025 9:02:57'),(410,'MTR16santander25','santander','',0,'12/09/2025 9:02:57','30/06/2025 9:02:57'),(411,'MTR17santander25','santander','',0,'27/05/2025 9:02:57','05/04/2025 9:02:57'),(412,'MTR18velneo25','velneo','',0,'26/04/2025 9:02:57','09/05/2025 9:02:57'),(413,'MTR19santander25','santander','',0,'29/04/2025 9:02:57','01/04/2025 9:02:57'),(414,'MTR0SAP25','SAP','',0,'26/06/2025 9:02:58','11/05/2025 9:02:58'),(415,'MTR1velneo25','velneo','',0,'04/10/2025 9:02:58','28/02/2025 9:02:58'),(416,'MTR2santander25','santander','',0,'02/06/2025 9:02:58','10/03/2025 9:02:58'),(417,'MTR3allegro25','allegro','',0,'02/09/2025 9:02:58','08/07/2025 9:02:58'),(418,'MTR4naturgy25','naturgy','',0,'27/03/2025 9:02:58','28/04/2025 9:02:58'),(419,'MTR5santander25','santander','',0,'06/08/2025 9:02:58','28/05/2025 9:02:58'),(420,'MTR6SAP25','SAP','',0,'07/09/2025 9:02:58','06/04/2025 9:02:58'),(421,'MTR7naturgy25','naturgy','',0,'27/08/2025 9:02:58','10/06/2025 9:02:58'),(422,'MTR8velneo25','velneo','',0,'28/02/2025 9:02:58','04/06/2025 9:02:58'),(423,'MTR9mutuaMadrileña25','mutuaMadrileña','',0,'08/06/2025 9:02:58','08/05/2025 9:02:58'),(424,'MTR10velneo25','velneo','',0,'03/07/2025 9:02:58','04/06/2025 9:02:58'),(425,'MTR11velneo25','velneo','',0,'17/06/2025 9:02:58','30/06/2025 9:02:58'),(426,'MTR12naturgy25','naturgy','',0,'13/08/2025 9:02:58','05/06/2025 9:02:58'),(427,'MTR13allegro25','allegro','',0,'07/09/2025 9:02:58','04/04/2025 9:02:58'),(428,'MTR14mutuaMadrileña25','mutuaMadrileña','',0,'05/10/2025 9:02:58','26/04/2025 9:02:58'),(429,'MTR15SAP25','SAP','',0,'24/06/2025 9:02:58','04/06/2025 9:02:58'),(430,'MTR16allegro25','allegro','',0,'25/09/2025 9:02:58','07/04/2025 9:02:58'),(431,'MTR17allegro25','allegro','',0,'24/03/2025 9:02:58','10/03/2025 9:02:58'),(432,'MTR18santander25','santander','',0,'12/06/2025 9:02:58','12/07/2025 9:02:58'),(433,'MTR19SAP25','SAP','',0,'05/06/2025 9:02:58','11/05/2025 9:02:58'),(434,'MTR0velneo25','velneo','',0,'12/09/2025 9:02:58','31/05/2025 9:02:58'),(435,'MTR1santander25','santander','',0,'03/06/2025 9:02:58','24/03/2025 9:02:58'),(436,'MTR2velneo25','velneo','',0,'02/09/2025 9:02:58','07/06/2025 9:02:58'),(437,'MTR3naturgy25','naturgy','',0,'15/10/2025 9:02:58','30/04/2025 9:02:58'),(438,'MTR4allegro25','allegro','',0,'02/10/2025 9:02:58','02/06/2025 9:02:58'),(439,'MTR5allegro25','allegro','',0,'25/09/2025 9:02:58','27/02/2025 9:02:58'),(440,'MTR6mutuaMadrileña25','mutuaMadrileña','',0,'06/08/2025 9:02:58','26/03/2025 9:02:58'),(441,'MTR7velneo25','velneo','',0,'28/06/2025 9:02:58','25/04/2025 9:02:58'),(442,'MTR8naturgy25','naturgy','',0,'08/04/2025 9:02:58','03/07/2025 9:02:58'),(443,'MTR9velneo25','velneo','',0,'17/08/2025 9:02:58','27/04/2025 9:02:58'),(444,'MTR10naturgy25','naturgy','',0,'06/04/2025 9:02:58','31/03/2025 9:02:58'),(445,'MTR11mutuaMadrileña25','mutuaMadrileña','',0,'14/06/2025 9:02:58','06/05/2025 9:02:58'),(446,'MTR12santander25','santander','',0,'04/04/2025 9:02:58','10/05/2025 9:02:58'),(447,'MTR13naturgy25','naturgy','',0,'11/08/2025 9:02:58','30/04/2025 9:02:58'),(448,'MTR14SAP25','SAP','',0,'02/10/2025 9:02:58','09/07/2025 9:02:58'),(449,'MTR15SAP25','SAP','',0,'29/05/2025 9:02:58','05/05/2025 9:02:58'),(450,'MTR16allegro25','allegro','',0,'31/08/2025 9:02:58','07/05/2025 9:02:58'),(451,'MTR17SAP25','SAP','',0,'02/05/2025 9:02:58','07/05/2025 9:02:58'),(452,'MTR18SAP25','SAP','',0,'13/09/2025 9:02:58','02/06/2025 9:02:58'),(453,'MTR19allegro25','allegro','',0,'02/05/2025 9:02:58','25/03/2025 9:02:58'),(454,'MTR0naturgy25','naturgy','',0,'30/04/2025 9:02:59','06/03/2025 9:02:59'),(455,'MTR1velneo25','velneo','',0,'08/05/2025 9:02:59','30/06/2025 9:02:59'),(456,'MTR2santander25','santander','',0,'03/09/2025 9:02:59','29/04/2025 9:02:59'),(457,'MTR3SAP25','SAP','',0,'10/07/2025 9:02:59','28/02/2025 9:02:59'),(458,'MTR4velneo25','velneo','',0,'04/10/2025 9:02:59','11/03/2025 9:02:59'),(459,'MTR5naturgy25','naturgy','',0,'06/06/2025 9:02:59','25/06/2025 9:02:59'),(460,'MTR6allegro25','allegro','',0,'15/05/2025 9:02:59','30/06/2025 9:02:59'),(461,'MTR7santander25','santander','',0,'17/03/2025 9:02:59','07/04/2025 9:02:59'),(462,'MTR8santander25','santander','',0,'25/09/2025 9:02:59','09/06/2025 9:02:59'),(463,'MTR9allegro25','allegro','',0,'25/06/2025 9:02:59','12/04/2025 9:02:59'),(464,'MTR10SAP25','SAP','',0,'15/10/2025 9:02:59','12/07/2025 9:02:59'),(465,'MTR11allegro25','allegro','',0,'01/06/2025 9:02:59','04/05/2025 9:02:59'),(466,'MTR12naturgy25','naturgy','',0,'29/04/2025 9:02:59','04/07/2025 9:02:59'),(467,'MTR13santander25','santander','',0,'25/05/2025 9:02:59','01/06/2025 9:02:59'),(468,'MTR14SAP25','SAP','',0,'08/09/2025 9:02:59','24/03/2025 9:02:59'),(469,'MTR15velneo25','velneo','',0,'06/03/2025 9:02:59','26/02/2025 9:02:59'),(470,'MTR16naturgy25','naturgy','',0,'16/06/2025 9:02:59','07/05/2025 9:02:59'),(471,'MTR17velneo25','velneo','',0,'17/05/2025 9:02:59','01/06/2025 9:02:59'),(472,'MTR18SAP25','SAP','',0,'06/07/2025 9:02:59','29/05/2025 9:02:59'),(473,'MTR19naturgy25','naturgy','',0,'13/05/2025 9:02:59','24/02/2025 9:02:59'),(474,'MTR0mutuaMadrileña25','mutuaMadrileña','',0,'09/04/2025 9:02:59','29/06/2025 9:02:59'),(475,'MTR1santander25','santander','',0,'26/09/2025 9:02:59','06/06/2025 9:02:59'),(476,'MTR2naturgy25','naturgy','',0,'29/04/2025 9:02:59','02/07/2025 9:02:59'),(477,'MTR3santander25','santander','',0,'12/07/2025 9:02:59','26/05/2025 9:02:59'),(478,'MTR4santander25','santander','',0,'10/03/2025 9:02:59','07/04/2025 9:02:59'),(479,'MTR5mutuaMadrileña25','mutuaMadrileña','',0,'26/06/2025 9:02:59','30/05/2025 9:02:59'),(480,'MTR6SAP25','SAP','',0,'28/02/2025 9:02:59','25/02/2025 9:02:59'),(481,'MTR7mutuaMadrileña25','mutuaMadrileña','',0,'12/04/2025 9:02:59','10/05/2025 9:02:59'),(482,'MTR8allegro25','allegro','',0,'25/07/2025 9:02:59','05/03/2025 9:02:59'),(483,'MTR9velneo25','velneo','',0,'28/02/2025 9:02:59','28/02/2025 9:02:59'),(484,'MTR10santander25','santander','',0,'31/03/2025 9:02:59','01/04/2025 9:02:59'),(485,'MTR11velneo25','velneo','',0,'08/06/2025 9:02:59','12/07/2025 9:02:59'),(486,'MTR12santander25','santander','',0,'07/07/2025 9:02:59','11/05/2025 9:02:59'),(487,'MTR13SAP25','SAP','',0,'27/03/2025 9:02:59','28/02/2025 9:02:59'),(488,'MTR14mutuaMadrileña25','mutuaMadrileña','',0,'08/08/2025 9:02:59','04/05/2025 9:02:59'),(489,'MTR15santander25','santander','',0,'24/05/2025 9:02:59','05/03/2025 9:02:59'),(490,'MTR16santander25','santander','',0,'25/03/2025 9:02:59','30/06/2025 9:02:59'),(491,'MTR17allegro25','allegro','',0,'24/07/2025 9:02:59','10/07/2025 9:02:59'),(492,'MTR18velneo25','velneo','',0,'01/04/2025 9:02:59','12/07/2025 9:02:59'),(493,'MTR19naturgy25','naturgy','',0,'05/08/2025 9:02:59','28/05/2025 9:02:59'),(494,'MTR0allegro25','allegro','',0,'16/08/2025 9:02:59','28/02/2025 9:02:59'),(495,'MTR1allegro25','allegro','',0,'10/08/2025 9:02:59','11/05/2025 9:02:59'),(496,'MTR2velneo25','velneo','',0,'30/08/2025 9:02:59','11/03/2025 9:02:59'),(497,'MTR3santander25','santander','',0,'02/05/2025 9:02:59','12/04/2025 9:02:59'),(498,'MTR4SAP25','SAP','',0,'04/06/2025 9:02:59','01/07/2025 9:02:59'),(499,'MTR5naturgy25','naturgy','',0,'04/08/2025 9:02:59','06/07/2025 9:02:59'),(500,'MTR6velneo25','velneo','',0,'30/03/2025 9:02:59','10/03/2025 9:02:59'),(501,'MTR7santander25','santander','',0,'01/10/2025 9:02:59','28/06/2025 9:02:59'),(502,'MTR8SAP25','SAP','',0,'02/08/2025 9:02:59','31/05/2025 9:02:59'),(503,'MTR9mutuaMadrileña25','mutuaMadrileña','',0,'06/04/2025 9:02:59','08/03/2025 9:02:59'),(504,'MTR10allegro25','allegro','',0,'29/08/2025 9:02:59','09/05/2025 9:02:59'),(505,'MTR11naturgy25','naturgy','',0,'06/05/2025 9:02:59','01/05/2025 9:02:59'),(506,'MTR12santander25','santander','',0,'24/09/2025 9:02:59','12/04/2025 9:02:59'),(507,'MTR13mutuaMadrileña25','mutuaMadrileña','',0,'25/09/2025 9:02:59','10/04/2025 9:02:59'),(508,'MTR14SAP25','SAP','',0,'04/03/2025 9:02:59','26/02/2025 9:02:59'),(509,'MTR15mutuaMadrileña25','mutuaMadrileña','',0,'11/03/2025 9:02:59','08/07/2025 9:02:59'),(510,'MTR16allegro25','allegro','',0,'29/09/2025 9:02:59','03/07/2025 9:02:59'),(511,'MTR17allegro25','allegro','',0,'05/05/2025 9:02:59','02/04/2025 9:02:59'),(512,'MTR18velneo25','velneo','',0,'25/05/2025 9:02:59','08/03/2025 9:02:59'),(513,'MTR19velneo25','velneo','',0,'03/09/2025 9:02:59','25/05/2025 9:02:59'),(514,'MTR0mutuaMadrileña25','mutuaMadrileña','',0,'08/05/2025 9:03:00','01/07/2025 9:03:00'),(515,'MTR1santander25','santander','',0,'28/07/2025 9:03:00','08/05/2025 9:03:00'),(516,'MTR2mutuaMadrileña25','mutuaMadrileña','',0,'06/07/2025 9:03:00','05/05/2025 9:03:00'),(517,'MTR3SAP25','SAP','',0,'27/05/2025 9:03:00','27/03/2025 9:03:00'),(518,'MTR4SAP25','SAP','',0,'11/06/2025 9:03:00','02/03/2025 9:03:00'),(519,'MTR5velneo25','velneo','',0,'16/05/2025 9:03:00','24/05/2025 9:03:00'),(520,'MTR6naturgy25','naturgy','',0,'16/10/2025 9:03:00','24/06/2025 9:03:00'),(521,'MTR7SAP25','SAP','',0,'14/06/2025 9:03:00','06/03/2025 9:03:00'),(522,'MTR8mutuaMadrileña25','mutuaMadrileña','',0,'14/07/2025 9:03:00','12/05/2025 9:03:00'),(523,'MTR9santander25','santander','',0,'06/10/2025 9:03:00','30/05/2025 9:03:00'),(524,'MTR10velneo25','velneo','',0,'17/07/2025 9:03:00','09/04/2025 9:03:00'),(525,'MTR11velneo25','velneo','',0,'27/08/2025 9:03:00','29/04/2025 9:03:00'),(526,'MTR12santander25','santander','',0,'15/08/2025 9:03:00','25/06/2025 9:03:00'),(527,'MTR13mutuaMadrileña25','mutuaMadrileña','',0,'07/06/2025 9:03:00','06/03/2025 9:03:00'),(528,'MTR14naturgy25','naturgy','',0,'09/09/2025 9:03:00','24/03/2025 9:03:00'),(529,'MTR15naturgy25','naturgy','',0,'28/05/2025 9:03:00','12/05/2025 9:03:00'),(530,'MTR16santander25','santander','',0,'25/09/2025 9:03:00','30/04/2025 9:03:00'),(531,'MTR17naturgy25','naturgy','',0,'01/04/2025 9:03:00','08/06/2025 9:03:00'),(532,'MTR18velneo25','velneo','',0,'24/03/2025 9:03:00','26/03/2025 9:03:00'),(533,'MTR19mutuaMadrileña25','mutuaMadrileña','',0,'29/05/2025 9:03:00','24/04/2025 9:03:00'),(534,'MTR0allegro25','allegro','',0,'25/03/2025 9:03:00','28/02/2025 9:03:00'),(535,'MTR1naturgy25','naturgy','',0,'29/06/2025 9:03:00','01/06/2025 9:03:00'),(536,'MTR2allegro25','allegro','',0,'10/09/2025 9:03:00','10/06/2025 9:03:00'),(537,'MTR3santander25','santander','',0,'16/05/2025 9:03:00','04/05/2025 9:03:00'),(538,'MTR4naturgy25','naturgy','',0,'03/08/2025 9:03:00','12/06/2025 9:03:00'),(539,'MTR5naturgy25','naturgy','',0,'04/07/2025 9:03:00','06/05/2025 9:03:00'),(540,'MTR6SAP25','SAP','',0,'10/06/2025 9:03:00','01/04/2025 9:03:00'),(541,'MTR7santander25','santander','',0,'14/08/2025 9:03:00','28/06/2025 9:03:00'),(542,'MTR8velneo25','velneo','',0,'12/08/2025 9:03:00','26/05/2025 9:03:00'),(543,'MTR9naturgy25','naturgy','',0,'28/04/2025 9:03:00','30/05/2025 9:03:00'),(544,'MTR10allegro25','allegro','',0,'16/10/2025 9:03:00','04/07/2025 9:03:00'),(545,'MTR11santander25','santander','',0,'01/04/2025 9:03:00','04/05/2025 9:03:00'),(546,'MTR12allegro25','allegro','',0,'08/09/2025 9:03:00','24/03/2025 9:03:00'),(547,'MTR13velneo25','velneo','',0,'30/05/2025 9:03:00','05/03/2025 9:03:00'),(548,'MTR14santander25','santander','',0,'28/02/2025 9:03:00','04/03/2025 9:03:00'),(549,'MTR15santander25','santander','',0,'11/07/2025 9:03:00','28/02/2025 9:03:00'),(550,'MTR16SAP25','SAP','',0,'26/04/2025 9:03:00','24/03/2025 9:03:00'),(551,'MTR17SAP25','SAP','',0,'13/09/2025 9:03:00','01/05/2025 9:03:00'),(552,'MTR18SAP25','SAP','',0,'09/03/2025 9:03:00','06/07/2025 9:03:00'),(553,'MTR19santander25','santander','',0,'16/08/2025 9:03:00','09/04/2025 9:03:00'),(554,'MTR0velneo25','velneo','',0,'11/08/2025 9:03:00','28/06/2025 9:03:00'),(555,'MTR1santander25','santander','',0,'15/05/2025 9:03:00','01/03/2025 9:03:00'),(556,'MTR2mutuaMadrileña25','mutuaMadrileña','',0,'10/10/2025 9:03:00','01/03/2025 9:03:00'),(557,'MTR3mutuaMadrileña25','mutuaMadrileña','',0,'01/09/2025 9:03:00','06/06/2025 9:03:00'),(558,'MTR4SAP25','SAP','',0,'03/10/2025 9:03:00','25/05/2025 9:03:00'),(559,'MTR5allegro25','allegro','',0,'29/04/2025 9:03:00','07/05/2025 9:03:00'),(560,'MTR6mutuaMadrileña25','mutuaMadrileña','',0,'24/08/2025 9:03:00','11/07/2025 9:03:00'),(561,'MTR7naturgy25','naturgy','',0,'03/03/2025 9:03:00','26/05/2025 9:03:00'),(562,'MTR8naturgy25','naturgy','',0,'05/06/2025 9:03:00','29/04/2025 9:03:00'),(563,'MTR9naturgy25','naturgy','',0,'12/08/2025 9:03:00','03/07/2025 9:03:00'),(564,'MTR10SAP25','SAP','',0,'25/02/2025 9:03:00','25/06/2025 9:03:00'),(565,'MTR11mutuaMadrileña25','mutuaMadrileña','',0,'11/07/2025 9:03:00','02/06/2025 9:03:00'),(566,'MTR12naturgy25','naturgy','',0,'06/07/2025 9:03:00','12/04/2025 9:03:00'),(567,'MTR13mutuaMadrileña25','mutuaMadrileña','',0,'16/10/2025 9:03:00','04/05/2025 9:03:00'),(568,'MTR14naturgy25','naturgy','',0,'31/07/2025 9:03:00','25/03/2025 9:03:00'),(569,'MTR15mutuaMadrileña25','mutuaMadrileña','',0,'24/07/2025 9:03:00','04/03/2025 9:03:00'),(570,'MTR16SAP25','SAP','',0,'08/09/2025 9:03:00','09/03/2025 9:03:00'),(571,'MTR17santander25','santander','',0,'17/08/2025 9:03:00','24/06/2025 9:03:00'),(572,'MTR18mutuaMadrileña25','mutuaMadrileña','',0,'13/07/2025 9:03:00','28/02/2025 9:03:00'),(573,'MTR19allegro25','allegro','',0,'15/06/2025 9:03:00','11/05/2025 9:03:00');
/*!40000 ALTER TABLE `proyecto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proyecto_has_empleado`
--

DROP TABLE IF EXISTS `proyecto_has_empleado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `proyecto_has_empleado` (
  `IDPROYECTO` int NOT NULL,
  `IDEMPLEADO` int NOT NULL,
  `FECHA` date NOT NULL,
  `COSTES` float NOT NULL,
  `HORAS` int NOT NULL,
  PRIMARY KEY (`IDPROYECTO`,`IDEMPLEADO`,`FECHA`),
  KEY `fk_PROYECTO_has_EMPLEADO_PROYECTO1_idx` (`IDPROYECTO`),
  CONSTRAINT `fk_PROYECTO_has_EMPLEADO_PROYECTO1` FOREIGN KEY (`IDPROYECTO`) REFERENCES `proyecto` (`IDPROYECTO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proyecto_has_empleado`
--

LOCK TABLES `proyecto_has_empleado` WRITE;
/*!40000 ALTER TABLE `proyecto_has_empleado` DISABLE KEYS */;
/*!40000 ALTER TABLE `proyecto_has_empleado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rol`
--

DROP TABLE IF EXISTS `rol`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rol` (
  `IDROL` int NOT NULL,
  `NOMBREROL` varchar(64) NOT NULL,
  `DESCROL` varchar(1024) NOT NULL,
  PRIMARY KEY (`IDROL`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rol`
--

LOCK TABLES `rol` WRITE;
/*!40000 ALTER TABLE `rol` DISABLE KEYS */;
INSERT INTO `rol` VALUES (1,'senior','programador senior'),(2,'junior','programador junior'),(3,'jefep','jefe de proyecto');
/*!40000 ALTER TABLE `rol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `IDUSUARIO` int NOT NULL AUTO_INCREMENT,
  `NOMBREUSUARIO` varchar(32) NOT NULL,
  `PASSUSUARIO` varchar(256) NOT NULL,
  PRIMARY KEY (`IDUSUARIO`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (3,'lucia','5e96a6cf706c46feaeda94715b59ffa61c09f2d46c122ce7456f385de6c51a06'),(4,'alejandro','dd130a849d7b29e5541b05d2f7f86a4acd4f1ec598c1c9438783f56bc4f0ff80'),(29,'carlos','e7c5e4e687eba0c36d42eb00e0b4779d98247b1932fbfa85d2eea25332ba2525'),(30,'juan','bb9bb98fd33ba0b8da5c6448068a95bcdeed75354e224d6253e37441b40f31ae');
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

-- Dump completed on 2025-01-28 19:48:10
