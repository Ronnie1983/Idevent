CREATE TABLE [dbo].[AddressModel] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [StreetAddress] NVARCHAR (MAX) NULL,
    [City]          NVARCHAR (MAX) NULL,
    [Country]       NVARCHAR (MAX) NULL,
    [PostalCode]    NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AddressModel] PRIMARY KEY CLUSTERED ([Id] ASC)
);

