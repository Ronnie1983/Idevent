CREATE TABLE [dbo].[Chips]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [HashedId] NVARCHAR(50) NOT NULL, 
    [ValidFrom] DATETIMEOFFSET NOT NULL, 
    [ValidTo] DATETIMEOFFSET NOT NULL, 
    [FK_ChipGroupId] INT NOT NULL, 
    [FK_UserId] INT NULL, 
    [FK_CompanyId] INT NOT NULL, 
    [FK_EventId] INT NULL
    CONSTRAINT [FK_Chips_ToCompanies] FOREIGN KEY (FK_CompanyId) REFERENCES [Companies]([Id]),
    CONSTRAINT [FK_Chips_ToEvents] FOREIGN KEY (FK_EventId) REFERENCES [Events]([Id]),
    CONSTRAINT [FK_Chips_ToChipGroups] FOREIGN KEY (FK_ChipGroupId) REFERENCES [ChipGroups]([Id])
)
