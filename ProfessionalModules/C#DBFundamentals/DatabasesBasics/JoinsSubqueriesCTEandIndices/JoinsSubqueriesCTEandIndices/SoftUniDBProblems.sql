--Problem 1 - Employee Address
  SELECT TOP 5
	     e.EmployeeId,
         e.JobTitle,
	     e.AddressID,
	     a.AddressText
    FROM Employees AS e
    JOIN Addresses AS a
      ON a.AddressID=e.AddressID
ORDER BY e.AddressID

--Problem 2 - Addresses with towns
SELECT TOP 50
	 e.FirstName,
	 e.LastName,
	 t.Name as Town,
	 a.AddressText
FROM Employees AS e
JOIN Addresses AS a
ON a.AddressID=e.AddressID
JOIN Towns AS t
ON t.TownID=a.TownID
ORDER BY e.FirstName,e.LastName

--Problem 3 - Sales employees
SELECT e.EmployeeID,
	   e.FirstName,
	   e.LastName,
	   d.Name AS DepartmentName
FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID=e.DepartmentID
WHERE d.Name='Sales'
ORDER BY e.EmployeeID

--Problem 4 - Employee departments
SELECT TOP 5
	   e.EmployeeID,
	   e.FirstName,
	   e.Salary,
	   d.Name
  FROM Employees AS e
  JOIN Departments AS d
    ON e.DepartmentID=d.DepartmentID
 WHERE e.Salary>15000
ORDER BY d.DepartmentID

--Problem 5 - Employees without projects
SELECT TOP 3
	   e.EmployeeID,
       e.FirstName
FROM Employees AS e
LEFT OUTER JOIN EmployeesProjects AS ep
ON ep.EmployeeID=e.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID

--Problem 6 - Employees hired after
SELECT e.FirstName,
       e.LastName,
	   e.HireDate,
	   d.Name as DeptName
FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID=e.DepartmentID
WHERE e.HireDate > '1999-01-01'
AND d.Name IN ('Finance','Sales')
ORDER BY e.HireDate

--Problem 7 - Employees with projects
SELECT TOP 5
	   e.EmployeeID,
       e.FirstName,
	   p.Name
FROM Employees AS e
JOIN EmployeesProjects AS ep
ON ep.EmployeeID=e.EmployeeID
JOIN Projects AS p
ON p.ProjectID=ep.ProjectID
WHERE p.StartDate>'2002-08-13' 
AND p.EndDate IS NULL
ORDER BY e.EmployeeID

--Problem 8 - Employee 24
SELECT e.EmployeeID,
       e.FirstName,
	   IIF(p.StartDate>='2005',NULL,p.Name) AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep
ON ep.EmployeeID=e.EmployeeID
JOIN Projects AS p
ON p.ProjectID=ep.ProjectID
WHERE e.EmployeeID=24

--Problem 9 - Employee manager
SELECT e.EmployeeID,
       e.FirstName,
	   e.ManagerID,
	   m.FirstName AS ManagerName
FROM Employees AS e
JOIN Employees AS m
ON m.EmployeeID=e.ManagerID
WHERE e.ManagerID IN (3,7)
ORDER BY e.EmployeeID

--Problem 10 - Employee summary
SELECT TOP 50
	   e.EmployeeID,
	   e.FirstName+' '+e.LastName AS EmployeeName,
	   m.FirstName+' '+m.LastName AS ManagerName,
	   d.Name AS DepartmentName
FROM Employees AS e
JOIN Employees AS m
ON m.EmployeeID=e.ManagerID
JOIN Departments AS d
ON d.DepartmentID=e.DepartmentID
ORDER BY e.EmployeeID

--Min average salary
WITH Salary_CTE(DepAvgSalary)
AS
(
SELECT AVG(Salary) AS Avg
FROM Employees AS e
GROUP BY e.DepartmentID
)

SELECT MIN(Salary_CTE.DepAvgSalary) AS MinAverageSalary
FROM Salary_CTE



