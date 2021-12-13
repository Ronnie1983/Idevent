CREATE PROCEDURE [dbo].[spCreateStandFunctionality]
	@Name NVARCHAR(50)
AS
BEGIN
	INSERT INTO StandFunctionalities
	OUTPUT inserted.Id
	VALUES(@Name)
END
