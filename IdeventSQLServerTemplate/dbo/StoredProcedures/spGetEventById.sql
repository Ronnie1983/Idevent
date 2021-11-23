CREATE PROCEDURE [dbo].spGetEventById
	@param1 int
AS
BEGIN
	SELECT E.Id, E.Name,
	(SELECT COUNT(Chips.Id) FROM Chips WHERE E.Id = FK_EventId) as NumberOfConnectedChips,
	Companies.Id, Companies.Name
	FROM Events as E
	INNER JOIN Companies ON FK_CompanyId = Companies.Id
	WHERE E.Id = @param1
END