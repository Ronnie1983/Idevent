CREATE PROCEDURE [dbo].[spCreateChip]
	@HashedId nvarchar(50),
	@ValidFrom DateTimeOffSet,
	@ValidTo DateTimeOffSet,
	@FK_CompanyId int,
	@FK_EventId int = null,
	@FK_ChipGroupId int = 1,
	@FK_UserId int = null
AS
BEGIN
	INSERT INTO Chips(HashedId, ValidFrom, ValidTo, FK_CompanyId, FK_EventId, FK_ChipGroupId, FK_UserId)
	OUTPUT inserted.Id
	VALUES(@HashedId, @ValidFrom, @ValidTo, @FK_CompanyId, @FK_EventId, @FK_ChipGroupId, @FK_UserId)
END
