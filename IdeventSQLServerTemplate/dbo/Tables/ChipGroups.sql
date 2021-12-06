CREATE TABLE [dbo].[ChipGroups]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [FK_EventId] INT NOT NULL, 
    CONSTRAINT [FK_ChipGroups_Events] FOREIGN KEY (FK_EventId) REFERENCES Events(Id)
)
