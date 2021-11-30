CREATE PROCEDURE [dbo].spGetAllProducts
AS
BEGIN
	SELECT P.Id, P.Name, P.Value, ES.Id, ES.Name 
	FROM StandProducts AS P
	INNER JOIN EventStands AS ES ON P.FK_EventStandId = ES.Id
END