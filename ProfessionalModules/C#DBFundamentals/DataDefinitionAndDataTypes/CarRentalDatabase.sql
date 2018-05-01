CREATE DATABASE CarRentalDB
USE CarRentalDB

--Problem 14 - Car rental database

--•	Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName NVARCHAR(100) NOT NULL,
	DailyRate DECIMAL(15,2) CHECK (DailyRate>=0) NOT NULL,
	WeeklyRate DECIMAL(15,2) CHECK (WeeklyRate>=0) NOT NULL,
	MonthlyRate DECIMAL(15,2) CHECK (MonthlyRate>=0) NOT NULL,
	WeekendRate DECIMAL(15,2) CHECK (WeekendRate>=0) NOT NULL
)

--•	Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
CREATE TABLE Cars (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	PlateNumber NVARCHAR(10) NOT NULL,
	Manufacturer NVARCHAR(100) NOT NULL,
	Model NVARCHAR(100) NOT NULL,
	CarYear INT CHECK (CarYear>=1900) NOT NULL,
	CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
	Doors INT NOT NULL CHECK (Doors>0 AND Doors<=5),
	Picture VARBINARY(MAX),
	Condition NVARCHAR(100),
	Available BIT DEFAULT 1
)

--•	Employees (Id, FirstName, LastName, Title, Notes)
CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	Title NVARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
)
--•	Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DriverLicenceNumber NVARCHAR(20) NOT NULL,
	FullName NVARCHAR(200) NOT NULL,
	Address NVARCHAR(200) NOT NULL,
	City NVARCHAR(50) NOT NULL,
	ZipCode NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)
--•	RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, 
--                TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
	TankLevel DECIMAL(15,2) NOT NULL,
	KilometrageStart DECIMAL(15,2) NOT NULL,
	KilometrageEnd DECIMAL(15,2) NOT NULL,
	TotalKilometrage AS (KilometrageEnd-KilometrageStart),
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays AS (DATEDIFF(DAY,StartDate,EndDate)+1),
	RateApplied DECIMAL(15,2) NOT NULL,
	TaxRate DECIMAL(15,2) NOT NULL,
	OrderStatus NVARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('Broke', 10, 60, 1500, 50),
('Bougie', 100, 600, 2500, 150),
('FiltyRich', 500, 2500, 9000, 750)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
('PK6969AC', 'Audi', 'A3', 2016, 2, 2, NULL, 'Dope', 1),
('CA0123BT', 'BMW', 'X5', 2016, 1, 4, NULL, 'Decent', 1),
('CO4567OP', 'Lada', '2107', 2018, 3, 4, 0121111, 'The best there is', 0)


INSERT INTO Employees (FirstName, LastName, Title) VALUES
('Stavri', 'Ismailov', 'Shef'),
('Genadi', 'Ivanov', 'Glavniq Iliev'),
('Haralampi', 'Lamqta', 'Obshtak')

INSERT INTO Customers (DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes) VALUES
('123456', 'Genadi ama drugiq', 'Drujba 2', 'Sofiqta bace', '1000', 'obiknov chovek'),
('12354334', 'Azis', 'na nekoi genitalite', 'Kostinbrod', '2120', 'namerete me v adam tyrsi adam'),
('3453432', 'Mom4eto', 'ygyla', 'kvartala', '2260', NULL)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, StartDate, EndDate, RateApplied, TaxRate, OrderStatus, Notes)
VALUES  
(1, 1, 1, 100, 100, 200.5,  '2018-01-22', '2018-01-23', 15, 0.20, 'Rented', NULL),
(2, 2, 2, 100,100, 100.5,  '2018-01-20', '2018-01-22', 80, 0.20, 'Pending', 'Zima e, ne mojah da q karam'),
(3, 3, 3, 2, 270000, 200000, '2018-01-21', '2018-04-30', 110, 0.20, 'Closed', NULL)
