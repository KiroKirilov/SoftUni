--Problem 5 - Showroom
SELECT Manufacturer,
       Model
FROM Models
ORDER BY Manufacturer, Id DESC

--Problem 6 - Y Generation
SELECT FirstName,
       LastName
FROM Clients
WHERE DATEPART(YEAR, BirthDate) BETWEEN 1977 AND 1994
ORDER BY FirstName,LastName, Id 

--Problem 7 - Spacious Office
SELECT t.Name AS TownName,
       o.Name AS OfficeName,
	   o.ParkingPlaces
FROM Offices o
JOIN Towns t
ON t.Id=o.TownId
WHERE o.ParkingPlaces>25
ORDER BY t.Name,o.Id

--Problem 8 - Available Vehicles
SELECT m.Model, m.Seats, v.Mileage
FROM Vehicles AS v
INNER JOIN Models AS m ON m.Id = v.ModelId
WHERE v.Id <> ALL (
        SELECT VehicleId FROM Orders WHERE ReturnDate IS NULL
)
ORDER BY v.Mileage ASC, m.Seats DESC, v.ModelId ASC, m.Model ASC

--Problem 9 - Offices per town
SELECT t.Name AS TownName,
       COUNT(o.Id) AS OfficesNumber
FROM Offices o
JOIN Towns t
ON t.Id=o.TownId
GROUP BY t.Name
ORDER BY OfficesNumber DESC, TownName

--Problem 10 - Buyers Best Choice 
SELECT m.Manufacturer,
       m.Model,
	   COUNT(o.Id) AS TimesOrdered
FROM Vehicles v
LEFT JOIN Models m
ON m.Id=v.ModelId
LEFT JOIN Orders o
ON o.VehicleId=v.Id
GROUP BY m.Manufacturer,m.Model
ORDER BY TimesOrdered DESC,m.Manufacturer DESC ,m.Model

--11 - Kinda Person
SELECT Names,
       Class
FROM
(
	SELECT c.FirstName +' '+c.LastName AS Names,
		   m.Class,
		   DENSE_RANK() OVER (PARTITION BY c.FirstName +' '+c.LastName
							  ORDER BY COUNT(m.Class) DESC) AS [UsageRank],
		   c.Id AS ClientId
	FROM Orders o
	JOIN Clients c
	ON c.Id=o.ClientId
	JOIN Vehicles v
	ON v.Id=o.VehicleId
	JOIN Models m
	ON m.Id=v.ModelId
	GROUP BY c.FirstName +' '+c.LastName, m.Class, c.Id
) AS OrderedUsage
WHERE OrderedUsage.UsageRank=1
ORDER BY Names, Class, ClientId

--Problem 12 - Age Groups Revenue
SELECT 
	  CASE 
		WHEN DATEPART(YEAR,c.BirthDate) BETWEEN 1970 AND 1979 THEN '70''s'
		WHEN DATEPART(YEAR,c.BirthDate) BETWEEN 1980 AND 1989 THEN '80''s'
		WHEN DATEPART(YEAR,c.BirthDate) BETWEEN 1990 AND 1999 THEN '90''s'
		ELSE 'Others'
	  END AS AgeGroup,
	  SUM(o.Bill) AS Revenue,
	  AVG(o.TotalMileage) AS AverageMileage
FROM Clients c
JOIN Orders o
ON o.ClientId=c.Id
JOIN Vehicles v
ON v.Id=o.VehicleId
GROUP BY
  CASE 
    WHEN DATEPART(YEAR,c.BirthDate) BETWEEN 1970 AND 1979 THEN '70''s'
	WHEN DATEPART(YEAR,c.BirthDate) BETWEEN 1980 AND 1989 THEN '80''s'
	WHEN DATEPART(YEAR,c.BirthDate) BETWEEN 1990 AND 1999 THEN '90''s'
	ELSE 'Others'
  END

--Problem 13 - Consumption in Mind
SELECT Manufacturer,
       AverageConsumption
FROM
(
	SELECT TOP 7
		   m.Id,
		   m.Manufacturer,
		   COUNT(o.Id) AS TimesOrdered,
		   AVG(m.Consumption) AS AverageConsumption
	FROM Orders o
	JOIN Vehicles v
	ON v.Id=o.VehicleId
	JOIN Models m
	ON m.Id=v.ModelId
	GROUP BY m.Id, m.Manufacturer
	ORDER BY TimesOrdered DESC
) AS cons
WHERE AverageConsumption BETWEEN 5 AND 15
ORDER BY Manufacturer, AverageConsumption

--Problem 14 - Debt Hunter
SELECT Names,
       Email,
	   Bill,
	   Town
FROM
(
	SELECT t.Name AS [Town], 
		   c.FirstName +' '+c.LastName AS [Names],
		   c. Email AS [Email],
		   o.Bill AS [Bill],
		   DENSE_RANK() OVER (PARTITION BY t.Name
							  ORDER BY o.Bill DESC) AS [BillRank],
		   c.Id AS [ClientId]
	FROM Clients c
	JOIN Orders o
	ON o.ClientId=c.Id
	JOIN Towns t
	ON t.Id=o.TownId
	WHERE c.CardValidity<o.CollectionDate
	GROUP BY t.Name, c.FirstName +' '+c.LastName, c. Email, o.Bill, c.Id
) AS RankedTowns
WHERE BillRank IN (1,2)
AND Bill IS NOT NULL
ORDER BY Town, Bill ASC, ClientId

--Problem 15 - Town Statistics
WITH CTE_OrderedGenders (TownName,Gender,TotalOrders,TownId)
AS
(
	SELECT t.Name AS TownName,
		   c.Gender AS Gender,
		   COUNT(o.Id) AS TotalOrders,
		   t.Id AS TownId
	FROM Towns t
	JOIN Orders o
	ON o.TownId=t.Id
	JOIN Clients c
	ON c.Id=o.ClientId
	GROUP BY t.Name, c.Gender, t.Id
)

SELECT ams.TownName,
       CAST(IIF(ams.MalePercent=0,NULL,ams.MalePercent)AS int) AS [MalePercent],
	   CAST(IIF(100-ams.MalePercent=0,NULL,100-ams.MalePercent)AS int) AS [FemalePercent]
FROM
(
SELECT DISTINCT p.TownName,
	   IIF(cte.Gender='M',
	       ROUND((CAST(cte.TotalOrders AS float)/p.AllOrders)*100,1),
		   100-ROUND((CAST(cte.TotalOrders AS float)/p.AllOrders)*100,1)) AS [MalePercent]
FROM
(
	SELECT TownName,
		   SUM(TotalOrders) AS [AllOrders]
	FROM CTE_OrderedGenders
	GROUP BY TownName, TownId
) AS p
JOIN CTE_OrderedGenders cte
ON cte.TownName=p.TownName
) AS ams

--Problem 16 - Home Sweet Home
WITH CTE_C (ReturnOfficeId, OfficeId, VehicleId, Manufacturer, Model)
AS
(
    SELECT
      W.ReturnOfficeId,
      W.OfficeId,
      W.Id,
      W.Manufacturer,
      W.Model
    FROM
      (SELECT
         DENSE_RANK()
         OVER ( PARTITION BY V.Id
           ORDER BY O.CollectionDate DESC ) AS [RANK],
         O.ReturnOfficeId,
         V.OfficeId,
         V.Id,
         M.Manufacturer,
         M.Model
       FROM Models AS M
         JOIN Vehicles AS V
           ON M.Id = V.ModelId
         LEFT JOIN Orders AS O
           ON O.VehicleId = V.Id) AS W
    WHERE W.RANK = 1
)

SELECT
  CONCAT(C.Manufacturer, ' - ', C.Model) AS [Vehicle],
  CASE
  WHEN (SELECT COUNT(*)
        FROM Orders
        WHERE VehicleId = C.VehicleId) = 0 OR C.OfficeId = C.ReturnOfficeId
    THEN 'home'
  WHEN C.ReturnOfficeId IS NULL
    THEN 'on a rent'
  WHEN C.OfficeId <> C.ReturnOfficeId
    THEN (SELECT CONCAT([To].Name, ' - ', [Of].Name)
          FROM Offices AS [Of]
            JOIN Towns AS [To]
              ON [To].Id = [Of].TownId
          WHERE C.ReturnOfficeId = [Of].Id)
  END                                    AS [Location]
FROM CTE_C AS C
ORDER BY Vehicle, C.VehicleId