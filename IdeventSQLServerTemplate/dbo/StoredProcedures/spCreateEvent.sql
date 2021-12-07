CREATE PROCEDURE [dbo].[spCreateEvent]
	@Name int,
	@CompanyId int
AS
BEGIN
	INSERT INTO Events(Name, FK_CompanyId)
	OUTPUT inserted.Id
	VALUES(@Name, @CompanyId)
END
