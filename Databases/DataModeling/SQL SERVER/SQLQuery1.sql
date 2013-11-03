SELECT e.FirstName +' '+e.LastName AS [Emplyee Name],
		d.Name DepartmantName,e.HireDate
FROM Employees e INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name IN ('Sales','Finance') AND
e.HireDate BETWEEN '1/1/1995' AND '12/31/2005'