SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `supermarket` DEFAULT CHARACTER SET utf8 ;
USE `supermarket` ;

-- -----------------------------------------------------
-- Table `supermarket`.`measures`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `supermarket`.`measures` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT ,
  `Measure_Name` VARCHAR(200) NULL DEFAULT NULL ,
  PRIMARY KEY (`ID`) ,
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `supermarket`.`vendors`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `supermarket`.`vendors` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT ,
  `Vendor_Name` VARCHAR(200) NULL ,
  PRIMARY KEY (`ID`) ,
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `supermarket`.`products`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `supermarket`.`products` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT ,
  `Product_Name` VARCHAR(200) NOT NULL ,
  `Base_Price` DECIMAL(10,2) NOT NULL ,
  `measures_ID` INT(11) NOT NULL ,
  `vendors_ID` INT(11) NOT NULL ,
  PRIMARY KEY (`ID`) ,
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC) ,
  INDEX `fk_products_measures_idx` (`measures_ID` ASC) ,
  INDEX `fk_products_vendors1_idx` (`vendors_ID` ASC) ,
  CONSTRAINT `fk_products_measures`
    FOREIGN KEY (`measures_ID` )
    REFERENCES `supermarket`.`measures` (`ID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_products_vendors1`
    FOREIGN KEY (`vendors_ID` )
    REFERENCES `supermarket`.`vendors` (`ID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 51
DEFAULT CHARACTER SET = utf8;

USE `supermarket` ;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- Data for table `supermarket`.`measures`
-- -----------------------------------------------------
START TRANSACTION;
USE `supermarket`;
INSERT INTO `supermarket`.`measures` (`ID`, `Measure_Name`) VALUES (1, 'liters');
INSERT INTO `supermarket`.`measures` (`ID`, `Measure_Name`) VALUES (2, 'pieces');
INSERT INTO `supermarket`.`measures` (`ID`, `Measure_Name`) VALUES (3, 'grams');
INSERT INTO `supermarket`.`measures` (`ID`, `Measure_Name`) VALUES (4, 'packs');
INSERT INTO `supermarket`.`measures` (`ID`, `Measure_Name`) VALUES (5, 'kg');

COMMIT;

-- -----------------------------------------------------
-- Data for table `supermarket`.`vendors`
-- -----------------------------------------------------
START TRANSACTION;
USE `supermarket`;
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor_Name`) VALUES (1, 'Zagorka OOD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor_Name`) VALUES (2, 'Vin Prom Targovishte OOD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor_Name`) VALUES (3, 'Beck\'s LTD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor_Name`) VALUES (4, 'Nestle Corp.');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor_Name`) VALUES (5, 'Svoge LTD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor_Name`) VALUES (6, 'Kamenitza OOD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor_Name`) VALUES (7, 'Bourgas Salams LTD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor_Name`) VALUES (8, 'Ariana Corp.');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor_Name`) VALUES (9, 'LIDL Corp.');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor_Name`) VALUES (10, 'Haribo Sweets LTD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor_Name`) VALUES (11, 'Amstel OOD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor_Name`) VALUES (12, 'Haineken LTD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor_Name`) VALUES (13, 'LEKI Corp.');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor_Name`) VALUES (14, 'Sami M OOD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor_Name`) VALUES (15, 'Jim Beam LTD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor_Name`) VALUES (16, 'Sobieski OOD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor_Name`) VALUES (17, '7Days Corp.');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor_Name`) VALUES (18, 'Milka OOD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor_Name`) VALUES (19, 'Deroni Corp');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor_Name`) VALUES (20, 'Olineza Corp.');

COMMIT;

-- -----------------------------------------------------
-- Data for table `supermarket`.`products`
-- -----------------------------------------------------
START TRANSACTION;
USE `supermarket`;
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (1, 'Beer \"Zagorka\"', 0.95, 1, 1);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (2, 'Vodka \"Targovishte\"', 7.85, 1, 2);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (3, '30Beer \"Beck\'s\"', 0.69, 1, 3);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (4, 'Chocolate \"Nestle\"', 2.8, 3, 4);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (5, 'Chocolate \"Svoge\"', 2.2, 3, 5);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (6, 'Beer \"Kamenitza\"', 1, 1, 6);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (7, 'Shpek \"Bourgas\"', 6.36, 3, 7);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (8, 'Beer \"Ariana\"', 0.95, 1, 8);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (9, 'Popcorn \"Lidl\"', 0.55, 2, 9);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (10, 'Gummy Bears \"Haribo\"', 3.25, 3, 10);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (11, 'Beer \"Amstel\"', 0.95, 1, 11);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (12, 'Beer \"Haineken\"', 3.2, 1, 12);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (13, 'Shpek \"Leki\"', 6.99, 3, 13);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (14, 'Teleshki Salam \"Leki\"', 2.8, 3, 13);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (15, 'Kamchiq Salam \"Leki\"', 3.2, 3, 13);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (16, 'Shpek \"Sami M\"', 5.69, 3, 14);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (17, 'Donut \"Lidl\"', 0.65, 2, 9);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (18, 'Whiskey \"JB\"', 17.89, 1, 15);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (19, 'Vodka \"Sobieski\"', 13.25, 1, 16);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (20, 'Lutenica \"Olineza\"', 3.99, 1, 20);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (21, 'Majoneza \"Olineza\"', 4.25, 1, 20);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (22, 'Ketchup \"Olineza\"', 1.65, 1, 20);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (23, 'Gorchitza \"Olineza\"', 1, 1, 20);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (24, 'Ketchup Detski \"Olineza\"', 3.65, 1, 20);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (25, 'Kroasan \"7Days\"', 0.95, 3, 17);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (26, 'Suha Pasta \"7Days\"', 0.4, 3, 17);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (27, 'Vafla \"7Days\"', 0.3, 3, 17);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (28, 'Neskafe \"Nestle\"', 0.29, 2, 4);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (29, 'Nestea \"Nestle\"', 3.2, 1, 4);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (30, 'Figaro \"Nestle\"', 3.88, 3, 4);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (31, 'Almond \"Nestle\"', 3.99, 3, 4);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (32, 'Vafla \"Nestle\"', 0.5, 3, 4);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (33, 'Chocolate \"Milka\"', 2.2, 3, 18);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (34, 'Vafla \"Milka\"', 0.65, 3, 18);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (35, 'Bonboni \"Milka\"', 3.99, 3, 18);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (36, 'Biskviti \"Milka\"', 2.33, 3, 18);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (37, 'Lutenitza \"Deroni\"', 3.99, 1, 19);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (38, 'Ketchup \"Deroni\"', 1.99, 1, 19);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (39, 'Majoneza \"Deroni\"', 3.98, 1, 19);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (40, 'Gorchitza \"Deroni\"', 1.65, 1, 19);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (41, 'Ketchup Detski \"Deroni\"', 3.22, 1, 19);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (42, 'Nadenitza \"Leki\"', 4.55, 3, 13);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (43, 'Lionska Nadenitza \"Leki\"', 3.66, 3, 13);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (44, 'Nadenitza \"Sami M\"', 4.22, 3, 14);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (45, 'Teleshki Salam \"Sami M\"', 3.2, 3, 14);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (46, 'Kamchiq Salam \"Sami M\"', 3.5, 3, 14);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (47, 'Kajma \"Sami M\"', 3.99, 3, 14);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (48, 'Kajma \"Leki\"', 3.66, 3, 13);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (49, 'Sos Tartar \"Deroni\"', 3.2, 1, 19);
INSERT INTO `supermarket`.`products` (`ID`, `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES (50, 'Sos Barbecue \"Olineza\"', 3.5, 1, 20);

COMMIT;
