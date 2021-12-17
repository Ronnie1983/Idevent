CREATE PROCEDURE [dbo].spUpdateChipContent
	@standProductId int,
	@chipId int,
	@amounts int
AS
BEGIN
	UPDATE ChipContents SET Amount = Amount + @amounts
	WHERE FK_StandProductId = @standProductId AND FK_ChipId = @chipId
END