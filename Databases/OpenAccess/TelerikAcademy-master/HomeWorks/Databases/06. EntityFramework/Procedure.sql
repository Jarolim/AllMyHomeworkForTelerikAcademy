USE northwind
GO

CREATE PROC usp_FindTotalIncome (@startDate datetime,  @endDate DateTime, @companyName nvarchar(50))
AS
SELECT SUM(od.Quantity*od.UnitPrice) AS TotalIncome
FROM Suppliers s
INNER JOIN Products p
ON s.SupplierID = p.SupplierID
INNER JOIN [ORDER Details] od
ON od.ProductID = p.ProductID
INNER JOIN Orders o
ON od.OrderID = o.OrderID
WHERE s.CompanyName = @companyName AND (o.OrderDate >= @startDate AND o.OrderDate <= @endDate)
GO
--drop procedure usp_FindTotalIncome

EXEC usp_FindTotalIncome '1994-01-01', '2000-12-31', 'Exotic Liquids'