--Problem 1 - Find Names of All Employees by First Name
SELECT FirstName,LastName
FROM Employees
WHERE FirstName LIKE 'sa%'

--Problem 2 - Find Names of All Employees by Last Name
SELECT FirstName,LastName
FROM Employees
WHERE LastName LIKE '%ei%'

--Problem 3 - Find First Names of All Employees
SELECT FirstName
FROM Employees
WHERE DepartmentID IN (3,10)
AND DATEPART(YEAR,HireDate) >=1995 
AND DATEPART(YEAR,HireDate) <=2005

--Problem 4 - Find All Employees Except Engineers
SELECT FirstName,LastName
FROM Employees
WHERE NOT JobTitle LIKE '%engineer%'

--Problem 5 - Find Towns with Name Length
SELECT Name
FROM Towns
WHERE LEN(Name) IN (5,6)
ORDER BY Name

--Problem 6 - Find Towns Starting With
SELECT TownId, Name
FROM Towns
WHERE Name LIKE '[MKBE]%'
ORDER BY Name

--Problem 7 - Find Towns Not Starting With
SELECT TownId, Name
FROM Towns
WHERE Name LIKE '[^RBD]%'
ORDER BY Name

--Problem 8 - Create View Employees Hired After 2000 Year
GO
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName,LastName
FROM Employees
WHERE DATEPART(YEAR,HireDate)>2000
GO

--Problem 9 - Length of Last Name
SELECT FirstName,LastName
FROM Employees
WHERE LEN(LastName)=5