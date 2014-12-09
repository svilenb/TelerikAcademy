You may have to change the connection string  in the app config for every taks because I use SQL Express.

Use this Sql command for task 10:

CREATE PROC usp_GetTotalIncome(@supplierName nvarchar, @startDate date, @endDate date)
AS
	SELECT SUM(od.UnitPrice) FROM [Order Details] od
		JOIN Orders o ON od.OrderID = o.OrderID
		JOIN Products p ON od.ProductID = p.ProductID
		JOIN Suppliers s ON p.SupplierID = s.SupplierID
	WHERE (o.ShippedDate BETWEEN @startDate AND @endDate) AND s.CompanyName = @supplierName
GO