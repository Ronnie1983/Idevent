CREATE PROCEDURE [dbo].[spGetAllEventsByCompanyId]
	@companyId int
AS
BEGIN
	SELECT E.Id, E.Name,
	Companies.Id, Companies.Name, Companies.Email, Companies.CVR, Companies.PhoneNumber
	FROM Events as E
	INNER JOIN Companies ON FK_CompanyId = Companies.Id
	WHERE E.FK_CompanyId = @companyId
END
