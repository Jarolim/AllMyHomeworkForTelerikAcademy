SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE DATABASE IF NOT EXISTS `bookStores`;
CREATE SCHEMA IF NOT EXISTS `bookStores` DEFAULT CHARACTER SET utf8 ;
USE `bookStores` ;

-- -----------------------------------------------------
-- Table `books`.`Books`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `bookStores`.`Books` ;

CREATE  TABLE IF NOT EXISTS `bookStores`.`Books` (
  `idBooks` INT NOT NULL AUTO_INCREMENT ,
  `titleBook` VARCHAR(45) NOT NULL ,
  `publishDate` DATE NOT NULL ,
  `ISBN` BIGINT NOT NULL ,
  PRIMARY KEY (`idBooks`) ,
  UNIQUE INDEX `idBooks_UNIQUE` (`idBooks` ASC) ,
  UNIQUE INDEX `ISBN_UNIQUE` (`ISBN` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `books`.`Authors`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `bookStores`.`Authors` ;

CREATE  TABLE IF NOT EXISTS `bookStores`.`Authors` (
  `idAuthors` INT(11) NOT NULL AUTO_INCREMENT ,
  `AuthorName` VARCHAR(45) NULL DEFAULT NULL ,
  `Books_idBooks` INT NOT NULL ,
  PRIMARY KEY (`idAuthors`, `Books_idBooks`) ,
  UNIQUE INDEX `idAuthors_UNIQUE` (`idAuthors` ASC) ,
  UNIQUE INDEX `AuthorName_UNIQUE` (`AuthorName` ASC) ,
  INDEX `fk_Authors_Books_idx` (`Books_idBooks` ASC) ,
  CONSTRAINT `fk_Authors_Books`
    FOREIGN KEY (`Books_idBooks` )
    REFERENCES `bookStores`.`Books` (`idBooks` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


USE `bookStores` ;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
