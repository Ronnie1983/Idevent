CREATE PROCEDURE [dbo].spGetAllEventStands
AS
BEGIN
	SELECT E.Id, E.Name, A.Id, A.Name, S.Id, S.Name
	FROM EventStands AS E
	INNER JOIN Events AS A ON E.FK_EventId = A.Id
	INNER JOIN StandFunctionalities AS S ON E.FK_StandFunctionalityId = s.Id
END