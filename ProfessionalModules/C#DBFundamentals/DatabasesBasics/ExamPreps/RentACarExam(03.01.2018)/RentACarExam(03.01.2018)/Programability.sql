--Problem 17 - Find My Ride
CREATE FUNCTION udf_CheckForVehicle(@townName NVARCHAR(50), @seatsNumber INT)
RETURNS NVARCHAR(100)
AS
BEGIN
	DECLARE @Output NVARCHAR(100) = (SELECT TOP 1
	                                     o.Name+' - '+m.Model AS [Result]
	                                FROM Vehicles v
									JOIN Models m
									ON m.Id=v.ModelId
									JOIN Offices o
									ON o.Id=v.OfficeId
									JOIN Towns t
									ON t.Id=o.TownId
									WHERE t.Name=@townName
									AND m.Seats=@seatsNumber
									ORDER BY o.Name ASC)
	IF (@Output='')
	BEGIN
		SET @Output='NO SUCH VEHICLE FOUND'
	END
    
    IF (@Output IS NULL)
	BEGIN
		SET @Output='NO SUCH VEHICLE FOUND'
	END

	RETURN @Output
END

GO

--Problem 18 - Move a Vehicle
CREATE PROCEDURE usp_MoveVehicle(@vehicleId INT, @officeId INT)
AS
  BEGIN
    BEGIN TRANSACTION
    DECLARE @officePlaces INT = (
      SELECT ParkingPlaces
      FROM Offices
      WHERE Id = @officeId
    )

    DECLARE @currentPlaces INT = (
      SELECT count(v.OfficeId)
      FROM Vehicles v
        JOIN Offices o
          ON v.OfficeId = o.Id
      WHERE o.Id = @officeId
      GROUP BY o.Name
    )

    IF (@officePlaces IS NULL OR @currentPlaces IS NULL OR @currentPlaces >= @officePlaces)
      BEGIN
        ROLLBACK;
        RAISERROR ('Not enough room in this office!', 16, 1);
      END

    UPDATE Vehicles
    SET OfficeId = @officeId
    WHERE Id = @vehicleId

    COMMIT;
END

GO

--Problem 19 - Move the Tally
CREATE TRIGGER UpdateMileage
ON Orders
AFTER UPDATE
AS
BEGIN
	DECLARE @mileageToAdd INT=(SELECT TOP 1 TotalMileage FROM inserted)
	DECLARE @vehicleId INT=(SELECT TOP 1 VehicleId FROM inserted)
    UPDATE Vehicles
	SET Mileage += @mileageToAdd
	WHERE Id = @vehicleId
	RETURN
END
