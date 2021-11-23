CREATE PROCEDURE [dbo].[spGetAllChips]

AS
BEGIN

	SELECT Chips.[Id], [ValidFrom], [ValidTo], Companies.Id, Companies.Name, ChipGroups.Id, ChipGroups.Name, Events.Id, Events.Name
	FROM Chips
	INNER JOIN Companies ON Chips.FK_CompanyId = Companies.Id
	INNER JOIN Events ON Chips.FK_EventId = Events.Id
	INNER JOIN ChipGroups ON Chips.FK_ChipGroupId = ChipGroups.Id
END
