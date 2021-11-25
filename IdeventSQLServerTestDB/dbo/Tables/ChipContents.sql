CREATE TABLE [dbo].[ChipContents] (
    [Id]                INT NOT NULL,
    [FK_StandProductId] INT NOT NULL,
    [FK_ChipId]         INT NULL,
    [FK_ChipGroupId]    INT NULL,
    [Amount]            INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ChipContents_ToStandProducts] FOREIGN KEY ([FK_StandProductId]) REFERENCES [dbo].[StandProducts] ([Id])
);

