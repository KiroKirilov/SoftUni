CREATE DATABASE SoftUniDB
USE SoftUniDB


--Problem 16 - Create SoftUni database
CREATE TABLE Towns (
	Id int IDENTITY,
	Name nvarchar(200) NOT NULL,
	CONSTRAINT PK_Towns PRIMARY KEY (Id)
)

CREATE TABLE Addresses (
	Id int IDENTITY, 
	AddressText nvarchar(max) NOT NULL,
	TownId int NOT NULL,
	CONSTRAINT PK_Addresses PRIMARY KEY (Id),
	CONSTRAINT FK_Addresses_Towns FOREIGN KEY (TownId) REFERENCES Towns (Id)
)

CREATE TABLE Departments (
	Id int IDENTITY, 
	Name nvarchar(200) NOT NULL,
	CONSTRAINT PK_Departments PRIMARY KEY (Id)
)

CREATE TABLE Employees (
	Id int IDENTITY,
	FirstName nvarchar(200) NOT NULL,
	MiddleName nvarchar(200),
	LastName nvarchar(200) NOT NULL,
	JobTitle nvarchar(200) NOT NULL, 
	DepartmentId int NOT NULL, 
	HireDate date NOT NULL, 
	Salary money NOT NULL, 
	AddressId int,
	CONSTRAINT PK_Employees PRIMARY KEY (Id),
	CONSTRAINT FK_Employees_Departments FOREIGN KEY (DepartmentId) REFERENCES Departments (Id),
	CONSTRAINT FK_Employees_Addresses FOREIGN KEY (AddressId) REFERENCES Addresses (Id),
	CONSTRAINT CK_Employees_Salary CHECK (Salary >= 0)
)

--Problem 18 - Basic insert
INSERT INTO Towns (Name) VALUES
('Sofia'), ('Plovdiv'), ('Varna'), ('Burgas')

INSERT INTO Departments (Name) VALUES
('Engineering'), 
('Sales'), 
('Marketing'), 
('Software Development'), 
('Quality Assurance')

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary) VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013/02/01', 3500.00), 
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004/03/02', 4000.00), 
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016/08/28', 525.25), 
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007/12/09', 3000.00), 
('Peter', 'Pan', 'Pan', 'Intern', 3, '2016/08/28', 599.88)

--Problem 19 - Basic select all fields
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees


--Problem 20 - Basic select all fields and order them
SELECT * FROM Towns
ORDER BY Name

SELECT * FROM Departments
ORDER BY Name

SELECT * FROM Employees
ORDER BY Salary DESC

--Problem 21 - Basic Select Some Fields
SELECT Name FROM Towns
ORDER BY Name

SELECT Name FROM Departments
ORDER BY Name

SELECT FirstName,LastName,JobTitle,Salary FROM Employees
ORDER BY Salary DESC

--Problem 22 - Increase employees salary
UPDATE Employees
SET Salary *= 1.10

SELECT Salary FROM Employees