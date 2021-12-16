CREATE PROCEDURE [dbo].[spGetChipById]
	@Id int
AS

BEGIN
	-- TODO: update spGetChipById with User when it done in database.
	-- SELECT is missing User info, because it is not made properly in database yet. 
	SELECT Chips.Id, [ValidFrom], [ValidTo],
	ChipGroups.Id, ChipGroups.Name,
	Companies.Id, Companies.Name, Companies.Email, Companies.PhoneNumber,
	--AspNetUsers.Email,
	Events.Id, Events.Name
	FROM Chips
	INNER JOIN Companies ON Chips.FK_CompanyId = Companies.Id
	LEFT JOIN ChipGroups ON Chips.FK_ChipGroupId = ChipGroups.Id
	LEFT JOIN Events ON Chips.FK_EventId = Events.Id
	--LEFT JOIN AspNetUsers ON Chips.FK_UserId = AspNetUsers.Id
	WHERE Chips.Id = @Id
END

