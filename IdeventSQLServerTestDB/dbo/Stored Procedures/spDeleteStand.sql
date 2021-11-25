CREATE PROCEDURE [dbo].[spDeleteStand]
	@standId int
	
AS
BEGIN
	DELETE EventStands
	WHERE EventStands.Id = @standId
END