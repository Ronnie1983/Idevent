CREATE PROCEDURE [dbo].spGetProductsByStandId
	@standId int
AS
BEGIN
	SELECT P.Id, P.Name, P.Value 
	FROM StandProducts AS P
	WHERE P.FK_EventStandId = @standId
END