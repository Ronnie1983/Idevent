CREATE PROCEDURE [dbo].[spGetAllEventsByCompanyId]
	@companyId int
AS
BEGIN
	SELECT E.Id, E.Name,
	CompanyModel.Id, CompanyModel.Name, CompanyModel.Email, CompanyModel.CVR, CompanyModel.PhoneNumber
	FROM Events as E
	INNER JOIN CompanyModel ON FK_CompanyId = CompanyModel.Id
	WHERE E.FK_CompanyId = @companyId
END
