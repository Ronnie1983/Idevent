CREATE PROCEDURE [dbo].[spUpdateUserRole]
	@roleName NVARCHAR(256),
	@userId NVARCHAR(450)
AS
BEGIN
	UPDATE AspNetUserRoles 
	SET AspNetUserRoles.RoleId = (SELECT AspNetRoles.Id FROM AspNetRoles WHERE AspNetRoles.Name = @roleName)
	WHERE AspNetUserRoles.UserId = @userId
END
