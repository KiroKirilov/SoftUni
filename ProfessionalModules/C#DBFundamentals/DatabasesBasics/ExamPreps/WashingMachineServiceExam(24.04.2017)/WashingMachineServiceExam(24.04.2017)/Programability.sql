--Problem 17 - Cost of Order
CREATE FUNCTION udf_GetCost (@jobId INT)
RETURNS DECIMAL(15,2)
AS
BEGIN
	DECLARE @totalPrice DECIMAL(15,2)=(SELECT ISNULL(SUM(op.Quantity*p.Price),0)
										 FROM Orders o
										  JOIN Jobs j
										    ON j.JobId=o.JobId
										  JOIN OrderParts op
										    ON op.OrderId=o.OrderId
										  JOIN Parts p
										    ON p.PartId=op.PartId
										 WHERE j.JobId=@jobId)

    RETURN @totalPrice
END

GO
--Problem 18 - Place Order
CREATE PROCEDURE usp_PlaceOrder(@jobId INT, @serialNumberPart VARCHAR(20), @quantity INT)
AS
BEGIN
	IF(@quantity<=0)
	BEGIN
        RAISERROR ('Part quantity must be more than zero!', 16, 1)
        RETURN;
	END	

	DECLARE @jobIdSelected INT= (
		SELECT  JobId
		FROM Jobs
		WHERE JobId=@jobId
	)

	IF(@jobIdSelected IS NULL)
	BEGIN
		RAISERROR ('Job not found!', 16, 1)
	END

	DECLARE @JobStatus VARCHAR(50) = (
      SELECT Status
      FROM Jobs
      WHERE JobId = @jobId
    )

    IF (@JobStatus = 'Finished')
      BEGIN
        RAISERROR ('This job is not active!', 16, 1)
	END

	DECLARE @PartId INT = (
      SELECT PartId
      FROM Parts
      WHERE SerialNumber = @serialNumberPart
    )

    IF (@PartId IS NULL)
      BEGIN
        RAISERROR ('Part not found!', 16, 1)
	END

	DECLARE @OrderId INT = (
      SELECT o.OrderId
      FROM Orders AS o
        JOIN OrderParts part
          ON o.OrderId = part.OrderId
        JOIN Parts p
          ON part.PartId = p.PartId
      WHERE o.JobId = @jobId AND p.PartId = @PartId AND o.IssueDate IS NULL
	)

	IF (@OrderId IS NULL)
      BEGIN
        INSERT INTO Orders (JobId, IssueDate) VALUES
          (@jobId, NULL)

        INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES
          (IDENT_CURRENT('Orders'), @PartId, @quantity)
      END
    ELSE
      BEGIN
        DECLARE @PartExistanceOrder INT = (
          SELECT @@ROWCOUNT
          FROM OrderParts
          WHERE OrderId = @OrderId AND PartId = @PartId
        )

        IF (@PartExistanceOrder IS NULL)
          BEGIN
            INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES
              (@OrderId, @PartId, @quantity)
          END
        ELSE
          BEGIN
            UPDATE OrderParts
            SET Quantity += @quantity
            WHERE OrderId = @OrderId AND PartId = @PartId
          END
	END
END

GO
--Problem 19 - Detect Delivery
CREATE TRIGGER tr_UpdateStock
ON Orders
AFTER UPDATE
AS
BEGIN
	DECLARE @oldStatus INT=(SELECT Delivered FROM deleted)
	DECLARE @newStatus INT=(SELECT Delivered FROM inserted)

	IF(@oldStatus<>@newStatus)
	BEGIN
		UPDATE Parts
		SET StockQty += op.Quantity
		FROM Parts p
		JOIN OrderParts op
		ON op.PartId=p.PartId
		JOIN Orders o
		ON o.OrderId=op.OrderId
		JOIN inserted i 
		ON i.OrderId=o.OrderId
		JOIN deleted d
		ON d.OrderId=o.OrderId
	END
END
