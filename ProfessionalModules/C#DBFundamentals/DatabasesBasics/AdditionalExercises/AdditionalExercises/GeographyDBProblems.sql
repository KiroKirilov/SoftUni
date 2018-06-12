USE Geography
GO

--Problem 8 - Peaks and Mountains
SELECT p.PeakName,
       m.MountainRange,
	   p.Elevation
FROM Peaks p
JOIN Mountains m
ON m.Id=p.MountainId
ORDER BY p.Elevation DESC, p.PeakName

--Problem 9 - Peaks with Their Mountain, Country and Continent
SELECT p.PeakName,
       m.MountainRange,
	   c.CountryName,
	   conts.ContinentName
FROM Peaks p
JOIN Mountains m
ON m.Id=p.MountainId
JOIN MountainsCountries mc
ON mc.MountainId=m.Id
JOIN Countries c
ON c.CountryCode=mc.CountryCode
JOIN Continents conts
ON conts.ContinentCode=c.ContinentCode
ORDER BY p.PeakName, c.CountryName

--Problem 10 - Rivers by Country
SELECT c.CountryName,
	   MAX(conts.ContinentName) AS ContinentName,
	   COUNT(r.Id) AS [RiversCount],
	   IIF(SUM(r.Length) IS NULL, 0,SUM(r.Length)) AS [TotalLength]
FROM Countries c
LEFT JOIN Continents conts
ON conts.ContinentCode=c.ContinentCode
LEFT JOIN CountriesRivers cr
ON cr.CountryCode=c.CountryCode
LEFT JOIN Rivers r
ON r.Id=cr.RiverId
GROUP BY c.CountryName
ORDER BY RiversCount DESC, TotalLength DESC, c.CountryName

--Problem 11 - Count of Countries by Currency
SELECT cur.CurrencyCode,
	   cur.Description AS [Currency],
	   COUNT(c.CountryCode) AS [NumberOfCountries]
FROM Currencies cur
LEFT JOIN Countries c 
ON c.CurrencyCode=cur.CurrencyCode
GROUP BY cur.CurrencyCode, cur.Description
ORDER BY NumberOfCountries DESC, [Currency] ASC

--Problem 12 - Population and Area by Continent
SELECT cont.ContinentName,
       SUM(c.AreaInSqKm) AS [CountriesArea],
	   SUM(CAST(c.Population AS float)) AS [CountriesPopulation]
FROM Continents cont
JOIN Countries c
ON c.ContinentCode=cont.ContinentCode
GROUP BY cont.ContinentName
ORDER BY CountriesPopulation DESC

--Problem 13 - Monasteries by Country
CREATE TABLE Monasteries
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(MAX) NOT NULL,
	CountryCode CHAR(2) FOREIGN KEY REFERENCES Countries(CountryCode)
)

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

ALTER TABLE Countries
ADD IsDeleted BIT NOT NULL DEFAULT 0

UPDATE Countries
SET IsDeleted=1
WHERE CountryCode IN
(
	SELECT CountryCode
	FROM CountriesRivers 
	GROUP BY CountryCode
	HAVING COUNT(RiverId)>3
)

SELECT m.Name AS [Monastery],
       c.CountryName AS [Country]
FROM Monasteries m
JOIN Countries c
ON c.CountryCode=m.CountryCode
WHERE c.IsDeleted<>1
ORDER BY m.Name

--Problem 14 - Monasteries by Continents and Countries
UPDATE Countries
SET CountryName='Burma'
WHERE CountryName='Myanmar'

INSERT INTO Monasteries(Name, CountryCode)
(
	SELECT 'Hanga Abbey',
		    CountryCode
	FROM Countries
	WHERE CountryName='Tanzania'
)

INSERT INTO Monasteries (Name, CountryCode)
  (SELECT
     'Myin-Tin-Daik',
     CountryCode
   FROM Countries
WHERE CountryName = 'Myanmar')

SELECT cont.ContinentName AS [ContinentName],
	   c.CountryName AS [CountryName],
	   COUNT(m.Id) AS [MonasteriesCount]
FROM Countries c
LEFT JOIN Monasteries m
ON m.CountryCode=c.CountryCode
JOIN Continents cont
ON cont.ContinentCode=c.ContinentCode
WHERE c.IsDeleted=0
GROUP BY cont.ContinentName,c.CountryName
ORDER BY MonasteriesCount DESC, c.CountryName