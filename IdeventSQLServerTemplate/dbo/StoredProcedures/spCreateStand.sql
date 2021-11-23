CREATE PROCEDURE [dbo].spCreateStand
	@name varchar(50),
	@eventId int,
	@funktionalityId int
AS
BEGIN
	INSERT INTO EventStands VALUES (@name, @eventId, @funktionalityId)
END