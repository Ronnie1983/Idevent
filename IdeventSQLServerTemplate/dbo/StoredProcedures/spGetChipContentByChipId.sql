CREATE PROCEDURE [dbo].[spGetChipContentByChipId]
	@ChipId int
AS
BEGIN
	SELECT StandProducts.Id, StandProducts.Name, StandProducts.Value, ChipContents.Amount , EventStands.Id
	FROM ChipContents
	INNER JOIN StandProducts ON ChipContents.FK_StandProductId = StandProducts.Id
	INNER JOIN EventStands ON StandProducts.FK_EventStandId = EventStands.Id
	WHERE ChipContents.FK_ChipId = @ChipId
END
