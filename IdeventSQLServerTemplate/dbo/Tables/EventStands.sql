CREATE TABLE [dbo].[EventStands]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [FK_EventId] INT NOT NULL, 
    [FK_EventStandFunctionalityId] INT NOT NULL
)
