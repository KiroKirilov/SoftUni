CREATE DATABASE MoviesDB
USE MoviesDB

--Problem 13 - Movies database
--•	Directors (Id, DirectorName, Notes)
--•	Genres (Id, GenreName, Notes)
--•	Categories (Id, CategoryName, Notes)
--•	Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)

CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DirectorName NVARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	GenreName NVARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName NVARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Title NVARCHAR(100) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
	CopyrightYear INT NOT NULL,
	Length INT NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Rating DECIMAL(2,1),
	Notes NVARCHAR(MAX),
	CHECK (CopyrightYear>=1900),
	CHECK (Rating>0 AND Rating<10),
	CHECK (Length>0)
)

INSERT INTO Genres (GenreName) VALUES
('Horror'),
('Porn'),
('Thriller'),
('Sci-Fi'),
('Drama')

INSERT INTO Directors (DirectorName) VALUES
('Genadi'),
('Stavri'),
('Ismail'),
('Stamat'),
('Prakash')

INSERT INTO Categories (CategoryName) VALUES
('PG-13'),
('R'),
('Kids'),
('E'),
('Ne struva')



INSERT INTO Movies(Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating) VALUES
('Film',1,2001,15,1,1,1),
('movie',2,2010,190,2,2,5.5),
('klipche',5,1999,90,4,5,4.3),
('video',3,2017,60,3,4,1.1),
('dvijeshti se snimki',4,2005,123,5,3,9)
