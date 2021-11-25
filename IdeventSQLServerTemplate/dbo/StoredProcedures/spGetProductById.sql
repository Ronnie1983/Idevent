CREATE PROCEDURE [dbo].[spGetProductById]
	@id int
AS
BEGIN
	SELECT S.Id, S.Name, S.Value 
	FROM StandProducts AS S
	WHERE S.Id = @id
END
