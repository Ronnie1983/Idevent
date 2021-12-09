CREATE PROCEDURE [dbo].spGetEventById
	@eventId int
AS
BEGIN
	SELECT E.Id, E.Name,
	(SELECT COUNT(Chips.Id) FROM Chips WHERE E.Id = FK_EventId) as NumberOfConnectedChips,
	CompanyModel.Id, CompanyModel.Name, CompanyModel.Email, CompanyModel.CVR, CompanyModel.PhoneNumber
	FROM Events as E
	INNER JOIN CompanyModel ON FK_CompanyId = CompanyModel.Id
	WHERE E.Id = @eventId
END