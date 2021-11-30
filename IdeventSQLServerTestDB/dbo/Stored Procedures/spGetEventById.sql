CREATE PROCEDURE [dbo].spGetEventById
	@param1 int
AS
BEGIN
	SELECT E.Id, E.Name,
	(SELECT COUNT(Chips.Id) FROM Chips WHERE E.Id = FK_EventId) as NumberOfConnectedChips,
	CompanyModel.Id, CompanyModel.Name
	FROM Events as E
	INNER JOIN CompanyModel ON FK_CompanyId = CompanyModel.Id
	WHERE E.Id = @param1
END