CREATE PROCEDURE [dbo].spCreateStand
	@name varchar(50),
	@eventId int,
	@functionalityId int
AS
BEGIN
	INSERT INTO EventStands VALUES (@name, @eventId, @functionalityId)
END
