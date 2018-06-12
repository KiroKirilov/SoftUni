USE Diablo
GO

--Problem 1 - Number of Users for Email Provider
SELECT SUBSTRING(Email, CHARINDEX('@',Email,1)+1,1000) AS [Email Provider],
       COUNT(*) AS [Number Of Users]
FROM Users
GROUP BY SUBSTRING(Email, CHARINDEX('@',Email,1)+1,1000)
ORDER BY [Number Of Users] DESC, [Email Provider]

--Problem 2 - All User in Games
SELECT g.Name,
       gt.Name,
	   u.Username,
	   ug.Level,
	   ug.Cash,
	   c.Name
FROM Games g
JOIN UsersGames AS ug
ON ug.GameId=g.Id
JOIN Users u
ON u.Id=ug.UserId
JOIN Characters c
ON c.Id=ug.CharacterId
JOIN GameTypes AS gt
ON gt.Id=g.GameTypeId
ORDER BY ug.Level DESC, u.Username, g.Name

--Problem 3 - Users in Games with Their Items
SELECT u.Username,
       g.Name AS Game,
	   COUNT(i.Id) AS [Items Count],
	   SUM(i.Price) AS [Items Price]
FROM Users u
INNER JOIN UsersGames ug
ON ug.UserId=u.Id
INNER JOIN Games g
ON g.Id=ug.GameId
INNER JOIN UserGameItems ugi
ON ugi.UserGameId=ug.Id
INNER JOIN Items i
ON i.Id=ugi.ItemId
GROUP BY u.Username, g.Name
HAVING COUNT(i.Id)>=10
ORDER BY [Items Count] DESC, [Items Price] DESC, u.Username

--Problem 4 - User in Games with Their Statistics
SELECT u.Username,
       g.Name,
	   MAX(c.Name) AS Character,
	   MAX(s1.Strength) + MAX(s2.Strength) + SUM(s3.Strength) AS Strength,
	   MAX(s1.Defence) + MAX(s2.Defence) + SUM(s3.Defence)    AS Defence,
	   MAX(s1.Speed) + MAX(s2.Speed) + SUM(s3.Speed)          AS Speed,
	   MAX(s1.Mind) + MAX(s2.Mind) + SUM(s3.Mind)             AS Mind,
	   MAX(s1.Luck) + MAX(s2.Luck) + SUM(s3.Luck)             AS Luck
FROM UsersGames ug
JOIN Users u
ON u.Id=ug.UserId
JOIN Games g
ON g.Id=ug.GameId
JOIN Characters c
ON c.Id=ug.CharacterId
JOIN [Statistics] s1
ON s1.Id=c.StatisticId
JOIN GameTypes gt
ON gt.Id=g.GameTypeId
JOIN [Statistics] s2
ON s2.Id=gt.BonusStatsId
JOIN UserGameItems ugi
ON ugi.UserGameId=ug.Id
JOIN Items i
ON i.Id=ugi.ItemId
JOIN [Statistics] s3
ON s3.Id=i.StatisticId
GROUP BY u.Username, g.Name
ORDER BY Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC

--Problem 5 - All Items with Greater than Average Statistics
SELECT i.Name,
       i.Price,
	   i.MinLevel,
	   Averages.Strength,
	   Averages.Defence,
	   Averages.Speed,
	   Averages.Luck,
	   Averages.Mind
FROM (
		SELECT *
		FROM [Statistics]
		WHERE Mind>(SELECT AVG(Mind) FROM [Statistics]) 
		  AND Luck>(SELECT AVG(Luck) FROM [Statistics]) 
		  AND Speed>(SELECT AVG(Speed) FROM [Statistics])) AS Averages
JOIN Items i
ON i.StatisticId=Averages.Id
ORDER BY i.Name

--Problem 6 - Display All Items with Information about Forbidden Game Type
SELECT i.Name AS [Item],
       i.Price,
	   i.MinLevel,
	   gt.Name AS [Forbidden Game Type]
FROM Items i
LEFT OUTER JOIN GameTypeForbiddenItems gtfi
ON gtfi.ItemId=i.Id
LEFT OUTER JOIN GameTypes gt
ON gt.Id=gtfi.GameTypeId
ORDER BY [Forbidden Game Type] DESC,[Item]

--Problem 7 - Buy Items for User in Game
DECLARE @gameName NVARCHAR(50) = 'Edinburgh'
DECLARE @username NVARCHAR(50) = 'Alex'

DECLARE @userGameId INT = (
  SELECT ug.Id
  FROM UsersGames AS ug
    JOIN Users AS u
      ON ug.UserId = u.Id
    JOIN Games AS g
      ON ug.GameId = g.Id
  WHERE u.Username = @username AND g.Name = @gameName
)

DECLARE @availableCash MONEY = (
  SELECT Cash
  FROM UsersGames
  WHERE Id = @userGameId
)

DECLARE @purchasePrice MONEY = (
  SELECT sum(Price)
  FROM Items
  WHERE Name IN (
    'Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)',
    'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet'
  )
)

IF (@availableCash >= @purchasePrice)
  BEGIN
    BEGIN TRANSACTION
    UPDATE UsersGames
    SET Cash -= @purchasePrice
    WHERE Id = @userGameId

    IF (@@ROWCOUNT <> 1)
      BEGIN
        ROLLBACK
        RAISERROR ('Could not make playment', 16, 1)
        RETURN
      END

    INSERT INTO UserGameItems (ItemId, UserGameId)
      (SELECT
         Id,
         @userGameId
       FROM Items
       WHERE Name IN
             ('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)',
              'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet'))

    IF ((SELECT count(*)
         FROM Items
         WHERE Name IN (
           'Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)',
           'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet'
         )) <> @@ROWCOUNT)
      BEGIN
        ROLLBACK
        RAISERROR ('Could not buy items', 16, 1)
        RETURN
      END
    COMMIT
  END

SELECT
  u.Username,
  g.Name,
  ug.Cash,
  i.Name AS [Item Name]
FROM UsersGames AS ug
  JOIN Games AS g
    ON ug.GameId = g.Id
  JOIN Users AS u
    ON ug.UserId = u.Id
  JOIN UserGameItems AS item
    ON ug.Id = item.UserGameId
  JOIN Items AS i
    ON item.ItemId = i.Id
WHERE g.Name = @gameName