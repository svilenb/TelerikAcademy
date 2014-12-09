SELECT * FROM Departments

SELECT Name FROM Departments

SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Employee Name], Salary
FROM Employees

SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Employee Name], Salary
FROM Employees

SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Addresses]
FROM Employees

SELECT DISTINCT Salary
FROM Employees

SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative'

SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Employee Name]
FROM Employees
WHERE FirstName LIKE 'SA%'

SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Employee Name]
FROM Employees
WHERE LastName LIKE '%ei%'

SELECT Salary
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Employee Name]
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

SELECT *
FROM Employees
WHERE ManagerID IS NULL

SELECT *
FROM Employees
WHERE Salary > 50000
ORDER By Salary DESC

SELECT TOP 5 *
FROM Employees
WHERE Salary > 50000
ORDER By Salary DESC

SELECT e.LastName, a.AddressText
FROM Employees e INNER JOIN Addresses a
	ON e.AddressID = a.AddressID

SELECT e.LastName, a.AddressText
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID

SELECT e.LastName [Employee Last Name], m.LastName [Manager Last Name]
FROM Employees e INNER JOIN Employees m
  ON e.ManagerID = m.EmployeeID

SELECT e.LastName [Employee Last Name], m.LastName [Manager Last Name], a.AddressText
FROM Employees e 
	INNER JOIN Employees m
		ON e.ManagerID = m.EmployeeID
	INNER JOIN Addresses a
		ON e.AddressID = a.AddressID

SELECT Name
FROM Departments
UNION
SELECT Name
FROM Towns

SELECT e.LastName [Employee Last Name], m.LastName [Manager Last Name]
FROM Employees m 
	RIGHT OUTER JOIN Employees e
		ON e.ManagerID = m.EmployeeID

SELECT e.LastName [Employee Last Name], m.LastName [Manager Last Name]
FROM Employees e 
	LEFT OUTER JOIN Employees m
		ON e.ManagerID = m.EmployeeID

SELECT e.FirstName + ' ' + e.LastName AS [Employee Name], e.HireDate, d.Name As [Department Name]
FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
WHERE (d.Name = 'Sales' OR d.Name = 'Finance' AND e.HireDate BETWEEN '1/1/1995' AND '1/1/2006')
