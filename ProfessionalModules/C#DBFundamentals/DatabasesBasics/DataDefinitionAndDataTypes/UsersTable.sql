
--Problem 8 - Create Table Users
CREATE TABLE Users (
	Id BIGINT UNIQUE IDENTITY NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL,
	Password VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(900),
	LastLoginTime DATE,
	IsDeleted BIT DEFAULT 0
	CONSTRAINT PK_Users PRIMARY KEY(Id)
)

INSERT INTO Users(Username, Password, ProfilePicture, LastLoginTime, IsDeleted) VALUES
('Stabri', '12345', 01011110, '2016/01/18 00:01:50', 0),
('Genadi', 'password123', 0001100, '2016/01/17 16:50:50', 0),
('Haralampi', 'mnogozdravaparola', 1111, '2016/01/17 08:45:45', 1),
('Miumiun', 'jelaqminka', 1100001, '2016/01/17 15:01:50', 0),
('Minka', 'miumiunemangal', 0110, '2016/01/17 22:23:50', 1)

--Problem 9 - Change primary key

ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (ID,Username)

--Problem 10 - Add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT CK_Users_Password CHECK (LEN(Password) >= 5)

--Problem 11 - Set default value of field
ALTER TABLE Users
ADD CONSTRAINT CK_DefaultLastLogin DEFAULT GETDATE() FOR LastLoginTime 

--Problem 12 - Set unique field
ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_Username CHECK (len(Username) >= 3)
