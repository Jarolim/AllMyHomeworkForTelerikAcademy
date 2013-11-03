--Task 1
SELECT concat(FirstName,' ',MiddleName, ' ', LAStName) AS [Full Name], Salary
FROM Employees
WHERE Salary = (SELECT MIN(Salary) FROM Employees)

--Task 2
SELECT concat(FirstName,' ',MiddleName, ' ', LAStName) AS [Full Name], Salary
FROM Employees
WHERE Salary <= (SELECT MIN(Salary)*1.1 FROM Employees)
Order By Salary

--Task 3
SELECT concat(FirstName,' ',MiddleName, ' ', LAStName) AS [Full Name], DepartmentID, Salary
FROM Employees e
WHERE Salary = 
  (SELECT min(Salary) FROM Employees 
   WHERE DepartmentID = e.DepartmentID)
order by DepartmentID

--Task 4
SELECT avg(Salary) AS [Avarage Sum]
FROM Employees
WHERE DepartmentID = 1

--Task 5
SELECT avg(Salary) AS [Avarage Sum]
FROM Employees e , Departments dep
WHERE e.DepartmentID = dep.DepartmentID and Name in ('Sales')

--Task 6
SELECT count(*) [Count employee in sales]
FROM Employees e , Departments dep
WHERE e.DepartmentID = dep.DepartmentID and Name in ('Sales')

--Task 7
SELECT count(*) [Count employee with manager]
FROM Employees 
WHERE ManagerID is not null

--Task 8
SELECT count(*) [Count employee no manager]
FROM Employees 
WHERE ManagerID is null

--Task 9
SELECT dep.Name, avg(Salary) AS [avg salary]
FROM Employees e , Departments dep
WHERE e.DepartmentID = dep.DepartmentID
group by dep.Name

--Task 10
SELECT count(*) [Count employee with manager], dep.Name, town.Name
FROM Employees e , Departments dep, Towns town, Addresses adr
WHERE e.DepartmentID = dep.DepartmentID and e.AddressID = adr.AddressID and adr.TownID = town.TownID
group by dep.Name, town.Name

--Task 11
SELECT COUNT(emp.EmployeeID) AS Count, concat(men.FirstName,' ', men.LAStName) AS [Full Name]
FROM Employees emp, Employees men
WHERE emp.ManagerID = men.EmployeeID
GROUP BY men.ManagerID, men.FirstName, men.LAStName
HAVING COUNT(emp.EmployeeID) = 5


--Task 12
SELECT concat(emp.FirstName,' ', emp.LAStName) AS [Employee Name], COALESCE(men.FirstName +' '+ men.LAStName, 'no manager') AS [Manager name]
FROM Employees emp 
  left JOIN Employees men 
    ON emp.ManagerID = men.EmployeeID

--Task 13
SELECT concat(FirstName, ' ', LAStName) AS [Employee Name]
FROM Employees
WHERE len(LAStName) = 5

--Task 14
SELECT CONVERT(VARCHAR(24), GETDATE(), 113)

--Task 15
CREATE TABLE Users (
  UserID int identity,
  Username nvarchar(100) not null,
  FullName nvarchar(100) not null,
  PaSs nvarchar(100) not null,
  LastLoginTime datetime,
  constraint PK_UserID primary key(UserID),
  --constraint UK_Username unique(username),
  --constraint LK_PASs check(len(PASs)>=5)
)
GO

--Task 16
CREATE VIEW [Users been today] AS
SELECT FullName FROM Users
WHERE DATEDIFF(d, LAStLoginTime, GETDATE()) = 0

GO

--Task 17
CREATE TABLE Groups (
  GroupID int identity,
  GroupName nvarchar(100) not null,
  constraint PK_GroupID primary key(GroupID),
  constraint UK_GroupName unique(GroupName),
)
GO

--Task 18
ALTER TABLE Users ADD GroupID int

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
  FOREIGN KEY (GroupID)
  REFERENCES Groups(GroupID)

GO

--Task 19
INSERT INTO Groups(GroupName)
VALUES ('Mahato')
INSERT INTO Groups(GroupName)
VALUES ('Alabala')
INSERT INTO Groups(GroupName)
VALUES ('Dzun')

INSERT INTO Users(Username, FullName, PASs, LAStLoginTime, GroupID)
VALUES ('Mahato', 'Ivan Ivanov', 'akjdASg', '2013-11-29', 1)
INSERT INTO Users(Username, FullName, PASs, LAStLoginTime, GroupID)
VALUES ('Bubo', 'Milo Ivanov', 'afASdf', '2013-11-29', 1)
INSERT INTO Users(Username, FullName, PASs, LAStLoginTime, GroupID)
VALUES ('Tuti', 'Rumen Ivanov', 'akjdASg', '2013-11-29', 2)

--Task 20
Update Users
SET FullName = 'Brown Todorov'
WHERE UserID = 11

Update Groups
SET GroupName = 'Alhimia'
WHERE GroupID = 1

--Task 21
DELETE FROM Users
WHERE UserID = 11

DELETE FROM Groups
WHERE GroupID = 3

--Task 22
drop table Users
GO

INSERT INTO Users(Username, FullName, PASs)
SELECT LOWER(Left(FirstName,1) + LAStName), CONCAT(FirstName, ' ', LAStName), LOWER(Left(FirstName,1) + LAStName) FROM Employees

--Task 23
Update Users
SET LastLoginTime = 10-03-2010
WHERE LAStLoginTime is null
 
--Task 24
ALTER TABLE Users ALTER COLUMN PASs nvarchar(100) NULL
GO

INSERT INTO Users(Username, FullName, LAStLoginTime, GroupID)
VALUES ('Mahato', 'Ivan Ivanov', '2013-11-29', 1)

DELETE FROM Users
WHERE Pass is null

--Task 25
SELECT dep.Name, avg(Salary) AS [avg salary], e.JobTitle 
FROM Employees e , Departments dep
WHERE e.DepartmentID = dep.DepartmentID
group by dep.Name, e.JobTitle

--Task 26
SELECT dep.Name, MIN(Salary) AS [min salary], e.JobTitle , MIN(e.FirstName +' ' + e.LastName) as [Full name]
FROM Employees e , Departments dep
WHERE e.DepartmentID = dep.DepartmentID
group by dep.Name, e.JobTitle

--Task 27
SELECT TOP 1 t.Name, COUNT(*) as [Employees number]
from Employees e
 join Addresses adr
 on (e.AddressID =  adr.AddressID)
 join Towns t
 on (adr.TownID = t.TownID)
 GROUP BY t.Name
 ORDER BY COUNT(*) DESC
 
 --Task 28
 SELECT t.Name, COUNT(e.ManagerID)as [Menagers number]
from Employees e
 join Addresses adr
 on (e.AddressID =  adr.AddressID)
 join Towns t
 on (adr.TownID = t.TownID)
WHERE e.EmployeeID in (SELECT DISTINCT ManagerID FROM Employees)
GROUP BY t.Name
 ORDER BY COUNT(e.ManagerID) DESC

--Task 29
CREATE TABLE WorkHours(
EmployeeID int IDENTITY,
WorkDate datetime,
Task nvarchar(50),
WorkingHours int,
Comment nvarchar(50),
CONSTRAINT PK_WorkHours PRIMARY KEY(EmployeeID),
CONSTRAINT FK_WorkHours_Employees FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID)
)

INSERT INTO WorkHours(WorkDate, Task, WorkingHours)
VALUES
(2013-11-29, 'First Task', 23),
(2013-11-29, 'Second Task', 3)

DELETE FROM WorkHours
WHERE Task LIKE '%First'

UPDATE WorkHours
SET WorkingHours = 10
WHERE Task = 'Second Task'

CREATE TABLE WorkHoursLog(
Id int IDENTITY,
OldRecord nvarchar(100) NOT NULL,
NewRecord nvarchar(100) NOT NULL,
Command nvarchar(10) NOT NULL,
EmployeeId int NOT NULL,
CONSTRAINT PK_WorkHoursLog PRIMARY KEY(Id),
CONSTRAINT FK_WorkHoursLogs_WorkHours FOREIGN KEY(EmployeeId) REFERENCES WorkHours(EmployeeID)
)

CREATE  TRIGGER tr_WorkHoursInsert ON WorkHours FOR INSERT
AS
INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId)
Values(' ',
(SELECT 'Day: ' + CAST(WorkDate AS nvarchar(50)) + ' ' + ' Task: ' + Task + ' ' + ' Hours: ' + CAST(WorkingHours AS nvarchar(50)) + ' ' + Comment
FROM Inserted),
'INSERT',
(SELECT EmployeeID FROM Inserted))
GO

CREATE TRIGGER tr_WorkHoursUpdate ON WorkHours FOR UPDATE
AS
INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId)
Values((SELECT  'Day: ' + IsNull(CAST(WorkDate AS nvarchar(50)),' ') + ' ' + ' Task: ' + IsNull(Task,' ') + ' ' + ' Hours: ' + IsNull(CAST(WorkingHours AS nvarchar(50)),' ') + ' ' + IsNull(Comment,' ')  FROM deleted),
(SELECT 'Day: ' + IsNull(CAST(WorkDate AS nvarchar(50)),' ') + ' ' + ' Task: ' + IsNull(Task,' ') + ' ' + ' Hours: ' +IsNull(CAST(WorkingHours AS nvarchar(50)),'') + ' ' + IsNull(Comment,' ') FROM Inserted),
'UPDATE',
(SELECT EmployeeID FROM Inserted))
GO

drop trigger tr_WorkHoursDeleted

CREATE TRIGGER tr_WorkHoursDeleted ON WorkHours FOR DELETE
AS
INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId)
Values((SELECT  'Day: ' + IsNull(CAST(WorkDate AS nvarchar(50)),'') + ' ' + ' Task: ' + IsNull(Task,'') + ' ' + ' Hours: ' + IsNull(CAST(WorkingHours AS nvarchar(50)),'') + ' ' + IsNull(Comment,'')  FROM deleted),
' ',
'DELETE',
(SELECT EmployeeID FROM Deleted))
GO

INSERT INTO WorkHours(WorkDate, Task, WorkingHours, Comment)
VALUES(2013-11-30, 'Random task4', 12, 'Comment4')

DELETE FROM WorkHours
WHERE Task = 'First Task'

UPDATE WorkHours
SET Task = 'Random task12'
WHERE EmployeeID = 8

--Task 30
BEGIN TRAN
DELETE FROM Employees
SELECT d.Name
FROM Employees e JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name
ROLLBACK TRAN

--Task 31
BEGIN TRAN
DROP TABLE EmployeesProjects
ROLLBACK TRAN

--Task 32
CREATE TABLE #TemporaryTable(
EmployeeID int NOT NULL,
ProjectID int NOT NULL
)

INSERT INTO #TemporaryTable
SELECT EmployeeID, ProjectID
FROM EmployeesProjects

DROP TABLE EmployeesProjects

CREATE TABLE EmployeesProjects(
EmployeeID int NOT NULL,
ProjectID int NOT NULL,
CONSTRAINT PK_EmployeesProjects PRIMARY KEY(EmployeeID, ProjectID),
CONSTRAINT FK_EP_Employee FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID),
CONSTRAINT FK_EP_Project FOREIGN KEY(ProjectID) REFERENCES Projects(ProjectID)
)

INSERT INTO EmployeesProjects
SELECT EmployeeID, ProjectID
FROM #TemporaryTable

