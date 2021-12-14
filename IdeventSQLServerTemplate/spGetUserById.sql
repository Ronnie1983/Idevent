CREATE PROCEDURE [dbo].[spGetUserById]
	@userId NVARCHAR(256)
AS
BEGIN

	SELECT U.Id, U.Email
	FROM AspNetUsers AS U
	WHERE  U.Id = @userId
END