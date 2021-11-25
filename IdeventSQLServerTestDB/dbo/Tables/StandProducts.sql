CREATE TABLE [dbo].[StandProducts] (
    [Id]              INT             NOT NULL,
    [Name]            NVARCHAR (50)   NULL,
    [Value]           DECIMAL (18, 2) NOT NULL,
    [FK_EventStandId] INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EventStandProducts_ToEventStands] FOREIGN KEY ([FK_EventStandId]) REFERENCES [dbo].[EventStands] ([Id])
);

