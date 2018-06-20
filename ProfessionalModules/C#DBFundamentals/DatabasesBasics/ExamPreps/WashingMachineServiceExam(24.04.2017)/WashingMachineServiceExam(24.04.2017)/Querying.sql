--Problem 5 - Clients by Name
SELECT FirstName, LastName,Phone
FROM Clients
ORDER BY LastName, ClientId

--Problem 6 - Job Status
SELECT Status, IssueDate
FROM Jobs
WHERE Status <>'Finished'
ORDER BY IssueDate, JobId

--Problem 7 - Mechanic Assignments
SELECT m.FirstName+' '+m.LastName AS [Mechanic],
       j.Status,
	   j.IssueDate
FROM Mechanics m
JOIN Jobs j
ON j.MechanicId = m.MechanicId
ORDER BY m.MechanicId, j.IssueDate, j.JobId

--Problem 8 - Current Clients
SELECT c.FirstName+' '+c.LastName AS Client,
       DATEDIFF(DAY,j.IssueDate,'2017-04-24') AS [Days going],
	   j.Status
FROM Clients c
JOIN Jobs j
ON j.ClientId=c.ClientId
WHERE j.Status<>'Finished'
ORDER BY [Days going] DESC, c.ClientId

--Problem 9 - Mechanic Performance
SELECT m.FirstName+' '+m.LastName AS [Mechanic],
       AVG(DATEDIFF(DAY,j.IssueDate,j.FinishDate)) AS [Average Days]
FROM Mechanics m
JOIN Jobs j
ON j.MechanicId=m.MechanicId
WHERE j.Status='Finished'
GROUP BY m.MechanicId,m.FirstName+' '+m.LastName
ORDER BY m.MechanicId

--Problem 10 - Hard Earners
SELECT TOP 3
       m.FirstName+' '+m.LastName AS [Mechanic],
	   COUNT(j.JobId) AS [Jobs]
FROM Mechanics m
  JOIN Jobs j
  ON j.MechanicId=m.MechanicId
WHERE j.Status<>'Finished'
GROUP BY m.FirstName+' '+m.LastName,m.MechanicId
HAVING COUNT(j.JobId)>1
ORDER BY Jobs DESC, m.MechanicId

--Problem 11 - Available Mechanics
WITH CTE_Finished(MechanicId)
AS
(
	SELECT MechanicId
	FROM Mechanics
	WHERE MechanicId NOT IN (SELECT j.MechanicId
	                         FROM Jobs j
							 WHERE j.Status<>'Finished'
							 AND j.MechanicId IS NOT NULL)
)

SELECT m.FirstName+' '+m.LastName AS [Mechanic]
FROM Mechanics m
  JOIN CTE_Finished f
  ON f.MechanicId=m.MechanicId
ORDER BY m.MechanicId

--Problem 12 - Parts Cost
SELECT ISNULL(SUM(p.Price*op.Quantity),0) AS [Parts Total]
FROM Parts p
  JOIN OrderParts op
  ON op.PartId=p.PartId
  JOIN Orders o
  ON o.OrderId=op.OrderId
WHERE DATEDIFF(WEEK,o.IssueDate,'2017-04-24')<=3

--Problem 13 - Past Expenses
SELECT j.JobId,
       ISNULL(SUM(p.Price*op.Quantity),0) AS [Total]
FROM Jobs j
LEFT JOIN Orders o
ON o.JobId = j.JobId
LEFT JOIN OrderParts op
ON op.OrderId=o.OrderId
LEFT JOIN Parts p
ON p.PartId=op.PartId
WHERE j.Status='Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId

--Problem 14 - Model Repair Time
SELECT m.ModelId,
       m.Name,
	   CONCAT(AVG(DATEDIFF(DAY,j.IssueDate,j.FinishDate)),' days') AS [Average Service Time]
FROM Models m
  JOIN Jobs j
  ON j.ModelId=m.ModelId
WHERE j.FinishDate IS NOT NULL
GROUP BY m.ModelId,m.Name
ORDER BY AVG(DATEDIFF(DAY,j.IssueDate,j.FinishDate))

--Problem 15 - Faultiest Model
SELECT TOP 1 WITH TIES
  m.Name,
  COUNT(*) AS [Times Serviced],
  (SELECT ISNULL(SUM(p.Price * op.Quantity), 0)
   FROM Jobs AS j
     JOIN Orders AS o
       ON O.JobId = j.JobId
     JOIN OrderParts AS op
       ON op.OrderId = o.OrderId
     JOIN Parts AS p
       ON p.[PartId] = op.PartId
   WHERE j.ModelId = m.ModelId) AS [Parts Total]
FROM Models AS m
  JOIN Jobs AS j
    ON j.ModelId = m.ModelId
GROUP BY m.ModelId, m.Name
ORDER BY [Times Serviced] DESC

--Problem 16 - Missing Parts
SELECT p.PartId,
       p.Description,
	   SUM(pn.Quantity) AS [Required],
	   AVG(p.StockQty) AS [In Stock],
	   ISNULL(SUM(op.Quantity),0) AS [Ordered]
FROM PartsNeeded pn
JOIN Parts p
ON p.PartId=pn.PartId
JOIN Jobs j
ON j.JobId=pn.JobId
LEFT JOIN Orders o
ON o.JobId=j.JobId
LEFT JOIN OrderParts op
ON op.OrderId=o.OrderId
WHERE j.Status<>'Finished'
GROUP BY p.PartId,p.Description
HAVING SUM(pn.Quantity)>AVG(p.StockQty) + ISNULL(SUM(op.Quantity), 0)
ORDER BY p.PartId

