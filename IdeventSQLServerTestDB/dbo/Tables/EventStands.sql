CREATE TABLE [dbo].[EventStands] (
    [Id]                      INT           NOT NULL,
    [Name]                    NVARCHAR (50) NOT NULL,
    [FK_EventId]              INT           NOT NULL,
    [FK_StandFunctionalityId] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EventStands_ToEvents] FOREIGN KEY ([FK_EventId]) REFERENCES [dbo].[Events] ([Id]),
    CONSTRAINT [FK_EventStands_ToStandFunctionalities] FOREIGN KEY ([FK_StandFunctionalityId]) REFERENCES [dbo].[StandFunctionalities] ([Id])
);

