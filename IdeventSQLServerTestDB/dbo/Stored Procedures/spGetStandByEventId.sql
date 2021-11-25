CREATE PROCEDURE [dbo].spGetStandByEventId
	@eventId int
	AS
BEGIN
	SELECT E.Id, E.Name, Events.Id, Events.Name, S.Id, S.Name
	FROM EventStands AS E
	INNER JOIN Events ON E.FK_EventId = Events.Id
	INNER JOIN StandFunctionalities AS S ON E.FK_StandFunctionalityId = S.Id
	WHERE E.FK_EventId = @eventId
	
END