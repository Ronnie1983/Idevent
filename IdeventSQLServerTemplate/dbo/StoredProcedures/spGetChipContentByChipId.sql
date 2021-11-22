CREATE PROCEDURE [dbo].[spGetChipContentByChipId]
	@ChipId int
AS
BEGIN
	SELECT StandProducts.Name, ChipContents.Amount 
	FROM ChipContents
	INNER JOIN StandProducts ON ChipContents.FK_StandProductId = StandProducts.Id
	WHERE ChipContents.FK_ChipId = @ChipId
END
