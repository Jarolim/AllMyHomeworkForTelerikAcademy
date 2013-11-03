SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `UniversitySystem` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `UniversitySystem` ;

-- -----------------------------------------------------
-- Table `UniversitySystem`.`Faculties`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `UniversitySystem`.`Faculties` (
  `Id` INT NOT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(45) NULL ,
  PRIMARY KEY (`Id`) ,
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitySystem`.`Departments`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `UniversitySystem`.`Departments` (
  `Id` INT NOT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(45) NULL ,
  `Faculties_Id` INT NOT NULL ,
  PRIMARY KEY (`Id`) ,
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC) ,
  INDEX `fk_Departments_Faculties1_idx` (`Faculties_Id` ASC) ,
  CONSTRAINT `fk_Departments_Faculties1`
    FOREIGN KEY (`Faculties_Id` )
    REFERENCES `UniversitySystem`.`Faculties` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitySystem`.`Titles`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `UniversitySystem`.`Titles` (
  `Id` INT NOT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(45) NOT NULL ,
  PRIMARY KEY (`Id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitySystem`.`Professors`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `UniversitySystem`.`Professors` (
  `Id` INT NOT NULL AUTO_INCREMENT ,
  `FirstName` VARCHAR(45) NOT NULL ,
  `LastName` VARCHAR(45) NOT NULL ,
  `Titles_Id` INT NOT NULL ,
  `Departments_Id` INT NOT NULL ,
  PRIMARY KEY (`Id`) ,
  INDEX `fk_Professors_Titles_idx` (`Titles_Id` ASC) ,
  INDEX `fk_Professors_Departments1_idx` (`Departments_Id` ASC) ,
  CONSTRAINT `fk_Professors_Titles`
    FOREIGN KEY (`Titles_Id` )
    REFERENCES `UniversitySystem`.`Titles` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Professors_Departments1`
    FOREIGN KEY (`Departments_Id` )
    REFERENCES `UniversitySystem`.`Departments` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitySystem`.`Courses`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `UniversitySystem`.`Courses` (
  `Id` INT NOT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(45) NOT NULL ,
  `Professors_Id` INT NOT NULL ,
  PRIMARY KEY (`Id`) ,
  INDEX `fk_Courses_Professors1_idx` (`Professors_Id` ASC) ,
  CONSTRAINT `fk_Courses_Professors1`
    FOREIGN KEY (`Professors_Id` )
    REFERENCES `UniversitySystem`.`Professors` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitySystem`.`Students`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `UniversitySystem`.`Students` (
  `Id` INT NOT NULL AUTO_INCREMENT ,
  `FirstName` VARCHAR(45) NOT NULL ,
  `LastName` VARCHAR(45) NOT NULL ,
  `Faculties_Id` INT NOT NULL ,
  PRIMARY KEY (`Id`) ,
  INDEX `fk_Students_Faculties1_idx` (`Faculties_Id` ASC) ,
  CONSTRAINT `fk_Students_Faculties1`
    FOREIGN KEY (`Faculties_Id` )
    REFERENCES `UniversitySystem`.`Faculties` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitySystem`.`CourseEnrollments`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `UniversitySystem`.`CourseEnrollments` (
  `Id` INT NOT NULL AUTO_INCREMENT ,
  `Students_Id` INT NOT NULL ,
  `Courses_Id` INT NOT NULL ,
  PRIMARY KEY (`Id`) ,
  INDEX `fk_CourseEnrollments_Students1_idx` (`Students_Id` ASC) ,
  INDEX `fk_CourseEnrollments_Courses1_idx` (`Courses_Id` ASC) ,
  CONSTRAINT `fk_CourseEnrollments_Students1`
    FOREIGN KEY (`Students_Id` )
    REFERENCES `UniversitySystem`.`Students` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_CourseEnrollments_Courses1`
    FOREIGN KEY (`Courses_Id` )
    REFERENCES `UniversitySystem`.`Courses` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `UniversitySystem` ;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
