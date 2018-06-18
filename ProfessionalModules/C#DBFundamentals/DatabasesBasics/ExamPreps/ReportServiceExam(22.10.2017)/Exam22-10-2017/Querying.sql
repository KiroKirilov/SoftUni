--Problem 5 - Users by age
SELECT Username,Age
FROM Users
ORDER BY Age,Username DESC

--Problem 6 - Unassigned reports
SELECT Description, OpenDate
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate, Description

--Problem 7 - Employees & Reports
SELECT e.FirstName,
	   e.LastName,
	   r.Description,
	   FORMAT (r.OpenDate, 'yyyy-MM-dd', 'en-US') AS DateConvert
FROM Employees AS e
JOIN Reports AS r
ON r.EmployeeId=e.Id
ORDER BY e.Id,r.OpenDate

--Problem 8 - Most reported category
SELECT c.Name,
	   COUNT(r.CategoryId) AS ReprotsNumber
FROM Reports AS r
JOIN Categories AS c
ON c.Id=r.CategoryId
GROUP BY r.CategoryId,c.Name
ORDER BY ReprotsNumber DESC, c.Name

--Problem 9 - Employees in Category
SELECT c.Name,
	   COUNT(e.Id) AS [Employees Number]
FROM Categories AS c
  JOIN Departments AS d
  ON d.Id=c.DepartmentId
  JOIN Employees AS e
  ON e.DepartmentId=d.Id
GROUP BY c.Name

--Problem 10 - Users per employee
SELECT e.FirstName+' '+e.LastName AS Name,
       COUNT(DISTINCT r.UserId) AS [Users Number]
FROM Employees AS e
  LEFT JOIN Reports AS r
  ON r.EmployeeId=e.Id
GROUP BY e.FirstName+' '+e.LastName
ORDER BY [Users Number] DESC, Name

--Problem 11 - Emergency patrol
SELECT r.OpenDate,
       r.Description,
	   u.Email AS [Reporter Email]
FROM Reports r
JOIN Categories c
ON c.Id=r.CategoryId
JOIN Departments d
ON d.Id=c.DepartmentId
JOIN Users u
ON u.Id=r.UserId
WHERE r.CloseDate IS NULL
AND LEN(r.Description)>20
AND r.Description LIKE '%str%'
AND d.Id IN (1,4,5)
ORDER BY r.OpenDate ASC,
         r.Description ASC,
		 u.Email ASC,
		 r.Id ASC

--Problem 12 - Birthday Report
SELECT DISTINCT c.Name
FROM Categories c
JOIN Reports r
ON r.CategoryId = c.id
JOIN Users u
ON u.Id=r.UserId
WHERE DAY(u.BirthDate)=DAY(r.OpenDate)
AND MONTH(u.BirthDate)=MONTH(r.OpenDate)
ORDER BY c.Name

--Problem 13 - Numbers Coincidence
SELECT DISTINCT u.Username
FROM Users u
JOIN Reports r
ON r.UserId=u.Id
JOIN Categories c
ON c.Id=r.CategoryId
WHERE (u.Username LIKE '[0-9]_%' AND CAST(c.Id AS varchar)=LEFT(u.Username,1))
OR (Username LIKE '%_[0-9]' AND CAST(c.id as varchar) = RIGHT(username, 1))
ORDER BY Username

--Problem 14 - Open/Closed Statistics
WITH CTE_Opened (EmployeeId,Opened)
AS
(
	    SELECT EmployeeId,  COUNT(*) AS ReportSum
	    FROM Reports r
	    WHERE  YEAR(r.OpenDate) = 2016
	    GROUP BY EmployeeId
),

CTE_Closed (EmployeeId,Closed)
AS
(
	    SELECT EmployeeId,  COUNT(*) AS ReportSum
	    FROM Reports r
	    WHERE  YEAR(r.CloseDate) = 2016
	    GROUP BY EmployeeId
)

SELECT e.Firstname+' '+e.Lastname AS Name,
	   CONCAT(ISNULL(c.Closed,0),'/',ISNULL(o.Opened,0)) AS [Closed Open Reports]
FROM Employees e
LEFT JOIN CTE_Closed c
ON c.EmployeeId=e.Id
LEFT JOIN CTE_Opened o
ON o.EmployeeId=e.Id
WHERE o.Opened IS NOT NULL
OR c.Closed IS NOT NULL
ORDER BY Name

--Problem 15 - Average Closing Time
SELECT d.Name,
       ISNULL(
	     CONVERT(varchar,
	       AVG(DATEDIFF(DAY,r.OpenDate,r.CloseDate))),
	           'no info') AS [Average Duration]
FROM Departments d
JOIN Categories c
ON c.DepartmentId=d.Id
LEFT JOIN Reports r
ON r.CategoryId=c.Id
GROUP BY d.Name
ORDER BY d.Name

--Problem 16 - Favorite Categories
WITH CTE_TotalReportsDepartments(DepartmentId,ReportsAmount)
AS
(
  SELECT d.Id, 
         COUNT(r.Id) AS TotalReports
  FROM Departments d
    JOIN Categories c
	ON c.DepartmentId=d.Id
	JOIN Reports r 
	ON r.CategoryId=c.Id
  GROUP BY d.Id
)

SELECT rc.Department,
       rc.Category,
	   ROUND(100*(CONVERT(float,rc.Reports)/CONVERT(float,trd.ReportsAmount)),0) AS [Percentage]
FROM
(
	SELECT d.Name AS Department,
		   c.Name AS Category,
		   COUNT(r.Id) AS Reports,
		   d.Id AS DepartmentId
	FROM Departments d
	  JOIN Categories c
	  ON c.DepartmentId=d.Id
	  JOIN Reports r
	  ON r.CategoryId=c.Id
	GROUP BY d.Name,c.Name,d.Id
) AS rc
JOIN CTE_TotalReportsDepartments trd
ON trd.DepartmentId=rc.DepartmentId
ORDER BY rc.Department,rc.Category, [Percentage]

--Problem 20 - Categories Revision
WITH CTE_StatusCount (CategoryId,InProgressCount,WaitingCount)
AS
(
	SELECT r.CategoryId,
	       SUM(CASE WHEN s.Label='in progress' THEN 1 ELSE 0 END) AS InProgressCount,
		   SUM(CASE WHEN s.Label='waiting' THEN 1 ELSE 0 END) AS WaitingCount
	FROM Reports r
	  JOIN Status s
	  ON s.Id=r.StatusId
	WHERE s.Label IN ('waiting','in progress')
	GROUP BY r.CategoryId
)

SELECT c.Name,
	   COUNT(r.Id) AS ReportsNumber,
       CASE
	     WHEN sc.InProgressCount>sc.WaitingCount THEN 'in progress'
		 WHEN sc.InProgressCount<sc.WaitingCount THEN 'waiting'
		 ELSE 'equal'
	   END AS MainStatus
FROM Reports r
  JOIN Status s
  ON s.Id=r.StatusId
  JOIN Categories c
  ON c.Id=r.CategoryId
  JOIN CTE_StatusCount sc
  ON sc.CategoryId=c.Id
WHERE s.Label IN ('waiting','in progress')
GROUP BY c.Name,
         CASE
	       WHEN sc.InProgressCount>sc.WaitingCount THEN 'in progress'
		   WHEN sc.InProgressCount<sc.WaitingCount THEN 'waiting'
	  	   ELSE 'equal'
	     END
ORDER BY c.Name, ReportsNumber, MainStatus