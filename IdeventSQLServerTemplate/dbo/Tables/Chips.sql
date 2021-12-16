CREATE TABLE [dbo].[Chips] (
    [Id]             INT                IDENTITY (1, 1) NOT NULL,
    [HashedId]       NVARCHAR (50)      NOT NULL,
    [ValidFrom]      DATETIMEOFFSET (7) NOT NULL,
    [ValidTo]        DATETIMEOFFSET (7) NOT NULL,
    [FK_ChipGroupId] INT                NULL,
    [FK_UserId]      NVARCHAR (50)      NULL,
    [FK_CompanyId]   INT                NOT NULL,
    [FK_EventId]     INT                NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Chips_ToChipGroups] FOREIGN KEY ([FK_ChipGroupId]) REFERENCES [dbo].[ChipGroups] ([Id]),
    CONSTRAINT [FK_Chips_ToCompanies] FOREIGN KEY ([FK_CompanyId]) REFERENCES [dbo].[Companies] ([Id]),
    CONSTRAINT [FK_Chips_ToEvents] FOREIGN KEY ([FK_EventId]) REFERENCES [dbo].[Events] ([Id])
);


