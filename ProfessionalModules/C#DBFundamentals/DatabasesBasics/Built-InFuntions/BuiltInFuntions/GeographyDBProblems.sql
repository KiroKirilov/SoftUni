--Problem 10 - Countries Holding ‘A’ 3 or More Times
SELECT CountryName,IsoCode
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

--Problem 11 - Mix of Peak and River Names
SELECT PeakName, RiverName,
	   LOWER(SUBSTRING(PeakName, 1, LEN(PeakName) - 1) + RiverName) AS [Mix]
FROM Peaks
JOIN Rivers
ON RIGHT(Peaks.PeakName,1) = LEFT(Rivers.RiverName,1)
ORDER BY Mix