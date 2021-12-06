CREATE PROCEDURE [dbo].[spGetAllChips]

AS
BEGIN

	SELECT Chips.[Id], [ValidFrom], [ValidTo], CompanyModel.Id, CompanyModel.Name, ChipGroups.Id, ChipGroups.Name, Events.Id, Events.Name
	FROM Chips
	INNER JOIN CompanyModel ON Chips.FK_CompanyId = CompanyModel.Id
	LEFT JOIN Events ON Chips.FK_EventId = Events.Id
	INNER JOIN ChipGroups ON Chips.FK_ChipGroupId = ChipGroups.Id
END
