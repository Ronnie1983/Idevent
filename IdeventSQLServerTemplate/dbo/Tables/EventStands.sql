CREATE TABLE [dbo].[EventStands]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [FK_EventId] INT NOT NULL, 
    [FK_EventStandFunctionalityId] INT NOT NULL
)
