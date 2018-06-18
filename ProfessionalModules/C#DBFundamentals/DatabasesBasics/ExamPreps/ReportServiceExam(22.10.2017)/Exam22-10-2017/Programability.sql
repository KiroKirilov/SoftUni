--Problem 17 - Employee’s Load
CREATE FUNCTION udf_GetReportsCount(@employeeId INT, @statusId INT)
RETURNS INT
AS
BEGIN
    DECLARE @count INT=
	(
		SELECT COUNT(*)
		FROM Reports r
		WHERE r.EmployeeId=@employeeId
		AND r.StatusId=@statusId
	)

	RETURN @count
END

GO
--Problem 18 - Assign Employee
CREATE PROCEDURE usp_AssignEmployeeToReport(@employeeId INT, @reportId INT)
AS
BEGIN 
	BEGIN TRANSACTION
		DECLARE @employeeDepartment INT = (SELECT DepartmentId
		                                   FROM Employees
									       WHERE Id=@employeeId)

		DECLARE @category INT = (SELECT CategoryId
		                         FROM Reports
								 WHERE Id=@reportId)
		
		DECLARE @categoryDepartment INT = (SELECT DepartmentId
										   FROM Categories
										   WHERE Id=@category)

		
		UPDATE Reports
		SET EmployeeId=@employeeId
		WHERE Id=@reportId

		IF (@employeeId IS NOT NULL
		    AND @categoryDepartment<>@employeeDepartment)
		BEGIN
			ROLLBACK;
			THROW 50013,'Employee doesn''t belong to the appropriate department!', 1;
		END

		COMMIT
END

GO
--Problem 19 - Close Reports
CREATE TRIGGER UpdateStatus
ON Reports
AFTER UPDATE
AS
BEGIN
	UPDATE Reports
	SET StatusId=3
	WHERE Id IN 
	(
		SELECT Id
		FROM inserted
		WHERE Id IN
			(SELECT Id 
			FROM deleted
			WHERE CloseDate IS NULL)
		AND CloseDate IS NOT NULL
	)
END


