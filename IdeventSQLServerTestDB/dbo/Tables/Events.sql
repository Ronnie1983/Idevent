CREATE TABLE [dbo].[Events] (
    [Id]           INT           NOT NULL,
    [Name]         NVARCHAR (50) NOT NULL,
    [FK_CompanyId] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Events_ToCompanies] FOREIGN KEY ([FK_CompanyId]) REFERENCES [dbo].[Companies] ([Id])
);

