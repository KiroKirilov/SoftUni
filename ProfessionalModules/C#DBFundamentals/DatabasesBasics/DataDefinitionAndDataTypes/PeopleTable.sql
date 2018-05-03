CREATE DATABASE PeopleDB
USE PeopleDB

--Problem 7 - Create Table People

CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(200) NOT NULL,
	Picture VARBINARY(2000),
	Height DECIMAL(15,2),
	Weight DECIMAL(15,2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX),	
	CONSTRAINT CK_People_Gender CHECK (Gender='m' OR Gender='f')
)

INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthdate, Biography) VALUES
('Genadi', 011101, 1.64, 65.77, 'm', '1995/01/07', 'Obicha slivovata'),
('Stavri', 0111, 1.88, 87.00, 'm', '1990/06/11', 'Samo levski i tesni...'),
('Haralampi', 101, 1.64, 65.77, 'm', '1989/05/03', 'Da verno taka se kazvam'),
('Minka', 0010, 1.70, 60.52, 'f', '2004/06/06', 'Vyzrastta e samo chislo'),
('Miumiun', 10010101, 1.90, 85.7, 'm', '1995/08/08', 'LDAJGHKDSJHKJSDGH')