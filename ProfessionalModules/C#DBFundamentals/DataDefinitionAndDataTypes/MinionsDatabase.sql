--Problem 1 - Create database
CREATE DATABASE Minions

USE Minions

--Problem 2 - Create tables
CREATE TABLE Minions(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Age INT NOT NULL
)

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(50) NOT NULL
)

--Promblem 3 - Alter Minions Table
ALTER TABLE Minions
ADD TownId INT NOT NULL

ALTER TABLE Minions
ADD CONSTRAINT FK_TownIdInMinions FOREIGN KEY (TownId)     
    REFERENCES Towns (Id) 


--Problem 4 - Insert records in both tables

--1	Sofia
--2	Plovdiv
--3	Varna

INSERT INTO Towns (Id,Name) VALUES
(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna')


--name age townId
--Kevin	22	1
--Bob	15	3
--Steward	NULL	2

INSERT INTO Minions (Id,Name,Age,TownId) VALUES
(1,'Kevin',22,1),
(2,'Bob',15,3),
(3,'Steward',NULL,2)

--Problem 5 - Truncate Table Minions

TRUNCATE TABLE Minions

--Problem 6 - Drop all tables

DROP TABLE Minions
DROP TABLE Towns