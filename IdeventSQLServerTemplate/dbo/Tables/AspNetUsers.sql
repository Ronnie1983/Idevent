CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (450)     NOT NULL,
    [UserName]             NVARCHAR (256)     NULL,
    [NormalizedUserName]   NVARCHAR (256)     NULL,
    [Email]                NVARCHAR (256)     NULL,
    [NormalizedEmail]      NVARCHAR (256)     NULL,
    [EmailConfirmed]       BIT                NOT NULL,
    [PasswordHash]         NVARCHAR (MAX)     NULL,
    [SecurityStamp]        NVARCHAR (MAX)     NULL,
    [ConcurrencyStamp]     NVARCHAR (MAX)     NULL,
    [PhoneNumber]          NVARCHAR (MAX)     NULL,
    [PhoneNumberConfirmed] BIT                NOT NULL,
    [TwoFactorEnabled]     BIT                NOT NULL,
    [LockoutEnd]           DATETIMEOFFSET (7) NULL,
    [LockoutEnabled]       BIT                NOT NULL,
    [AccessFailedCount]    INT                NOT NULL,
    [AddressId]            INT                NULL,
    [CompanyId]            INT                NULL,
    [InvoiceAddressId]     INT                NULL,
    [Role]                 NVARCHAR (MAX)     NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AspNetUsers_AddressModel_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [dbo].Addresses ([Id]),
    CONSTRAINT [FK_AspNetUsers_AddressModel_InvoiceAddressId] FOREIGN KEY ([InvoiceAddressId]) REFERENCES [dbo].[Addresses] ([Id]),
    CONSTRAINT [FK_AspNetUsers_CompanyModel_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [EmailIndex]
    ON [dbo].[AspNetUsers]([NormalizedEmail] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[AspNetUsers]([NormalizedUserName] ASC) WHERE ([NormalizedUserName] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_InvoiceAddressId]
    ON [dbo].[AspNetUsers]([InvoiceAddressId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_CompanyId]
    ON [dbo].[AspNetUsers]([CompanyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_AddressId]
    ON [dbo].[AspNetUsers]([AddressId] ASC);

