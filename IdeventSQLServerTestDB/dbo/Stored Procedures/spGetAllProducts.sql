CREATE PROCEDURE [dbo].spGetAllProducts
AS
BEGIN
	SELECT P.Id, P.Name, P.Value, S.Id, S.Name FROM StandProducts AS P
	INNER JOIN EventStands AS S ON P.FK_EventStandId = S.FK_EventId
END