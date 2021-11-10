CREATE TABLE [dbo].[CompanyPermissions]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [FK_CompanyId] INT NOT NULL, 
    [FK_PermissionId] INT NOT NULL, 
    [Limit] INT NULL

)
