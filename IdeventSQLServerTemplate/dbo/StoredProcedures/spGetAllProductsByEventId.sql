CREATE PROCEDURE [dbo].[spGetAllProductsByEventId]
	@eventId int
AS
BEGIN
	SELECT Products.Id, Products.Name, Products.Value
	FROM StandProducts AS Products
	INNER JOIN EventStands ON Products.FK_EventStandId = EventStands.Id
	WHERE EventStands.FK_EventId = @eventId
END
