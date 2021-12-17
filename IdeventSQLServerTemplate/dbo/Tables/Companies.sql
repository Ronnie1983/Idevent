CREATE TABLE [dbo].[Companies] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (100) NOT NULL,
    [Email]            NVARCHAR (255) NOT NULL,
    [InvoiceAddressId] INT            NULL,
    [AddressId]        INT            NULL,
    [CVR]              NVARCHAR (8)   NOT NULL,
    [PhoneNumber]      NVARCHAR (30)  NOT NULL,
    [Note]             NVARCHAR (MAX) NULL,
    [Active]           BIT            NOT NULL,
    [Logo]             NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Companies_Addresses_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([Id]),
    CONSTRAINT [FK_Companies_Addresses_InvoiceAddressId] FOREIGN KEY ([InvoiceAddressId]) REFERENCES [dbo].[Addresses] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Companies_AddressId]
    ON [dbo].[Companies]([AddressId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Companies_InvoiceAddressId]
    ON [dbo].[Companies]([InvoiceAddressId] ASC);

