CREATE PROCEDURE [dbo].[spGetAllEvents]
AS
BEGIN

	SELECT Events.Id, Events.Name, 
	(SELECT COUNT(Chips.Id) FROM Chips WHERE Events.Id = FK_EventId) as NumberOfConnectedChips,
	Companies.Id, Companies.Name
	FROM Events
	INNER JOIN Companies ON FK_CompanyId = Companies.Id

END
