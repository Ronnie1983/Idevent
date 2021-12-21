CREATE PROCEDURE [dbo].[spGetStandProductAndContentByChipId]
	@ChipId int,
	@StandId int
AS
BEGIN
	SELECT ChipContents.Id, StandProducts.Name, StandProducts.Value, ChipContents.Amount , StandProducts.FK_EventStandId AS EventStandId
	FROM ChipContents
	LEFT JOIN StandProducts ON ChipContents.FK_StandProductId = StandProducts.Id
	WHERE (ChipContents.FK_ChipId IS NULL OR ChipContents.FK_ChipId = @ChipId) AND StandProducts.FK_EventStandId = @StandId
END