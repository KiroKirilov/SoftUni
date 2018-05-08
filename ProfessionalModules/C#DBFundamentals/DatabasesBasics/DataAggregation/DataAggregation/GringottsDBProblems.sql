--Problem 1 - Records' count
SELECT COUNT(Id) AS [Count]
FROM WizzardDeposits

--Problem 2 - Longest magic wand
SELECT MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits

--Problem 3 - Longest magic wand per deposit group
SELECT DepositGroup,
	   MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits
GROUP BY DepositGroup

--Problem 4 - Smallest Deposit Group per Magic Wand Size
SELECT TOP 2 DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

--Problem 5 - Deposit sum
SELECT DepositGroup,
	   SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
GROUP BY DepositGroup

--Problem 6 - Deposits Sum for Ollivander Family
SELECT DepositGroup,
	   SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
WHERE MagicWandCreator='Ollivander family'
GROUP BY DepositGroup	

--Problem 7 - Deposits Filter
SELECT DepositGroup,
	   SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
WHERE MagicWandCreator='Ollivander family'
GROUP BY DepositGroup	
HAVING SUM(DepositAmount)<150000
ORDER BY TotalSum DESC

--Problem 8 - Deposit charge
SELECT DepositGroup,
	   MagicWandCreator,
	   MIN(DepositCharge) AS [MinDepositCharge]
FROM WizzardDeposits
GROUP BY DepositGroup,MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

--Problem 9 - Age groups
SELECT
	CASE
		WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		WHEN Age >=61 THEN '[61+]'
	END AS [SizeGroup],
	COUNT(*) AS [WizardCount]
FROM WizzardDeposits
GROUP BY
	CASE
		WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		WHEN Age >=61 THEN '[61+]'
	END

--Problem 10 - First Letter
SELECT LEFT(FirstName,1) AS [FirstLetter]
FROM WizzardDeposits
WHERE DepositGroup='Troll Chest'
GROUP BY LEFT(FirstName,1)

--Problem 11 - Average interest
SELECT DepositGroup, IsDepositExpired, 
	   AVG(DepositInterest) AS [AverageInterest]
FROM WizzardDeposits
WHERE DepositStartDate >= CONVERT(DATETIME, '01/01/1985')
GROUP BY IsDepositExpired,DepositGroup
ORDER BY DepositGroup DESC, IsDepositExpired

--Problem 12 - Rich Wizard, Poor Wizard
SELECT TOP 1
	(SELECT DepositAmount FROM WizzardDeposits Where Id=(SELECT MIN(Id) FROM WizzardDeposits)) -
	(SELECT DepositAmount FROM WizzardDeposits Where Id=(SELECT MAX(Id) FROM WizzardDeposits))
	AS [SumDifference]
FROM WizzardDeposits