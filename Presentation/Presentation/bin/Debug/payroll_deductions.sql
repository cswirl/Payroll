-- MySQL dump 10.13  Distrib 5.1.49, for Win32 (ia32)
--
-- Host: localhost    Database: payroll_deductions
-- ------------------------------------------------------
-- Server version	5.1.49-community

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
-- Table structure for table `tblbasebracket`
--

DROP TABLE IF EXISTS `tblbasebracket`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblbasebracket` (
  `baseBracket` decimal(10,2) NOT NULL,
  `payMethod` enum('Daily','Weekly','Semi','Monthly') NOT NULL,
  `baseCode` enum('1','2','3','4','5','6','7','8') NOT NULL,
  PRIMARY KEY (`payMethod`,`baseCode`),
  KEY `fk_tblbasebracket_tblbasebracket_over1` (`baseCode`),
  CONSTRAINT `fk_tblbasebracket_tblbasebracket_over1` FOREIGN KEY (`baseCode`) REFERENCES `tblbasebracket_over` (`baseCode`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblbasebracket`
--

LOCK TABLES `tblbasebracket` WRITE;
/*!40000 ALTER TABLE `tblbasebracket` DISABLE KEYS */;
INSERT INTO `tblbasebracket` VALUES ('0.00','Daily','1'),('0.00','Daily','2'),('1.65','Daily','3'),('8.25','Daily','4'),('28.05','Daily','5'),('74.26','Daily','6'),('165.02','Daily','7'),('412.54','Daily','8'),('0.00','Weekly','1'),('0.00','Weekly','2'),('9.62','Weekly','3'),('48.08','Weekly','4'),('163.46','Weekly','5'),('432.69','Weekly','6'),('961.54','Weekly','7'),('2403.85','Weekly','8'),('0.00','Semi','1'),('0.00','Semi','2'),('20.83','Semi','3'),('104.17','Semi','4'),('354.17','Semi','5'),('937.50','Semi','6'),('2083.33','Semi','7'),('5208.33','Semi','8'),('0.00','Monthly','1'),('0.00','Monthly','2'),('0.00','Monthly','3'),('0.00','Monthly','4'),('0.00','Monthly','5'),('0.00','Monthly','6'),('0.00','Monthly','7'),('0.00','Monthly','8');
/*!40000 ALTER TABLE `tblbasebracket` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblbasebracket_over`
--

DROP TABLE IF EXISTS `tblbasebracket_over`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblbasebracket_over` (
  `baseCode` enum('1','2','3','4','5','6','7','8') NOT NULL,
  `over` decimal(5,2) NOT NULL,
  PRIMARY KEY (`baseCode`),
  UNIQUE KEY `over_UNIQUE` (`over`),
  UNIQUE KEY `baseCode_UNIQUE` (`baseCode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblbasebracket_over`
--

LOCK TABLES `tblbasebracket_over` WRITE;
/*!40000 ALTER TABLE `tblbasebracket_over` DISABLE KEYS */;
INSERT INTO `tblbasebracket_over` VALUES ('1','0.00'),('2','0.05'),('3','0.10'),('4','0.15'),('5','0.20'),('6','0.25'),('7','0.30'),('8','0.32');
/*!40000 ALTER TABLE `tblbasebracket_over` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblphilhealth`
--

DROP TABLE IF EXISTS `tblphilhealth`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblphilhealth` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `rangeFrom` decimal(10,2) unsigned zerofill NOT NULL DEFAULT '00000000.00',
  `rangeTo` decimal(10,2) unsigned zerofill NOT NULL DEFAULT '00000000.00',
  `sal_base` decimal(10,2) unsigned zerofill NOT NULL DEFAULT '00000000.00',
  `ees` decimal(10,2) unsigned zerofill NOT NULL DEFAULT '00000000.00',
  `ers` decimal(10,2) unsigned zerofill NOT NULL DEFAULT '00000000.00',
  `tmc` decimal(10,2) unsigned zerofill NOT NULL DEFAULT '00000000.00',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=55 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblphilhealth`
--

LOCK TABLES `tblphilhealth` WRITE;
/*!40000 ALTER TABLE `tblphilhealth` DISABLE KEYS */;
INSERT INTO `tblphilhealth` VALUES (28,'00004999.99','00000000.00','00004000.00','00000050.00','00000050.00','00000100.00'),(29,'00005000.00','00005999.99','00005000.00','00000062.50','00000062.50','00000125.00'),(30,'00006000.00','00006999.99','00006000.00','00000075.00','00000075.00','00000150.00'),(31,'00007000.00','00007999.99','00007000.00','00000087.50','00000087.50','00000175.00'),(32,'00008000.00','00008999.99','00008000.00','00000100.00','00000100.00','00000200.00'),(33,'00009000.00','00009999.99','00009000.00','00000112.50','00000112.50','00000225.00'),(34,'00010000.00','00010999.99','00010000.00','00000125.00','00000125.00','00000250.00'),(35,'00011000.00','00011999.99','00011000.00','00000137.50','00000137.50','00000275.00'),(36,'00012000.00','00012999.99','00012000.00','00000150.00','00000150.00','00000300.00'),(37,'00013000.00','00013999.99','00013000.00','00000162.50','00000162.50','00000325.00'),(38,'00014000.00','00014999.99','00014000.00','00000175.00','00000175.00','00000350.00'),(39,'00015000.00','00015999.99','00015000.00','00000187.50','00000187.50','00000375.00'),(40,'00016000.00','00016999.99','00016000.00','00000200.00','00000200.00','00000400.00'),(41,'00017000.00','00017999.99','00017000.00','00000212.50','00000212.50','00000425.00'),(42,'00018000.00','00018999.99','00018000.00','00000225.00','00000225.00','00000450.00'),(43,'00019000.00','00019999.99','00019000.00','00000237.50','00000237.50','00000475.00'),(44,'00020000.00','00020999.99','00020000.00','00000250.00','00000250.00','00000500.00'),(45,'00021000.00','00021999.99','00021000.00','00000262.50','00000262.50','00000525.00'),(46,'00022000.00','00022999.99','00022000.00','00000275.00','00000275.00','00000550.00'),(47,'00023000.00','00023999.99','00023000.00','00000287.50','00000287.50','00000575.00'),(48,'00024000.00','00024999.99','00024000.00','00000300.00','00000300.00','00000600.00'),(49,'00025000.00','00025999.99','00025000.00','00000312.50','00000312.50','00000625.00'),(50,'00026000.00','00026999.99','00026000.00','00000325.00','00000325.00','00000650.00'),(51,'00027000.00','00027999.99','00027000.00','00000337.50','00000337.50','00000675.00'),(52,'00028000.00','00028999.99','00028000.00','00000350.00','00000350.00','00000700.00'),(53,'00029000.00','00029999.99','00029000.00','00000362.50','00000362.50','00000725.00'),(54,'00030000.00','09999999.00','00030000.00','00000375.00','00000375.00','00000750.00');
/*!40000 ALTER TABLE `tblphilhealth` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblsss`
--

DROP TABLE IF EXISTS `tblsss`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblsss` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `rangeFrom` decimal(10,2) unsigned zerofill NOT NULL DEFAULT '00000000.00',
  `rangeTo` decimal(10,2) unsigned zerofill NOT NULL DEFAULT '00000000.00',
  `er_1` decimal(10,2) unsigned zerofill NOT NULL DEFAULT '00000000.00',
  `ee_1` decimal(10,2) unsigned zerofill NOT NULL DEFAULT '00000000.00',
  `total_1` decimal(10,2) unsigned zerofill NOT NULL DEFAULT '00000000.00',
  `er_2` int(10) unsigned NOT NULL DEFAULT '0',
  `er_3` decimal(10,2) unsigned NOT NULL DEFAULT '0.00',
  `ee_2` decimal(10,2) unsigned zerofill NOT NULL DEFAULT '00000000.00',
  `total_2` decimal(10,2) unsigned zerofill NOT NULL DEFAULT '00000000.00',
  `total_contri` decimal(10,2) unsigned zerofill NOT NULL DEFAULT '00000000.00',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=350 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblsss`
--

LOCK TABLES `tblsss` WRITE;
/*!40000 ALTER TABLE `tblsss` DISABLE KEYS */;
INSERT INTO `tblsss` VALUES (321,'00001000.00','00001249.99','00000070.70','00000030.00','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(322,'00001250.00','00001749.99','00000106.00','00000050.00','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(323,'00001750.00','00002249.99','00000141.30','00000066.70','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(324,'00002250.00','00002749.99','00000176.70','00000083.30','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(325,'00002750.00','00003249.99','00000212.00','00000100.00','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(326,'00003250.00','00003749.99','00000247.30','00000116.70','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(327,'00003750.00','00004249.99','00000282.70','00000133.30','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(328,'00004250.00','00004749.99','00000318.00','00000150.00','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(329,'00004750.00','00005249.99','00000353.30','00000166.70','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(330,'00005250.00','00005749.99','00000388.70','00000183.30','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(331,'00005750.00','00006249.99','00000424.00','00000200.00','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(332,'00006250.00','00006749.99','00000459.30','00000216.70','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(333,'00006750.00','00007249.99','00000494.70','00000233.30','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(334,'00007250.00','00007749.99','00000530.00','00000250.00','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(335,'00007750.00','00008249.99','00000565.30','00000266.70','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(336,'00008250.00','00008749.99','00000600.70','00000283.30','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(337,'00008750.00','00009249.99','00000636.00','00000300.00','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(338,'00009250.00','00009749.99','00000671.30','00000316.70','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(339,'00009750.00','00010249.99','00000706.70','00000333.30','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(340,'00010250.00','00010749.99','00000742.00','00000350.00','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(341,'00010750.00','00011249.99','00000777.30','00000366.70','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(342,'00011250.00','00011749.99','00000812.70','00000383.30','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(343,'00011750.00','00012249.99','00000848.00','00000400.00','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(344,'00012250.00','00012749.99','00000883.30','00000416.70','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(345,'00012750.00','00013249.99','00000918.70','00000433.30','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(346,'00013250.00','00013749.99','00000954.00','00000450.00','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(347,'00013750.00','00014249.99','00000989.30','00000466.70','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(348,'00014250.00','00014749.99','00001024.70','00000483.30','00000000.00',10,'0.00','00000000.00','00000000.00','00000000.00'),(349,'00014750.00','09999999.00','00001060.00','00000500.00','00000000.00',30,'0.00','00000000.00','00000000.00','00000000.00');
/*!40000 ALTER TABLE `tblsss` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbltaxbracket`
--

DROP TABLE IF EXISTS `tbltaxbracket`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbltaxbracket` (
  `exemption` decimal(10,2) NOT NULL,
  `statusCode` tinyint(3) unsigned NOT NULL,
  `baseCode` enum('1','2','3','4','5','6','7','8') NOT NULL,
  `payMethod` enum('Daily','Weekly','Semi','Monthly') NOT NULL,
  PRIMARY KEY (`statusCode`,`baseCode`,`payMethod`),
  KEY `fk_tblTaxBracket_tblTaxPayerStatus1` (`statusCode`),
  KEY `fk_tbltaxbracket_tblbasebracket_over1` (`baseCode`),
  CONSTRAINT `fk_tbltaxbracket_tblbasebracket_over1` FOREIGN KEY (`baseCode`) REFERENCES `tblbasebracket_over` (`baseCode`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_tblTaxBracket_tblTaxPayerStatus1` FOREIGN KEY (`statusCode`) REFERENCES `tbltaxpayerstatus` (`statusCode`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbltaxbracket`
--

LOCK TABLES `tbltaxbracket` WRITE;
/*!40000 ALTER TABLE `tbltaxbracket` DISABLE KEYS */;
INSERT INTO `tbltaxbracket` VALUES ('1.00',1,'1','Daily'),('1.00',1,'1','Weekly'),('1.00',1,'1','Semi'),('0.00',1,'1','Monthly'),('0.00',1,'2','Daily'),('0.00',1,'2','Weekly'),('0.00',1,'2','Semi'),('0.00',1,'2','Monthly'),('33.00',1,'3','Daily'),('192.00',1,'3','Weekly'),('417.00',1,'3','Semi'),('0.00',1,'3','Monthly'),('99.00',1,'4','Daily'),('577.00',1,'4','Weekly'),('1250.00',1,'4','Semi'),('0.00',1,'4','Monthly'),('231.00',1,'5','Daily'),('1346.00',1,'5','Weekly'),('2917.00',1,'5','Semi'),('0.00',1,'5','Monthly'),('462.00',1,'6','Daily'),('2692.00',1,'6','Weekly'),('5833.00',1,'6','Semi'),('0.00',1,'6','Monthly'),('825.00',1,'7','Daily'),('4808.00',1,'7','Weekly'),('10417.00',1,'7','Semi'),('0.00',1,'7','Monthly'),('1650.00',1,'8','Daily'),('9615.00',1,'8','Weekly'),('20833.00',1,'8','Semi'),('0.00',1,'8','Monthly'),('1.00',2,'1','Daily'),('1.00',2,'1','Weekly'),('1.00',2,'1','Semi'),('0.00',2,'1','Monthly'),('165.00',2,'2','Daily'),('962.00',2,'2','Weekly'),('2083.00',2,'2','Semi'),('0.00',2,'2','Monthly'),('198.00',2,'3','Daily'),('1154.00',2,'3','Weekly'),('2500.00',2,'3','Semi'),('0.00',2,'3','Monthly'),('264.00',2,'4','Daily'),('1538.00',2,'4','Weekly'),('3333.00',2,'4','Semi'),('0.00',2,'4','Monthly'),('396.00',2,'5','Daily'),('2308.00',2,'5','Weekly'),('5000.00',2,'5','Semi'),('0.00',2,'5','Monthly'),('627.00',2,'6','Daily'),('3654.00',2,'6','Weekly'),('7917.00',2,'6','Semi'),('0.00',2,'6','Monthly'),('990.00',2,'7','Daily'),('5769.00',2,'7','Weekly'),('12500.00',2,'7','Semi'),('0.00',2,'7','Monthly'),('1815.00',2,'8','Daily'),('10577.00',2,'8','Weekly'),('22917.00',2,'8','Semi'),('0.00',2,'8','Monthly'),('1.00',3,'1','Daily'),('1.00',3,'1','Weekly'),('1.00',3,'1','Semi'),('0.00',3,'1','Monthly'),('248.00',3,'2','Daily'),('1442.00',3,'2','Weekly'),('3125.00',3,'2','Semi'),('0.00',3,'2','Monthly'),('281.00',3,'3','Daily'),('1635.00',3,'3','Weekly'),('3542.00',3,'3','Semi'),('0.00',3,'3','Monthly'),('347.00',3,'4','Daily'),('2019.00',3,'4','Weekly'),('4375.00',3,'4','Semi'),('0.00',3,'4','Monthly'),('479.00',3,'5','Daily'),('2788.00',3,'5','Weekly'),('6042.00',3,'5','Semi'),('0.00',3,'5','Monthly'),('710.00',3,'6','Daily'),('4135.00',3,'6','Weekly'),('8958.00',3,'6','Semi'),('0.00',3,'6','Monthly'),('1073.00',3,'7','Daily'),('6250.00',3,'7','Weekly'),('13542.00',3,'7','Semi'),('0.00',3,'7','Monthly'),('1898.00',3,'8','Daily'),('11058.00',3,'8','Weekly'),('23958.00',3,'8','Semi'),('0.00',3,'8','Monthly'),('1.00',4,'1','Daily'),('1.00',4,'1','Weekly'),('1.00',4,'1','Semi'),('0.00',4,'1','Monthly'),('330.00',4,'2','Daily'),('1923.00',4,'2','Weekly'),('4167.00',4,'2','Semi'),('0.00',4,'2','Monthly'),('363.00',4,'3','Daily'),('2115.00',4,'3','Weekly'),('4583.00',4,'3','Semi'),('0.00',4,'3','Monthly'),('429.00',4,'4','Daily'),('2500.00',4,'4','Weekly'),('5417.00',4,'4','Semi'),('0.00',4,'4','Monthly'),('561.00',4,'5','Daily'),('3269.00',4,'5','Weekly'),('7083.00',4,'5','Semi'),('0.00',4,'5','Monthly'),('792.00',4,'6','Daily'),('4615.00',4,'6','Weekly'),('10000.00',4,'6','Semi'),('0.00',4,'6','Monthly'),('1155.00',4,'7','Daily'),('6731.00',4,'7','Weekly'),('14583.00',4,'7','Semi'),('0.00',4,'7','Monthly'),('1980.00',4,'8','Daily'),('11538.00',4,'8','Weekly'),('25000.00',4,'8','Semi'),('0.00',4,'8','Monthly'),('1.00',5,'1','Daily'),('1.00',5,'1','Weekly'),('1.00',5,'1','Semi'),('0.00',5,'1','Monthly'),('413.00',5,'2','Daily'),('2404.00',5,'2','Weekly'),('5208.00',5,'2','Semi'),('0.00',5,'2','Monthly'),('446.00',5,'3','Daily'),('2596.00',5,'3','Weekly'),('5625.00',5,'3','Semi'),('0.00',5,'3','Monthly'),('512.00',5,'4','Daily'),('2981.00',5,'4','Weekly'),('6458.00',5,'4','Semi'),('0.00',5,'4','Monthly'),('644.00',5,'5','Daily'),('3750.00',5,'5','Weekly'),('8125.00',5,'5','Semi'),('0.00',5,'5','Monthly'),('857.00',5,'6','Daily'),('5096.00',5,'6','Weekly'),('11042.00',5,'6','Semi'),('0.00',5,'6','Monthly'),('1238.00',5,'7','Daily'),('7212.00',5,'7','Weekly'),('15625.00',5,'7','Semi'),('0.00',5,'7','Monthly'),('2063.00',5,'8','Daily'),('12019.00',5,'8','Weekly'),('26042.00',5,'8','Semi'),('0.00',5,'8','Monthly'),('1.00',6,'1','Daily'),('1.00',6,'1','Weekly'),('1.00',6,'1','Semi'),('0.00',6,'1','Monthly'),('495.00',6,'2','Daily'),('2885.00',6,'2','Weekly'),('6250.00',6,'2','Semi'),('0.00',6,'2','Monthly'),('528.00',6,'3','Daily'),('3077.00',6,'3','Weekly'),('6667.00',6,'3','Semi'),('0.00',6,'3','Monthly'),('594.00',6,'4','Daily'),('3462.00',6,'4','Weekly'),('7500.00',6,'4','Semi'),('0.00',6,'4','Monthly'),('726.00',6,'5','Daily'),('4231.00',6,'5','Weekly'),('9167.00',6,'5','Semi'),('0.00',6,'5','Monthly'),('957.00',6,'6','Daily'),('5577.00',6,'6','Weekly'),('12083.00',6,'6','Semi'),('0.00',6,'6','Monthly'),('1320.00',6,'7','Daily'),('7692.00',6,'7','Weekly'),('16667.00',6,'7','Semi'),('0.00',6,'7','Monthly'),('2145.00',6,'8','Daily'),('12500.00',6,'8','Weekly'),('27083.00',6,'8','Semi'),('0.00',6,'8','Monthly');
/*!40000 ALTER TABLE `tbltaxbracket` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbltaxpayerstatus`
--

DROP TABLE IF EXISTS `tbltaxpayerstatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbltaxpayerstatus` (
  `statusCode` tinyint(3) unsigned NOT NULL,
  `status` varchar(30) NOT NULL,
  PRIMARY KEY (`statusCode`),
  UNIQUE KEY `status_UNIQUE` (`status`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbltaxpayerstatus`
--

LOCK TABLES `tbltaxpayerstatus` WRITE;
/*!40000 ALTER TABLE `tbltaxpayerstatus` DISABLE KEYS */;
INSERT INTO `tbltaxpayerstatus` VALUES (3,'ME1/S1'),(4,'ME2/S2'),(5,'ME3/S3'),(6,'ME4/S4'),(2,'S/ME'),(1,'Z');
/*!40000 ALTER TABLE `tbltaxpayerstatus` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2012-02-17 16:59:42
