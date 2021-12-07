CREATE PROCEDURE [dbo].[spGetUserById]
	@userId NVARCHAR(450)
AS
BEGIN

	SELECT U.Email
	FROM AspNetUsers AS U
	WHERE U.Id = @userId

END