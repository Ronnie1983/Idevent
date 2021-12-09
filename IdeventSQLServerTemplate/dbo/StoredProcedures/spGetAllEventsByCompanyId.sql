CREATE PROCEDURE [dbo].[spGetAllEventsByCompanyId]
	@companyId int
AS
BEGIN
	SELECT Ev.Id, Ev.Name, Company.Id, Company.Name 
	FROM Events as Ev
	INNER JOIN CompanyModel as Company ON FK_CompanyId = Company.Id
	WHERE Ev.FK_CompanyId = @companyId
END
