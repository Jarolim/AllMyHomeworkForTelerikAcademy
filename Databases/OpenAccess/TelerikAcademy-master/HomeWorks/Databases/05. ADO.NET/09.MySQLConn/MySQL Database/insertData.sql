INSERT INTO `bookstores`.`books` (`titleBook`, `publishDate`, `ISBN`) VALUES ('\"Person in Hawai\"', '2001-03-31', '123456789');
INSERT INTO `bookstores`.`books` (`titleBook`, `publishDate`, `ISBN`) VALUES ('\"Milla in Millan\"', '2001-03-31', '345623456');
INSERT INTO `bookstores`.`books` (`titleBook`, `publishDate`, `ISBN`) VALUES ('\"People dead\"', '2001-03-31', '123124567');

UPDATE `bookstores`.`books` SET `publishDate`='2011-05-08' WHERE `idBooks`='3';
UPDATE `bookstores`.`books` SET `publishDate`='2004-10-31' WHERE `idBooks`='2';

INSERT INTO `bookstores`.`authors` (`AuthorName`, `Books_idBooks`) VALUES ('\"Peter Minov\"', '1');
INSERT INTO `bookstores`.`authors` (`AuthorName`, `Books_idBooks`) VALUES ('\"Minio Penlio\"', '1');
INSERT INTO `bookstores`.`authors` (`AuthorName`, `Books_idBooks`) VALUES ('\"Alisa Minosh\"', '2');
INSERT INTO `bookstores`.`authors` (`AuthorName`, `Books_idBooks`) VALUES ('\"Caily Lang', '3');
