CREATE PROCEDURE [dbo].spGetEventById
	@eventId int
AS
BEGIN
	SELECT E.Id, E.Name,
	(SELECT COUNT(Chips.Id) FROM Chips WHERE E.Id = FK_EventId) as NumberOfConnectedChips,
	Companies.Id, Companies.Name, Companies.Email, Companies.CVR, Companies.PhoneNumber
	FROM Events as E
	INNER JOIN Companies ON FK_CompanyId = Companies.Id
	WHERE E.Id = @eventId
END