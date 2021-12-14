CREATE PROCEDURE [dbo].[spGetChipContentByChipId]
	@ChipId int
AS
BEGIN
	SELECT ChipContents.Id, StandProducts.Name, StandProducts.Value, ChipContents.Amount , StandProducts.Id
	FROM ChipContents
	INNER JOIN StandProducts ON ChipContents.FK_StandProductId = StandProducts.Id
	WHERE ChipContents.FK_ChipId = @ChipId
END
