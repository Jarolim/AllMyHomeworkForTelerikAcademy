SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `supermarket` DEFAULT CHARACTER SET utf8 ;
USE `supermarket` ;

-- -----------------------------------------------------
-- Table `supermarket`.`measures`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `supermarket`.`measures` (
  `ID` INT(11) NOT NULL ,
  `Measure Name` VARCHAR(200) NULL DEFAULT NULL ,
  PRIMARY KEY (`ID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `supermarket`.`vendors`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `supermarket`.`vendors` (
  `ID` INT(11) NOT NULL ,
  `Vendor Name` VARCHAR(200) NULL DEFAULT NULL ,
  PRIMARY KEY (`ID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `supermarket`.`products`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `supermarket`.`products` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT ,
  `Product Name` VARCHAR(200) NOT NULL ,
  `Base Price` DECIMAL(10,2) NOT NULL ,
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
INSERT INTO `supermarket`.`measures` (`ID`, `Measure Name`) VALUES (100, 'liters');
INSERT INTO `supermarket`.`measures` (`ID`, `Measure Name`) VALUES (200, 'pieces');
INSERT INTO `supermarket`.`measures` (`ID`, `Measure Name`) VALUES (300, 'grams');
INSERT INTO `supermarket`.`measures` (`ID`, `Measure Name`) VALUES (400, 'packs');
INSERT INTO `supermarket`.`measures` (`ID`, `Measure Name`) VALUES (500, 'kg');

COMMIT;

-- -----------------------------------------------------
-- Data for table `supermarket`.`vendors`
-- -----------------------------------------------------
START TRANSACTION;
USE `supermarket`;
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor Name`) VALUES (10, 'Zagorka OOD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor Name`) VALUES (20, 'Vin Prom Targovishte OOD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor Name`) VALUES (30, 'Beck\'s LTD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor Name`) VALUES (40, 'Nestle Corp.');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor Name`) VALUES (50, 'Svoge LTD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor Name`) VALUES (60, 'Kamenitza OOD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor Name`) VALUES (70, 'Bourgas Salams LTD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor Name`) VALUES (80, 'Ariana Corp.');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor Name`) VALUES (90, 'LIDL Corp.');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor Name`) VALUES (100, 'Haribo Sweets LTD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor Name`) VALUES (110, 'Amstel OOD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor Name`) VALUES (120, 'Haineken LTD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor Name`) VALUES (130, 'LEKI Corp.');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor Name`) VALUES (140, 'Sami M OOD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor Name`) VALUES (150, 'Jim Beam LTD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor Name`) VALUES (160, 'Sobieski OOD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor Name`) VALUES (170, '7Days Corp.');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor Name`) VALUES (180, 'Milka OOD');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor Name`) VALUES (190, 'Deroni Corp');
INSERT INTO `supermarket`.`vendors` (`ID`, `Vendor Name`) VALUES (200, 'Olineza Corp.');

COMMIT;

-- -----------------------------------------------------
-- Data for table `supermarket`.`products`
-- -----------------------------------------------------
START TRANSACTION;
USE `supermarket`;
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (1, '10', Beer "Zagorka", 100, 1);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (2, '20', Vodka "Targovishte", 100, 8);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (3, '30', Beer "Beck's", 100, 1);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (4, '40', Chocolate "Nestle", 300, 3);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (5, '50', Chocolate "Svoge", 300, 2);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (6, '60', Beer "Kamenitza", 100, 1);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (7, '70', Shpek "Bourgas", 300, 7);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (8, '80', Beer "Ariana", 100, 1);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (9, '90', Popcorn "Lidl", 200, 1);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (10, '100', Gummy Bears "Haribo", 300, 4);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (11, '110', Beer "Amstel", 100, 1);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (12, '120', Beer "Haineken", 100, 3);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (13, '130', Shpek "Leki", 300, 6);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (14, '130', Teleshki Salam "Leki", 300, 3);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (15, '130', Kamchiq Salam "Leki", 300, 3);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (16, '140', Shpek "Sami M", 300, 5);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (17, '90', Donut "Lidl", 200, 1);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (18, '150', Whiskey "JB", 100, 17);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (19, '160', Vodka "Sobieski", 100, 12);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (20, '200', Lutenica "Olineza", 100, 4);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (21, '200', Majoneza "Olineza", 100, 4);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (22, '200', Ketchup "Olineza", 100, 2);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (23, '200', Gorchitza "Olineza", 100, 1);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (24, '200', Ketchup Detski "Olineza", 100, 2);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (25, '170', Kroasan "7Days", 300, 1);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (26, '170', Suha Pasta "7Days", 300, 1);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (27, '170', Vafla "7Days", 300, 0);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (28, '40', Neskafe "Nestle", 200, 0);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (29, '40', Nestea "Nestle", 100, 3);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (30, '40', Figaro "Nestle", 300, 4);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (31, '40', Almond "Nestle", 300, 4);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (32, '40', Vafla "Nestle", 300, 1);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (33, '180', Chocolate "Milka", 300, 2);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (34, '180', Vafla "Milka", 300, 1);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (35, '180', Bonboni "Milka", 300, 4);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (36, '180', Biskviti "Milka", 300, 3);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (37, '190', Lutenitza "Deroni", 100, 4);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (38, '190', Ketchup "Deroni", 100, 3);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (39, '190', Majoneza "Deroni", 100, 4);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (40, '190', Gorchitza "Deroni", 100, 2);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (41, '190', Ketchup Detski "Deroni", 100, 2);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (42, '130', Nadenitza "Leki", 300, 5);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (43, '130', Lionska Nadenitza "Leki", 300, 6);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (44, '140', Nadenitza "Sami M", 300, 5);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (45, '140', Teleshki Salam "Sami M", 300, 3);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (46, '140', Kamchiq Salam "Sami M", 300, 3);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (47, '140', Kajma "Sami M", 300, 3);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (48, '130', Kajma "Leki", 300, 3);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (49, '190', Sos Tartar "Deroni", 100, 4);
INSERT INTO `supermarket`.`products` (`ID`, `Product Name`, `Base Price`, `measures_ID`, `vendors_ID`) VALUES (50, '200', Sos Barbecue "Olineza", 100, 4);

COMMIT;
