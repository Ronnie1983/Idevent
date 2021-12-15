CREATE PROCEDURE [dbo].spGetProductsByStandId
	@standId int
AS
BEGIN
	SELECT P.Id, P.Name, P.Value, P.FK_EventStandId AS Id 
	FROM StandProducts AS P
	WHERE P.FK_EventStandId = @standId
END