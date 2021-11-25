CREATE PROCEDURE [dbo].spGetAllFunctionsForEvent
	@eventId int
AS
BEGIN
	SELECT S.Name FROM StandFunctionalities AS S
	INNER JOIN EventStands AS E ON E.FK_StandFunctionalityId = S.Id
	WHERE E.FK_EventId = @eventId
	GROUP BY S.Name
END