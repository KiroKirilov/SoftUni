CREATE DATABASE TableRelationsExercises
GO
USE TableRelationsExercises

--Problem 1 - One-To-One Relationship

CREATE TABLE Passports (
  PassportID int NOT NULL,
  PassportNumber varchar(50) NOT NULL UNIQUE
)
CREATE TABLE Persons (
  PersonID int NOT NULL,
  FirstName nvarchar(50) NOT NULL,
  Salary money NOT NULL,
  PassportID int NOT NULL
)

INSERT INTO Passports VALUES 
  (101, 'N34FG21B'), 
  (102, 'K65LO4R7'), 
  (103, 'ZE657QP2')

INSERT INTO Persons VALUES 
  (1, 'Roberto', 43330.00, 102),
  (2, 'Tom', 56100.00, 103),
  (3, 'Yana', 60200.00, 101)

ALTER TABLE Persons
ADD CONSTRAINT PK_Persons PRIMARY KEY (PersonID)

ALTER TABLE Passports
ADD CONSTRAINT PK_Passports PRIMARY KEY (PassportID)

ALTER TABLE Persons
ADD CONSTRAINT FK_Persons_Passports FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)

--Problem 2 - One-To-Many Relationship
CREATE TABLE Manufacturers (
  ManufacturerID int NOT NULL,
  Name nvarchar(50) NOT NULL,
  EstablishedOn date, 
  CONSTRAINT PK_Manufacturers PRIMARY KEY (ManufacturerID)
)

CREATE TABLE Models (
  ModelID int NOT NULL,
  Name nvarchar(50) NOT NULL,
  ManufacturerID int NOT NULL,
  CONSTRAINT PK_Models PRIMARY KEY (ModelID),
  CONSTRAINT FK_Models_Manufacturers FOREIGN KEY (ManufacturerID) 
    REFERENCES Manufacturers (ManufacturerID)
)

INSERT INTO Manufacturers VALUES
  (1, 'BMW', '1916/03/07'),
  (2, 'Tesla', '2003/01/01'),
  (3, 'Lada', '1966/05/01')

INSERT INTO Models VALUES
  (101, 'X1', 1),
  (102, 'i6', 1),
  (103, 'Model S', 2),
  (104, 'Model X', 2),
  (105, 'Model 3', 2),
  (106, 'Nova', 3)

--Problem 3 - Many-To-Many Relationship
CREATE TABLE Students (
  StudentID INT NOT NULL,
  Name nvarchar(50) NOT NULL,
  CONSTRAINT PK_Students PRIMARY KEY (StudentID)
)

CREATE TABLE Exams (
  ExamID int NOT NULL,
  Name nvarchar(50) NOT NULL,
  CONSTRAINT PK_Exams PRIMARY KEY (ExamID)
)

CREATE TABLE StudentsExams (
  StudentID int NOT NULL,
  ExamID int NOT NULL
  CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentID,ExamID),
  CONSTRAINT FK_StudentsExams_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
  CONSTRAINT FK_StudentsExams_Exams FOREIGN KEY (ExamID) REFERENCES Exams(ExamID),
)

INSERT INTO Students VALUES
  (1, 'Mila'), 
  (2, 'Toni'), 
  (3, 'Ron')

INSERT INTO Exams VALUES
  (101, 'SpringMVC'), 
  (102, 'Neo4j'), 
  (103, 'Oracle 11g')

INSERT INTO StudentsExams VALUES
  (1, 101), 
  (1, 102), 
  (2, 101), 
  (3, 103), 
  (2, 102), 
  (2, 103)

 --Problem 4 - Self-Referencing 
 CREATE TABLE Teachers (
  TeacherID INT NOT NULL,
  Name nvarchar(50) NOT NULL,
  ManagerID INT,
  CONSTRAINT PK_Teachers PRIMARY KEY (TeacherID),
  CONSTRAINT FK_Teachers_Teachers FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers VALUES
  (101, 'John', NULL),
  (102, 'Maya', 106),
  (103, 'Silvia', 106),
  (104, 'Ted', 105),
  (105, 'Mark', 101),
  (106, 'Greta', 101)

--Problem 5 - Online Store Database
CREATE TABLE Cities (
	CityID INT NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_Cities PRIMARY KEY (CityID)
)

CREATE TABLE ItemTypes (
	ItemTypeID INT NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_ItemTypes PRIMARY KEY (ItemTypeID)
)

CREATE TABLE Items (
	ItemID INT NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	ItemTypeID INT NOT NULL,
	CONSTRAINT PK_Items PRIMARY KEY (ItemID),
	CONSTRAINT FK_Items_ItemTypes FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE Customers (
	CustomerID INT NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Birthday DATE NOT NULL,
	CityID INT NOT NULL,
	CONSTRAINT PK_Customers PRIMARY KEY (CustomerID),
	CONSTRAINT FK_Customers_Cities FOREIGN KEY (CityID) REFERENCES Cities(CityID)
)

CREATE TABLE Orders (
	OrderID INT NOT NULL,
	CustomerID INT NOT NULL,
	CONSTRAINT PK_Orders PRIMARY KEY (OrderID),
	CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE OrderItems (
	OrderID INT NOT NULL,
	ItemID INT NOT NULL,
	CONSTRAINT PK_OrderItems PRIMARY KEY (OrderID, ItemID),
	CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
	CONSTRAINT FK_OrderItems_Items FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
)

--Problem 6 - University Database
CREATE TABLE Majors (
	MajorID INT NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_Majors PRIMARY KEY (MajorID)
)

CREATE TABLE Subjects (
	SubjectID INT NOT NULL,
	SubjectName NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_Subjects PRIMARY KEY (SubjectID)
)

CREATE TABLE Students (
	StudentID INT NOT NULL,
	StudentNumber INT NOT NULL,
	StudentName NVARCHAR(50) NOT NULL,
	MajorID INT NOT NULL,
	CONSTRAINT PK_Students PRIMARY KEY (StudentID),
	CONSTRAINT FK_Students_Majors FOREIGN KEY (MajorID) REFERENCES Majors(MajorID)
)

CREATE TABLE Payments (
	PaymentID INT NOT NULL,
	PaymentDate DATE NOT NULL,
	PaymentAmount DECIMAL(15,2) NOT NULL,
	StudentID INT NOT NULL,
	CONSTRAINT PK_Payments PRIMARY KEY (PaymentID),
	CONSTRAINT FK_Payments_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
)

CREATE TABLE Agenda (
	StudentID INT NOT NULL,
	SubjectID INT NOT NULL
	CONSTRAINT PK_Agenda PRIMARY KEY (StudentID,SubjectID),
	CONSTRAINT FK_Agenda_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
	CONSTRAINT FK_Agenda_Subjects FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
)