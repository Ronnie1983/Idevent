CREATE TABLE [dbo].[ChipContents]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [FK_StandProductId] INT NOT NULL, 
    [FK_ChipId] INT NULL, 
    [FK_ChipGroupId] INT NULL, 
    [Amount] INT NOT NULL, 
    CONSTRAINT [FK_ChipContents_ToStandProducts] FOREIGN KEY ([FK_StandProductId]) REFERENCES [StandProducts]([Id])
)
