CREATE PROCEDURE [dbo].spGetAllFunctions
AS
BEGIN
SELECT S.Id, S.Name FROM StandFunctionalities AS S
END