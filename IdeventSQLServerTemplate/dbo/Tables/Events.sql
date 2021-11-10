CREATE TABLE [dbo].[Events]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [FK_CompanyId] INT NOT NULL, 
    CONSTRAINT [FK_Events_ToCompanies] FOREIGN KEY ([FK_CompanyId]) REFERENCES [Companies]([Id])
)
