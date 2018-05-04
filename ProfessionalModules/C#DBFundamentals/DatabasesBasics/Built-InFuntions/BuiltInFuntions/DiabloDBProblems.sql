--Problem 12 - Games from 2011 and 2012 year
SELECT TOP 50 Name,
              FORMAT(Start,'yyyy-MM-dd') AS [Start]
FROM Games
WHERE DATEPART(YEAR,Start) IN (2011,2012)
ORDER BY Start,Name

--Problem 13 - User Email Providers
SELECT Username,
       SUBSTRING(Email,CHARINDEX('@',Email,1)+1,1000) AS [Email Provider]
FROM Users
ORDER BY [Email Provider], Username

--Problem 14 - Get Users with IPAdress Like Pattern
SELECT Username, IpAddress
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

--Problem 15 - Show All Games with Duration and Part of the Day
SELECT Name AS [Game],
       IIF(DATEPART(HH, Start) >=18,'Evening',
		  IIF(DATEPART(HH,Start)>=12,'Afternoon','Morning'))
	   AS [Part of the Day],

	   IIF(Duration IS NULL,'Extra Long',
		  IIF(Duration>6,'Long',
		      IIF(Duration>=4,'Short','Extra Short')))
	   AS [Duration]
FROM Games
ORDER BY Name,Duration,[Part of the Day]