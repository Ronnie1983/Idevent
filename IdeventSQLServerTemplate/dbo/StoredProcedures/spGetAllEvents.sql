CREATE PROCEDURE [dbo].[spGetAllEvents]
AS
BEGIN

	SELECT Events.Id, Events.Name, 
	(SELECT COUNT(Chips.Id) FROM Chips WHERE Events.Id = FK_EventId) as NumberOfConnectedChips,
	CompanyModel.Id, CompanyModel.Name
	FROM Events
	INNER JOIN CompanyModel ON FK_CompanyId = CompanyModel.Id

END
