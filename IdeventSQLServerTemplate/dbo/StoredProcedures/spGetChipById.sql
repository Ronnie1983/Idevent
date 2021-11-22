CREATE PROCEDURE [dbo].[spGetChipById]
	@Id int
AS

BEGIN
	-- TODO: update spGetChipById with User when it done in database.
	-- SELECT is missing User info, because it is not made properly in database yet. 
	SELECT Chips.Id, [ValidFrom], [ValidTo],
	ChipGroups.Id, ChipGroups.Name as ChipGroupName,
	Companies.Id,Companies.Name as CompanyName, Companies.Email,
	--AspNetUsers.Email,
	Events.Id, Events.Name as EventName
	FROM Chips
	INNER JOIN Companies ON Chips.FK_CompanyId = Companies.Id
	INNER JOIN ChipGroups ON Chips.FK_ChipGroupId = ChipGroups.Id
	INNER JOIN Events ON Chips.FK_EventId = Events.Id
	--INNER JOIN AspNetUsers ON Chips.FK_UserId = AspNetUsers.Id
	WHERE Chips.Id = @Id

	SELECT * FROM ChipContents
END

