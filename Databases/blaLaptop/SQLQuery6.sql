INSERT INTO Users(Username, Password, FullName, LastLogin)
SELECT FirstName + ' ' + LastName, 
	   LOWER(SUBSTRING(FirstName, 0, 1) + LastName + 'salt'), 
	   LOWER(SUBSTRING(FirstName, 0, 1) + LastName),
	   getdate()
FROM Employees