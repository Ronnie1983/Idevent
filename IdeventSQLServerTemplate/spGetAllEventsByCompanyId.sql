CREATE PROCEDURE [dbo].[spGetAllEventsByCompanyId]
	@companyId int
AS
BEGIN
	SELECT Ev.Id, Ev.Name
	FROM Events as Ev
	WHERE Ev.FK_CompanyId = @companyId
END
