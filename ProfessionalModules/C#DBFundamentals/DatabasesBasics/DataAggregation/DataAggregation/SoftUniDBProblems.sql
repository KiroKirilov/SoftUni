--Problem 13 - Departments Total Salaries
SELECT DepartmentID,
	   SUM(Salary) AS [TotalSalary]
FROM Employees
GROUP BY DepartmentID

--Problem 14 - Employees minimum salaries
SELECT DepartmentID,
	   MIN(Salary) as[MinimumSalary]
FROM Employees
WHERE DepartmentID IN (2,5,7) AND HireDate>'01/01/2000'
GROUP BY DepartmentID

--Problem 15 - Employees Average Salaries
SELECT * 
INTO NewEmployeesTable
FROM Employees
WHERE Salary>30000

DELETE FROM NewEmployeesTable
WHERE ManagerID=42

UPDATE NewEmployeesTable
SET Salary+=5000
WHERE DepartmentID=1

SELECT DepartmentID,
       AVG(Salary) AS [AverageSalary]
FROM NewEmployeesTable
GROUP BY DepartmentID

--Problem 16 - Employees Maximum Salaries
SELECT DepartmentID,
       MAX(Salary) AS [MaxSalary]
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--Problem 17 - Employees Count Salaries
SELECT COUNT(Salary) AS [Count]
FROM Employees
WHERE ManagerID IS NULL

--Problem 18 - Third highest salary
SELECT 
  DepartmentID,
  (SELECT DISTINCT Salary FROM Employees
   WHERE DepartmentID = e.DepartmentID
   ORDER BY Salary DESC 
   OFFSET 2 ROWS FETCH NEXT 1 ROWS ONLY) AS ThirdHighestSalary
FROM Employees e
WHERE 
  (SELECT DISTINCT Salary FROM Employees
   WHERE DepartmentID = e.DepartmentID
   ORDER BY Salary DESC 
   OFFSET 2 ROWS FETCH NEXT 1 ROWS ONLY) IS NOT NULL
GROUP BY DepartmentID

--Problem 19 - Salary Challange
  SELECT TOP 10
         FirstName, LastName, DepartmentID
    FROM Employees as e1
   WHERE Salary>
         (SELECT AVG(Salary)
	       FROM Employees as e2
	       WHERE e1.DepartmentID=e2.DepartmentID
	       GROUP BY DepartmentID)
ORDER BY DepartmentID