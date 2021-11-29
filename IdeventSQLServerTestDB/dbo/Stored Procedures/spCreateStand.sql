CREATE PROCEDURE [dbo].spCreateStand
	@name varchar(50),
	@eventId int,
	@functionalityId int
AS
BEGIN
	INSERT INTO EventStands 
	OUTPUT inserted.Id
	VALUES (6, @name, @eventId, @functionalityId) -- 6 default id for testing.
END