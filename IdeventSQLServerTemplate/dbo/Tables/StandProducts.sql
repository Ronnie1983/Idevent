CREATE TABLE [dbo].[StandProducts]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] NVARCHAR(50) NULL, 
    [Value] DECIMAL(18, 2) NOT NULL, 
    [FK_EventStandId] INT NOT NULL, 
    CONSTRAINT [FK_EventStandProducts_ToEventStands] FOREIGN KEY ([FK_EventStandId]) REFERENCES [EventStands]([Id])
)
