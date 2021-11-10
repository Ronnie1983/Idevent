CREATE TABLE [dbo].[EventStands]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [FK_EventId] INT NOT NULL, 
    [FK_StandFunctionalityId] INT NOT NULL, 
    CONSTRAINT [FK_EventStands_ToEvents] FOREIGN KEY (FK_EventId) REFERENCES [Events]([Id]),
    CONSTRAINT [FK_EventStands_ToStandFunctionalities] FOREIGN KEY (FK_StandFunctionalityId) REFERENCES [StandFunctionalities]([Id])
)
