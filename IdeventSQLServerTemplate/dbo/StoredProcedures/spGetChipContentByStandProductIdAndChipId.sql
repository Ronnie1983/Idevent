CREATE PROCEDURE [dbo].spGetChipContentByStandProductIdAndChipId
	@standProductId int,
	@chipId int
AS
BEGIN
	SELECT * 
	FROM ChipContents AS CC
	WHERE CC.FK_ChipId = @chipId AND CC.FK_StandProductId = @standProductId
END
