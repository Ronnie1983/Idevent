CREATE PROCEDURE [dbo].spCreateStand
	@id int,
	@name varchar(50),
	@eventId int,
	@functionalityId int
AS
BEGIN
	INSERT INTO EventStands 
	OUTPUT inserted.Id
	VALUES (@id, @name, @eventId, @functionalityId)
END