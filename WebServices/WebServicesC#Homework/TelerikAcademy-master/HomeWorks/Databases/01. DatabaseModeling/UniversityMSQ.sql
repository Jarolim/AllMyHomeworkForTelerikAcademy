SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `Universities` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `Universities` ;

-- -----------------------------------------------------
-- Table `Universities`.`Faculties`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `Universities`.`Faculties` (
  `idFaculties` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NULL ,
  PRIMARY KEY (`idFaculties`) ,
  UNIQUE INDEX `idFaculties_UNIQUE` (`idFaculties` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Universities`.`Departments`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `Universities`.`Departments` (
  `idDepartments` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NULL ,
  `Faculties_idFaculties` INT NOT NULL ,
  PRIMARY KEY (`idDepartments`, `Faculties_idFaculties`) ,
  UNIQUE INDEX `idDepartments_UNIQUE` (`idDepartments` ASC) ,
  INDEX `fk_Departments_Faculties_idx` (`Faculties_idFaculties` ASC) ,
  CONSTRAINT `fk_Departments_Faculties`
    FOREIGN KEY (`Faculties_idFaculties` )
    REFERENCES `Universities`.`Faculties` (`idFaculties` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Universities`.`Professors`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `Universities`.`Professors` (
  `idProfessors` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NULL ,
  `Departments_idDepartments` INT NOT NULL ,
  PRIMARY KEY (`idProfessors`, `Departments_idDepartments`) ,
  UNIQUE INDEX `idProfessors_UNIQUE` (`idProfessors` ASC) ,
  INDEX `fk_Professors_Departments1_idx` (`Departments_idDepartments` ASC) ,
  CONSTRAINT `fk_Professors_Departments1`
    FOREIGN KEY (`Departments_idDepartments` )
    REFERENCES `Universities`.`Departments` (`idDepartments` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Universities`.`Courses`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `Universities`.`Courses` (
  `idCourses` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NULL ,
  `Departments_idDepartments` INT NOT NULL ,
  `Professors_idProfessors` INT NOT NULL ,
  UNIQUE INDEX `idCourses_UNIQUE` (`idCourses` ASC) ,
  PRIMARY KEY (`idCourses`, `Departments_idDepartments`, `Professors_idProfessors`) ,
  INDEX `fk_Courses_Departments1_idx` (`Departments_idDepartments` ASC) ,
  INDEX `fk_Courses_Professors1_idx` (`Professors_idProfessors` ASC) ,
  CONSTRAINT `fk_Courses_Departments1`
    FOREIGN KEY (`Departments_idDepartments` )
    REFERENCES `Universities`.`Departments` (`idDepartments` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Courses_Professors1`
    FOREIGN KEY (`Professors_idProfessors` )
    REFERENCES `Universities`.`Professors` (`idProfessors` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Universities`.`Title`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `Universities`.`Title` (
  `idTitle` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NULL ,
  `Professors_idProfessors` INT NOT NULL ,
  PRIMARY KEY (`idTitle`, `Professors_idProfessors`) ,
  UNIQUE INDEX `idTitle_UNIQUE` (`idTitle` ASC) ,
  INDEX `fk_Title_Professors1_idx` (`Professors_idProfessors` ASC) ,
  CONSTRAINT `fk_Title_Professors1`
    FOREIGN KEY (`Professors_idProfessors` )
    REFERENCES `Universities`.`Professors` (`idProfessors` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Universities`.`Students`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `Universities`.`Students` (
  `idStudents` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NULL ,
  `Faculties_idFaculties` INT NOT NULL ,
  PRIMARY KEY (`idStudents`, `Faculties_idFaculties`) ,
  UNIQUE INDEX `idStudents_UNIQUE` (`idStudents` ASC) ,
  INDEX `fk_Students_Faculties1_idx` (`Faculties_idFaculties` ASC) ,
  CONSTRAINT `fk_Students_Faculties1`
    FOREIGN KEY (`Faculties_idFaculties` )
    REFERENCES `Universities`.`Faculties` (`idFaculties` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Universities`.`StudentCourses`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `Universities`.`StudentCourses` (
  `Courses_idCourses` INT NOT NULL ,
  `Students_idStudents` INT NOT NULL ,
  PRIMARY KEY (`Courses_idCourses`, `Students_idStudents`) ,
  INDEX `fk_StudentCourses_Students1_idx` (`Students_idStudents` ASC) ,
  CONSTRAINT `fk_StudentCourses_Courses1`
    FOREIGN KEY (`Courses_idCourses` )
    REFERENCES `Universities`.`Courses` (`idCourses` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_StudentCourses_Students1`
    FOREIGN KEY (`Students_idStudents` )
    REFERENCES `Universities`.`Students` (`idStudents` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `Universities` ;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
