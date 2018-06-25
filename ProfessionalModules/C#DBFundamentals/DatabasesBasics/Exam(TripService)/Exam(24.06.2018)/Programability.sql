--Problem 18 - Available Room
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @roomId INT =(SELECT TOP 1 r.Id
						  FROM Rooms r
						  JOIN Trips t
						  ON t.RoomId=r.Id
						  WHERE t.CancelDate IS NULL
						  AND @Date NOT BETWEEN t.ArrivalDate AND t.CancelDate
						  AND r.HotelId=@HotelId
						  AND r.Beds>@People
						  ORDER BY r.Price DESC)

	IF (@roomId IS NULL)
	BEGIN
		RETURN 'No rooms available'
	END

	DECLARE @roomType NVARCHAR(100)=(SELECT Type FROM Rooms WHERE Id=@roomId)
	DECLARE @beds INT = (SELECT Beds FROM Rooms WHERE Id=@roomId)
	DECLARE @roomRate DECIMAL(15,2)=(SELECT Price FROM Rooms WHERE Id=@roomId)
	DECLARE @hotelRate DECIMAL(15,2)=(SELECT h.BaseRate
									  FROM Rooms r
									  JOIN Hotels h
									  ON h.Id=r.HotelId
									  WHERE r.Id=@roomId)

	DECLARE @totalPrice DECIMAL(15,2) = (@hotelRate+@roomRate)*@People

	RETURN CONCAT('Room ',@roomId,': ',@roomType, ' (',@beds,' beds) - $',@totalPrice)
END

GO

--Problem 19 - Switch Room
CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN
	DECLARE @tripPeopleCount INT = (SELECT COUNT(*)
								    FROM AccountsTrips
								    WHERE TripId=@TripId)

	DECLARE @currentHotelId INT = (SELECT HotelId
								   FROM Rooms
								   WHERE Id=@TripId)

	DECLARE @targetHotelId INT = (SELECT HotelId
								  FROM Rooms
								  WHERE Id=@TargetRoomId)

	IF(@currentHotelId<>@targetHotelId)
	BEGIN
		RAISERROR('Target room is in another hotel!',16,1)
		RETURN
	END

	DECLARE @targetBeds INT = (SELECT Beds
							   FROM Rooms
							   WHERE Id=@TargetRoomId)

	IF(@tripPeopleCount>@targetBeds)
	BEGIN
		RAISERROR('Not enough beds in target room!',16,2)
		RETURN
	END

	UPDATE Trips
	SET RoomId=@TargetRoomId
	WHERE Id=@TripId
END

