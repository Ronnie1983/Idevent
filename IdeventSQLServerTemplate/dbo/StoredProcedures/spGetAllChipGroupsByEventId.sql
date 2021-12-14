CREATE PROCEDURE [dbo].[spGetAllChipGroupsByEventId]
	@eventId int
AS
BEGIN
	SELECT [Id], [Name], [FK_EventId]
	FROM ChipGroups
	WHERE ChipGroups.FK_EventId = @eventId
END
