CREATE PROCEDURE [dbo].spDeleteUserById
	@userId NVARCHAR(max)
AS
BEGIN
	DELETE FROM AspNetUsers
	WHERE AspNetUsers.Id = @userId
END