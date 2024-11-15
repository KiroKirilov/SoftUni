--Problem 12 - Highest Peaks in Bulgaria
SELECT c.CountryCode,
       m.MountainRange,
	   p.PeakName,
	   p.Elevation
FROM Countries AS c
JOIN MountainsCountries AS mc
ON mc.CountryCode=c.CountryCode
JOIN Mountains AS m
ON m.Id=mc.MountainId
JOIN Peaks AS p
ON p.MountainId=m.Id
WHERE c.CountryCode='BG'
AND p.Elevation>2835
ORDER BY p.Elevation DESC

--Problem 13 - Count Mountain Ranges
SELECT CountryCode, COUNT(MountainId) AS MountainRanges
FROM MountainsCountries
WHERE CountryCode IN ('BG','US','RU')
GROUP BY CountryCode

--Problem 14 - Countries with Rivers
SELECT TOP 5
       c.CountryName,
	   r.RiverName
FROM Countries AS c
JOIN Continents AS conts
ON conts.ContinentCode = c.ContinentCode
LEFT OUTER JOIN CountriesRivers AS cr
ON cr.CountryCode=c.CountryCode
LEFT OUTER JOIN Rivers AS r
ON r.Id=cr.RiverId
WHERE conts.ContinentCode='AF'
ORDER BY c.CountryName

--Problem 15 - Continents and Currencies
SELECT OrderedCurrencies.ContinentCode,OrderedCurrencies.CurrencyCode,
OrderedCurrencies.CurrencyUsage
FROM
(SELECT c.CurrencyCode,
	   c.ContinentCode,
       COUNT(c.CountryName) AS CurrencyUsage,
	   DENSE_RANK() OVER (PARTITION BY ContinentCode
	                      ORDER BY COUNT(CurrencyCode) DESC
) AS [UsageRank]
FROM Countries c
GROUP BY c.CurrencyCode, c.ContinentCode
HAVING COUNT(c.CountryName)>1) AS OrderedCurrencies
WHERE OrderedCurrencies.UsageRank=1

--Problem 16 - Countries without any Mountains
SELECT COUNT(c.CountryCode) AS CountryCode
FROM Countries AS c
LEFT OUTER JOIN MountainsCountries AS mc
ON mc.CountryCode=c.CountryCode
WHERE mc.MountainId IS NULL

--Problem 17 - Highest Peak and Longest River by Country
SELECT TOP 5
	   c.CountryName,
	   MAX(p.Elevation) AS HighestPeakElevation,
	   MAX(r.Length) AS LongestRiverLength
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
ON mc.CountryCode=c.CountryCode
LEFT JOIN Mountains AS m
ON m.Id=mc.MountainId
LEFT JOIN Peaks AS p
ON p.MountainId=m.Id
LEFT JOIN CountriesRivers AS cr
ON cr.CountryCode=c.CountryCode
LEFT JOIN Rivers AS r
ON r.Id=cr.RiverId
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName

--Problem 18 - Highest Peak Name and Elevation by Country
WITH CTE_PeakInfo (CountryName, PeakName, Elevation, MountainRange)
AS
(
	SELECT c.CountryName,
		   p.PeakName,
		   MAX(p.Elevation),
		   m.MountainRange
	FROM Countries c
	LEFT JOIN MountainsCountries mc
	ON mc.CountryCode=c.CountryCode
	LEFT JOIN Mountains m
	ON m.Id=mc.MountainId
	LEFT JOIN Peaks p
	ON p.MountainId=m.Id
	GROUP BY c.CountryName, p.PeakName, m.MountainRange
)

SELECT TOP 5
       e.CountryName AS [Country],
       ISNULL(PeakName,'(no highest peak)') AS [Highest Peak Name],
	   ISNULL(Elevation,0) AS [Highest Peak Elevation],
	   ISNULL(MountainRange,'(no mountain)') AS [Mountain]
FROM
(
	SELECT CountryName,
		   MAX(Elevation) AS HighestElevation
	FROM CTE_PeakInfo
	GROUP BY CountryName
) AS e
LEFT JOIN CTE_PeakInfo cpi
ON cpi.CountryName=e.CountryName
AND cpi.Elevation=e.HighestElevation
ORDER BY e.CountryName,cpi.PeakName