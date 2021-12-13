CREATE PROCEDURE [dbo].[spGetStandFunctionalityById]
	@Id int

AS
BEGIN
	SELECT SF.Id, SF.Name 
	FROM StandFunctionalities SF
	WHERE SF.Id = @Id
END
