CREATE PROCEDURE [dbo].[spGetChipBySecretId]
	@Id nvarchar(50)
AS

BEGIN
	-- TODO: update spGetChipById with User when it done in database.
	-- SELECT is missing User info, because it is not made properly in database yet. 
	SELECT Chips.Id, [ValidFrom], [ValidTo],
	ChipGroups.Id, ChipGroups.Name,
	CompanyModel.Id, CompanyModel.Name, CompanyModel.Email, CompanyModel.PhoneNumber,
	--AspNetUsers.Email,
	Events.Id, Events.Name
	FROM Chips
	INNER JOIN CompanyModel ON Chips.FK_CompanyId = CompanyModel.Id
	INNER JOIN ChipGroups ON Chips.FK_ChipGroupId = ChipGroups.Id
	INNER JOIN Events ON Chips.FK_EventId = Events.Id
	--INNER JOIN AspNetUsers ON Chips.FK_UserId = AspNetUsers.Id
	WHERE Chips.HashedId = @Id
END