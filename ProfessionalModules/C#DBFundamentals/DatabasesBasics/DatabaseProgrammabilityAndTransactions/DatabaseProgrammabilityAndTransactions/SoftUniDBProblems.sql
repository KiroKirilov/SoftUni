USE SoftUni

GO
--Problem 1 - Employees with Salary Above 35000
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS
BEGIN
  SELECT FirstName, LastName
  FROM Employees
  WHERE Salary>35000
END

GO
--Problem 2 - Employees with Salary Above Number
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber 
                 @Number DECIMAL(18,4)
AS
BEGIN
  SELECT FirstName, LastName
  FROM Employees
  WHERE Salary>=@Number
END

GO
--Problem 3 - Town Names Starting With
CREATE PROCEDURE usp_GetTownsStartingWith  
                 @StartsWith VARCHAR(MAX)
AS
BEGIN
  SELECT Name AS [Town]
  FROM Towns
  WHERE LEFT(Name,LEN(@StartsWith))=@StartsWith
END

GO
--Problem 4 - Employees from Town
CREATE PROCEDURE usp_GetEmployeesFromTown   
                 @TownName VARCHAR(MAX)
AS
  SELECT FirstName, LastName
  FROM Employees AS e
  JOIN Addresses AS a
  ON a.AddressID=e.AddressID
  JOIN Towns AS t
  ON t.TownID = a.TownID
  WHERE t.Name=@TownName

GO
--Problem 5 - Salary Level Function
CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS VARCHAR(10)
AS
BEGIN
  DECLARE @SalaryLevel VARCHAR(10)='High'

  IF (@salary<30000) 
    SET @SalaryLevel='Low'
  ELSE IF (@salary<=50000) 
    SET @SalaryLevel='Average'

  RETURN @SalaryLevel
END

GO
--Problem 6 - Employees by Salary Level
CREATE PROCEDURE usp_EmployeesBySalaryLevel 
					@SalaryLevel VARCHAR(MAX)
AS
  SELECT FirstName, LastName
  FROM Employees
  WHERE dbo.ufn_GetSalaryLevel(Salary)=@SalaryLevel

GO
--Problem 7 - Define Function
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters varchar(max), @word varchar(max))
RETURNS bit
AS
BEGIN
  DECLARE @isComprised bit = 0;
  DECLARE @currentIndex int = 1;
  DECLARE @currentChar char;

  WHILE(@currentIndex <= LEN(@word))
  BEGIN
    SET @currentChar = SUBSTRING(@word, @currentIndex, 1);
    IF(CHARINDEX(@currentChar, @setOfLetters) = 0)
      RETURN @isComprised;
    SET @currentIndex += 1;
  END
  RETURN @isComprised + 1;
END

GO
--Problem 8 - Delete Employees and Departments
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment(@departmentId INT)
AS
  ALTER TABLE Departments
    ALTER COLUMN ManagerID INT NULL

  DELETE FROM EmployeesProjects
  WHERE EmployeeID IN
        (
          SELECT EmployeeID
          FROM Employees
          WHERE DepartmentID = @departmentId
        )

  UPDATE Employees
  SET ManagerID = NULL
  WHERE ManagerID IN
        (
          SELECT EmployeeID
          FROM Employees
          WHERE DepartmentID = @departmentId
        )

  UPDATE Departments
  SET ManagerID = NULL
  WHERE ManagerID IN
        (
          SELECT EmployeeID
          FROM Employees
          WHERE DepartmentID = @departmentId
        )

  DELETE FROM Employees
  WHERE EmployeeID IN
        (
          SELECT EmployeeID
          FROM Employees
          WHERE DepartmentID = @departmentId
        )

  DELETE FROM Departments
  WHERE DepartmentID = @departmentId

  SELECT COUNT(*) AS [Employees Count]
  FROM Employees AS E
    JOIN Departments AS D
      ON D.DepartmentID = E.DepartmentID
WHERE E.DepartmentID = @departmentId

GO
--Problem 21 - Employees with Three Projects
CREATE PROCEDURE usp_AssignProject(@emloyeeId INT, @projectID INT) 
AS
BEGIN
	DECLARE @EmployeeProjectsCount INT =(SELECT COUNT(ProjectID)
	                                       FROM EmployeesProjects
	                                   GROUP BY EmployeeID
	                                     HAVING EmployeeID=@emloyeeId);
	BEGIN TRANSACTION
		IF (@EmployeeProjectsCount>2)
		BEGIN 
			RAISERROR ('The employee has too many projects!', 16, 1)
			ROLLBACK;
			RETURN
		END
		ELSE
		BEGIN
			INSERT INTO EmployeesProjects VALUES (@emloyeeId,@projectID)
			COMMIT
		END
END

GO
--Problem 22 - Delete Employees
CREATE TABLE Deleted_Employees
(
	EmployeeId INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(100),
	LastName NVARCHAR(100),
	MiddleName NVARCHAR(100),
	JobTitle NVARCHAR(100),
	DepartmentId INT,
	Salary MONEY
) 

GO

CREATE TRIGGER InsertFiredEmployeesInDeletedRecords
ON Employees
AFTER DELETE
AS
	INSERT INTO Deleted_Employees 
		SELECT FirstName,
			   LastName,
			   MiddleName,
			   JobTitle,
			   DepartmentID,
			   Salary
		FROM deleted
		