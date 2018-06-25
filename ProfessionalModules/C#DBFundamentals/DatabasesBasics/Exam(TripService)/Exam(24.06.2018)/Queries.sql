--Problem 5 - Bulgarian Cities
SELECT Id,
       Name
FROM Cities
WHERE CountryCode='BG'
ORDER BY Name

--Problem 6 - People Born After 1991
SELECT CONCAT(FirstName,' ',ISNULL(MiddleName+' ',''),LastName) AS [Full Names],
       YEAR(BirthDate) AS [Birth Year]
FROM Accounts
WHERE YEAR(BirthDate)>1991
ORDER BY YEAR(BirthDate) DESC, FirstName

--Problem 7 - EEE-Mails
SELECT a.FirstName,
       a.LastName,
	   FORMAT(a.BirthDate,'MM-dd-yyyy') AS Birthdate,
	   c.Name AS Hometown,
	   a.Email
FROM Accounts a
JOIN Cities c
ON c.Id=a.CityId
WHERE a.Email LIKE 'e%'
ORDER BY c.Name DESC

--Problem 8 - City Statistics
SELECT c.Name,
       COUNT(h.Id) AS Hotels
FROM Cities c
LEFT JOIN Hotels h
ON h.CityId=c.Id
GROUP BY c.Name
ORDER BY Hotels DESC, c.Name

--Problem 9 - Expensive First-Class Rooms
SELECT r.Id,
       r.Price,
	   h.Name,
	   c.Name
FROM Rooms r
JOIN Hotels h
ON h.Id=r.HotelId
JOIN Cities c
ON c.Id=h.CityId
WHERE r.Type='First Class'
ORDER BY r.Price DESC, r.Id

--Problem 10 - Longest and Shortest Trips
SELECT a.Id AS AccountId,
	   CONCAT(a.FirstName,' ',a.LastName) AS [FullName],
	   MAX(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate)) AS LongestTrip,
	   MIN(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate)) AS ShortestTrip
FROM Accounts a
JOIN AccountsTrips act
ON act.AccountId=a.Id
JOIN Trips t
ON t.Id=act.TripId
WHERE a.MiddleName IS NULL
AND t.CancelDate IS NULL
GROUP BY CONCAT(a.FirstName,' ',a.LastName),a.Id
ORDER BY LongestTrip DESC, a.Id

--Problem 11 - Metropolis
SELECT TOP 5
       c.Id,
	   c.Name,
	   c.CountryCode,
	   COUNT(a.Id) AS Accounts
FROM Cities c
JOIN Accounts a
ON a.CityId=c.Id
GROUP BY c.Id,c.Name, c.CountryCode
ORDER BY Accounts DESC

--Problem 12 - Romantic Getaways
SELECT a.Id,
       a.Email,
	   cr.Name AS City,
	   COUNT(*) AS Trips
FROM Accounts a
JOIN AccountsTrips act
ON act.AccountId=a.Id
JOIN Trips t
ON t.Id=act.TripId
JOIN Rooms r
ON r.Id=t.RoomId
JOIN Hotels h
ON h.Id=r.HotelId
JOIN Cities cr
ON cr.Id=h.CityId
WHERE cr.Id=a.CityId
GROUP BY a.Id, a.Email,cr.Name
ORDER BY Trips DESC, a.Id

--Problem 13 - Lucrative Destinations
SELECT TOP 10
       c.Id,
	   c.Name,
	   SUM(ISNULL(h.BaseRate,0)+ISNULL(r.Price,0)) AS TotalRevenue,
	   COUNT(t.Id) AS TripCount
FROM Cities c
JOIN Hotels h
ON h.CityId=c.Id
JOIN Rooms r
ON r.HotelId=h.Id
JOIN Trips t
ON t.RoomId=r.Id
WHERE YEAR(t.BookDate)=2016
GROUP BY c.Id, c.Name
ORDER BY TotalRevenue DESC, TripCount DESC

--Problem 14 - Trip Revenues
WITH CTE_UnorderedTrips(TripId, HotelName, Type, Revenue)
AS
(
SELECT t.Id,
       h.Name,
       r.Type,
	   IIF(t.CancelDate IS NULL,SUM(h.BaseRate+r.Price),0) AS Revenue
FROM Trips t
JOIN Rooms r
ON r.Id=t.RoomId
JOIN Hotels h
ON h.Id=r.HotelId
JOIN AccountsTrips act
ON act.TripId=t.Id
GROUP BY t.Id,h.Name, r.Type, t.CancelDate
)

SELECT *
FROM CTE_UnorderedTrips
ORDER BY Type, TripId

--Problem 15 - Top Travelers
SELECT RankedCountries.AccountId,
       RankedCountries.Email,
	   RankedCountries.CountryCode,
	   RankedCountries.TotalTrips AS Trips
FROM
(
	SELECT a.Id AS AccountId,
		   a.Email,
		   ct.CountryCode,
		   COUNT(t.Id) AS TotalTrips,
		   DENSE_RANK() OVER (PARTITION BY ct.CountryCode
							  ORDER BY COUNT(t.Id) DESC,a.Id) AS TripRank
	FROM Accounts a
	JOIN AccountsTrips act
	ON act.AccountId=a.Id
	JOIN Trips t
	ON t.Id=act.TripId
	JOIN Rooms r
	ON r.Id=t.RoomId
	JOIN Hotels h 
	ON h.Id=r.HotelId
	JOIN Cities ct
	ON ct.Id=h.CityId
	GROUP BY ct.CountryCode, a.Email, a.Id
) AS RankedCountries
WHERE RankedCountries.TripRank=1
ORDER BY RankedCountries.TotalTrips DESC, RankedCountries.AccountId

--Problem 16 - Luggage Fees
SELECT act.TripId,
       SUM(act.Luggage) AS TotalLuggage,
	   CONCAT('$',IIF(SUM(act.Luggage)>5,SUM(act.Luggage)*5,0)) AS Fee
FROM AccountsTrips act
GROUP BY act.TripId
HAVING SUM(act.Luggage)>0
ORDER BY SUM(act.Luggage) DESC

--Problem 17 - GDPR Violation
SELECT t.Id AS TripId,
       CONCAT(FirstName,' ',ISNULL(MiddleName+' ',''),LastName) AS [Full Name],
	   ca.Name AS [From],
	   ct.Name AS [To],
	   IIF(t.CancelDate IS NULL,CONCAT(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate),' days'),'Canceled') AS [Duration]
FROM AccountsTrips act
JOIN Accounts a
ON a.Id=act.AccountId
JOIN Trips t
ON t.Id=act.TripId
JOIN Rooms r
ON r.Id=t.RoomId
JOIN Hotels h
ON h.Id=r.HotelId
JOIN Cities ct
ON ct.Id=h.CityId
JOIN Cities ca
ON ca.Id=a.CityId
ORDER BY [Full Name], t.Id