CREATE PROCEDURE [dbo].[spCreateChipContent]
	@ProductId int,
	@ChipId int,
	@GroupId int,
	@Amount int
AS
BEGIN
	INSERT INTO ChipContents
	VALUES(@ProductId, @ChipId, @GroupId, @Amount)
END