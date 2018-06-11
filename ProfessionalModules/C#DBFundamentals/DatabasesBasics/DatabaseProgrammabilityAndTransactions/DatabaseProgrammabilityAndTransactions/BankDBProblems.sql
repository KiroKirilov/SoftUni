USE Bank

GO
--Problem 9 - Find Full Name  
CREATE PROCEDURE usp_GetHoldersFullName 
AS
  SELECT FirstName+' '+LastName AS [Full Name]
  FROM AccountHolders

GO
 --Problem 10 - People with Balance Higher Than
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan 
                      @Balance DECIMAL(16,2)
AS
  SELECT ah.FirstName, ah.LastName
  FROM Accounts AS a
  JOIN AccountHolders AS ah
  on ah.Id=a.AccountHolderId
  GROUP BY ah.FirstName,ah.LastName
  HAVING SUM(a.Balance)>@Balance

GO
--Problem 11 - Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue(@Sum MONEY, @YearlyInterestRate FLOAT, @NumberOfYears INT)
RETURNS MONEY
AS
BEGIN
  DECLARE @Result MONEY=@Sum*POWER(1+@YearlyInterestRate,@NumberOfYears);
  RETURN ROUND(@Result,4);
END

GO
--Problem 12 - Calculating Interest
CREATE PROCEDURE usp_CalculateFutureValueForAccount (@AccountId INT, @InterestRate FLOAT)
AS
BEGIN
  SELECT a.Id AS [Account Id],
         ah.FirstName AS [First Name], 
         ah.LastName AS [Last Name], 
         a.Balance AS [Current Balance],
         dbo.ufn_CalculateFutureValue(a.Balance,@InterestRate,5) AS [Balance in 5 years]
  FROM AccountHolders AS ah
  JOIN Accounts AS a
  ON a.AccountHolderId = ah.Id
  WHERE a.Id=@AccountId
END

GO

--Problem 14 - Create Table Logs
CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT,
	OldSum MONEY,
	NewSum MONEY
)

GO

CREATE TRIGGER InsertIntoLogs
	ON Accounts
	AFTER UPDATE
	AS
	  INSERT INTO Logs VALUES
	  (
	  	  (SELECT Id FROM inserted),
		  (SELECT Balance FROM deleted),
		  (SELECT Balance FROM inserted)
	  )
	
--Problem 15 - Create Table Emails
CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT,
	Subject NVARCHAR(MAX),
	Body NVARCHAR(MAX)
)

GO

CREATE TRIGGER CreateEmail
	ON Logs
	AFTER INSERT
	AS
		INSERT INTO NotificationEmails(Recipient, Subject,Body) VALUES
		(
			(SELECT AccountId FROM inserted),
			(CONCAT('Balance change for account: ', (SELECT AccountId
                                               FROM inserted))),
			(CONCAT('On ', (SELECT GETDATE()
                               FROM inserted), 'your balance was changed from ', (SELECT OldSum
                                                                                  FROM inserted), 'to ', (SELECT NewSum
                                                                                                          FROM inserted), '.'))
		)

GO
--Problem 16 - Deposit Money
CREATE PROCEDURE usp_DepositMoney (@AccountId INT, @MoneyAmount MONEY)
AS
	BEGIN TRANSACTION
	    UPDATE Accounts
		SET Balance+=@MoneyAmount
		WHERE Id=@AccountId
	COMMIT

GO
--Problem 17 - Withdraw Money
CREATE PROCEDURE usp_WithdrawMoney (@AccountId INT, @MoneyAmount MONEY)
AS
	BEGIN TRANSACTION
	    UPDATE Accounts
		SET Balance-=@MoneyAmount
		WHERE Id=@AccountId
	COMMIT

GO
--Problem 18 - Money Transfer
CREATE PROCEDURE usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount MONEY)
AS
  BEGIN
	BEGIN TRANSACTION
		EXEC usp_WithdrawMoney @SenderId, @Amount
		EXEC usp_DepositMoney @ReceiverId, @Amount

		IF ((SELECT Balance
			 FROM Accounts
			 WHERE Id=@SenderId)<0)
		BEGIN
			ROLLBACK
		END
		ELSE 
		BEGIN
			COMMIT
		END
  END