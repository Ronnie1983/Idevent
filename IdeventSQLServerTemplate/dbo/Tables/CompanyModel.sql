CREATE TABLE [dbo].[CompanyModel] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (50)  NOT NULL,
    [Logo]             NVARCHAR (255) NULL,
    [CVR]              NVARCHAR (8)   NOT NULL,
    [Email]            NVARCHAR (254) NOT NULL,
    [PhoneNumber]      NVARCHAR (30)  NOT NULL,
    [Active]           BIT            NOT NULL,
    [Note]             NVARCHAR (255) DEFAULT ('') NOT NULL,
    [AddressId]        INT            NULL,
    [InvoiceAddressId] INT            NULL,
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

