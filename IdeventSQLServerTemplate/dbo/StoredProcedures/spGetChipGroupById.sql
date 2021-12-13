CREATE PROCEDURE [dbo].[spGetChipGroupById]
	@chipGroupId int
AS
BEGIN
	SELECT Id, Name, FK_EventId
	FROM ChipGroups
	WHERE ChipGroups.Id = @chipGroupId
END