-- --------------------------------------------------------
-- Host:                         csitmariadb.eku.edu
-- Server version:               10.8.3-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             12.6.0.6765
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for csc340_db
CREATE DATABASE IF NOT EXISTS `csc340_db` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `csc340_db`;

-- Dumping structure for table csc340_db.kellammember
CREATE TABLE IF NOT EXISTS `kellammember` (
  `member_id` int(4) NOT NULL AUTO_INCREMENT,
  `member_name` varchar(50) NOT NULL DEFAULT '',
  `member_address` varchar(100) NOT NULL DEFAULT '',
  `member_email` varchar(50) NOT NULL DEFAULT '',
  `member_password` varchar(50) NOT NULL DEFAULT '',
  `member_phone` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`member_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table csc340_db.kellampizza
CREATE TABLE IF NOT EXISTS `kellampizza` (
  `pizza_id` int(3) NOT NULL AUTO_INCREMENT,
  `pizza_name` varchar(50) NOT NULL,
  `pizza_price` decimal(5,2) NOT NULL,
  `pizza_descr` varchar(200) NOT NULL DEFAULT '',
  PRIMARY KEY (`pizza_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table csc340_db.kellam_orders
CREATE TABLE IF NOT EXISTS `kellam_orders` (
  `order_id` int(11) NOT NULL AUTO_INCREMENT,
  `member_id` int(11) DEFAULT NULL,
  `order_date` datetime DEFAULT NULL,
  `total_amount` decimal(10,2) DEFAULT NULL,
  `status` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`order_id`),
  KEY `member_id` (`member_id`),
  CONSTRAINT `kellam_orders_ibfk_1` FOREIGN KEY (`member_id`) REFERENCES `kellammember` (`member_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

-- Dumping structure for table csc340_db.kellam_order_details
CREATE TABLE IF NOT EXISTS `kellam_order_details` (
  `detail_id` int(11) NOT NULL AUTO_INCREMENT,
  `order_id` int(11) DEFAULT NULL,
  `pizza_id` int(11) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `price` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`detail_id`),
  KEY `order_id` (`order_id`),
  KEY `pizza_id` (`pizza_id`),
  CONSTRAINT `kellam_order_details_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `kellam_orders` (`order_id`),
  CONSTRAINT `kellam_order_details_ibfk_2` FOREIGN KEY (`pizza_id`) REFERENCES `kellampizza` (`pizza_id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
