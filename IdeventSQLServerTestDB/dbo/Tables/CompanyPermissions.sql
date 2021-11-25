CREATE TABLE [dbo].[CompanyPermissions] (
    [Id]              INT NOT NULL,
    [FK_CompanyId]    INT NOT NULL,
    [FK_PermissionId] INT NOT NULL,
    [Limit]           INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

