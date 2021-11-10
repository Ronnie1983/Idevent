CREATE TABLE [dbo].[ChipContents]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FK_EventStandId] INT NOT NULL, 
    [FK_ChipId] INT NOT NULL, 
    [Amount] INT NOT NULL
)
