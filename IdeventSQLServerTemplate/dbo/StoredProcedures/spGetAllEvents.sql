CREATE PROCEDURE [dbo].[spGetAllEvents]
AS
BEGIN

	SELECT Events.Id as EventId, Events.Name, 
	(SELECT COUNT(Chips.Id) FROM Chips WHERE Events.Id = FK_EventId) as ConnectedChips,
	Companies.Id as CompanyId, CompanyName
	FROM Events
	INNER JOIN Companies ON FK_CompanyId = Companies.Id

END
