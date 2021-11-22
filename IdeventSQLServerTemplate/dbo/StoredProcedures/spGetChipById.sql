CREATE PROCEDURE [dbo].[spGetChipById]
	@Id int
AS

BEGIN
	-- SELECT is missing User info, because it is not made properly in database yet.
	SELECT Chips.Id, [ValidFrom], [ValidTo], ChipGroups.Name as ChipGroupName, Companies.Name as CompanyName, Companies.Email, Events.Name as EventName 
	FROM Chips
	INNER JOIN Companies ON Chips.FK_CompanyId = Companies.Id
	INNER JOIN ChipGroups ON Chips.FK_ChipGroupId = ChipGroups.Id
	INNER JOIN Events ON Chips.FK_EventId = Events.Id
	WHERE Chips.Id = @Id
END

