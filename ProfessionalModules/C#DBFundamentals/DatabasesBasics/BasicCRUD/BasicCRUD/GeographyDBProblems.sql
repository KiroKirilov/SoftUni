--Problem 22 - All mountain peaks
  SELECT PeakName 
    FROM Peaks
ORDER BY PeakName

--Problem 23 - Biggest countries by population
  SELECT TOP 30 CountryName,Population
    FROM Countries
   WHERE ContinentCode ='EU'
ORDER BY Population DESC, CountryName

--Problem 24 - Countries and Currency (Euro / Not Euro)
SELECT 
	CountryName,CountryCode,
	IIF(Currencies.CurrencyCode='EUR','Euro','Not Euro') AS [Currency]
FROM Countries
LEFT JOIN Currencies ON Currencies.CurrencyCode = Countries.CurrencyCode
ORDER BY CountryName
