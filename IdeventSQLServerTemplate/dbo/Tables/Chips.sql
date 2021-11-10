CREATE TABLE [dbo].[Chips]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [HashedId] NVARCHAR(50) NOT NULL, 
    [ValidFrom] DATETIMEOFFSET NOT NULL, 
    [ValidTo] DATETIMEOFFSET NOT NULL, 
    [FK_ChipGroupId] INT NOT NULL, 
    [FK_UserId] INT NULL, 
    [FK_CompanyId] INT NOT NULL, 
    [FK_EventId] INT NULL
)
