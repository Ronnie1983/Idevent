CREATE TABLE [dbo].[Addresses] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [StreetAddress] NVARCHAR (100) NULL,
    [City]          NVARCHAR (100) NULL,
    [Country]       NVARCHAR (100) NULL,
    [PostalCode]    NVARCHAR (12)  NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([Id] ASC)
);