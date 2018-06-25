--Problem 20 - Cancel Trip
CREATE TRIGGER tr_CancelDeleted
ON Trips
INSTEAD OF DELETE
AS
BEGIN
	UPDATE Trips
	SET CancelDate='2018-06-24'
	WHERE CancelDate IS NULL
	AND Id IN (SELECT Id
				 FROM deleted)
END

DELETE FROM Trips
WHERE Id IN (48, 49, 50)
