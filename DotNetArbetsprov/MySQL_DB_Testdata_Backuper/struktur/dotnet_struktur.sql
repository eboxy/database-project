/*
SQLyog Enterprise - MySQL GUI v7.12 RC2
MySQL - 5.0.45-log : Database - tomstation_net
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

CREATE DATABASE /*!32312 IF NOT EXISTS*/`tomstation_net` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `tomstation_net`;

/*Table structure for table `artist_net` */

DROP TABLE IF EXISTS `artist_net`;

CREATE TABLE `artist_net` (
  `No` int(6) NOT NULL auto_increment,
  `ValArt` tinyint(1) NOT NULL default '0',
  `Artist` varchar(50) NOT NULL,
  `VPfr` varchar(4) NOT NULL,
  `VPtill` varchar(10) NOT NULL,
  `Ursland` varchar(5) NOT NULL,
  `Ursstad` varchar(50) NOT NULL,
  `Musiktyp` varchar(50) NOT NULL,
  `Kortbio` varchar(6000) NOT NULL,
  PRIMARY KEY  (`No`)
) ENGINE=InnoDB AUTO_INCREMENT=252 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `cd_net` */

DROP TABLE IF EXISTS `cd_net`;

CREATE TABLE `cd_net` (
  `#` int(6) unsigned NOT NULL auto_increment,
  `Val` tinyint(1) NOT NULL default '0',
  `Artist_no` int(6) NOT NULL,
  `Album` varchar(80) NOT NULL,
  `Format` varchar(15) NOT NULL,
  `Press` varchar(5) NOT NULL,
  `Ar` varchar(4) NOT NULL,
  `Kommentar` varchar(1000) NOT NULL default 'No Comment',
  PRIMARY KEY  (`#`),
  KEY `Artist_no` (`Artist_no`),
  CONSTRAINT `cd_net_ibfk_1` FOREIGN KEY (`Artist_no`) REFERENCES `artist_net` (`No`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=48 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `inkop_net` */

DROP TABLE IF EXISTS `inkop_net`;

CREATE TABLE `inkop_net` (
  `Skiv_no` int(6) unsigned NOT NULL auto_increment,
  `ValInk` tinyint(1) NOT NULL default '0',
  `Art_no` int(6) NOT NULL,
  `Titel` varchar(80) NOT NULL,
  `Form` varchar(15) NOT NULL,
  `Land` varchar(5) NOT NULL,
  `Utg` varchar(4) NOT NULL,
  `Komt` varchar(1000) NOT NULL,
  `Inm_dat` varchar(10) NOT NULL,
  `Kop_grad` varchar(1) NOT NULL,
  `Kop_kat` varchar(10) NOT NULL,
  `Ca_pris` varchar(4) NOT NULL,
  PRIMARY KEY  (`Skiv_no`),
  KEY `Art_no` (`Art_no`),
  CONSTRAINT `FK_inkop_net` FOREIGN KEY (`Art_no`) REFERENCES `artist_net` (`No`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
