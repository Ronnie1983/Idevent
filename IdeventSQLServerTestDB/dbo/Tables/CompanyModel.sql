CREATE TABLE [dbo].[CompanyModel] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (MAX) NOT NULL,
    [Email]            NVARCHAR (MAX) NOT NULL,
    [InvoiceAddressId] INT            NULL,
    [AddressId]        INT            NULL,
    [CVR]              NVARCHAR (MAX) NOT NULL,
    [PhoneNumber]      NVARCHAR (MAX) NOT NULL,
    [Note]             NVARCHAR (MAX) NULL,
    [Active]           BIT            NOT NULL,
    [Logo]             NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_CompanyModel] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CompanyModel_AddressModel_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[AddressModel] ([Id]),
    CONSTRAINT [FK_CompanyModel_AddressModel_InvoiceAddressId] FOREIGN KEY ([InvoiceAddressId]) REFERENCES [dbo].[AddressModel] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyModel_InvoiceAddressId]
    ON [dbo].[CompanyModel]([InvoiceAddressId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyModel_AddressId]
    ON [dbo].[CompanyModel]([AddressId] ASC);

