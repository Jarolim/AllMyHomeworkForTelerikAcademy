CREATE DATABASE PerformanceDb;

USE PerformanceDb;
CREATE TABLE Logs(
  LogId int NOT NULL AUTO_INCREMENT,
  LogText nvarchar(100),
  LogDate datetime,
  PRIMARY KEY (LogId, LogDate)
)PARTITION BY RANGE(YEAR(LogDate)) (
	PARTITION p0 VALUES LESS THAN (1950),
	PARTITION p2 VALUES LESS THAN (1980),
	PARTITION p3 VALUES LESS THAN (2000),
	PARTITION p4 VALUES LESS THAN MAXVALUE
); 

DROP TABLE Logs


drop procedure usp_FillLogs;

DELIMITER $$
CREATE PROCEDURE usp_FillLogs (RecordsCount int)

Begin
Declare RowCount int DEFAULT RecordsCount;
Declare MyText nvarchar(100);
DECLARE MyDate datetime;
START TRANSACTION;
WHILE RowCount > 0 DO
	set MyText = concat('Text ', cast(10 as nchar(100)), ': ', cast(uuid() as nchar(100)));
	Set MyDate = CURRENT_TIMESTAMP - INTERVAL FLOOR(RAND() * 100) YEAR;
	INSERT INTO Logs(LogText, LogDate) Values(MyText, MyDate);
	SET RowCount = RowCount - 1;
END WHILE;
COMMIT;
End$$


call usp_FillLogs(1000000);

SELECT * FROM Logs PARTITION (p0);
SELECT * FROM Logs PARTITION (p2);
SELECT * FROM Logs PARTITION (p3);
SELECT * FROM Logs PARTITION (p4);

-- Select from all partittions
SELECT * FROM Logs;

-- Select from a single partition
SELECT * FROM Logs WHERE YEAR(LogDate) > 2000;


