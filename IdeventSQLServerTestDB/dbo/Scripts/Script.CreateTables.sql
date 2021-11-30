﻿-- All of the code in here is from a generated script (option when you try to publish), where I took out the setup and generate table parts.
-- This will need to be updated should the tables of the database schema be updated.
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


USE [IdeventTestDB];

PRINT N'Creating Table [dbo].[Addresses]...';


GO
CREATE TABLE [dbo].[Addresses] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [StreetAddress] NVARCHAR (100) NOT NULL,
    [City]          NVARCHAR (50)  NOT NULL,
    [Country]       NVARCHAR (50)  NOT NULL,
    [PostalCode]    NVARCHAR (10)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[AspNetRoleClaims]...';


GO
CREATE TABLE [dbo].[AspNetRoleClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [RoleId]     NVARCHAR (450) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Index [dbo].[AspNetRoleClaims].[IX_AspNetRoleClaims_RoleId]...';


GO
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId]
    ON [dbo].[AspNetRoleClaims]([RoleId] ASC);


GO
PRINT N'Creating Table [dbo].[AspNetRoles]...';


GO
CREATE TABLE [dbo].[AspNetRoles] (
    [Id]               NVARCHAR (450) NOT NULL,
    [Name]             NVARCHAR (256) NULL,
    [NormalizedName]   NVARCHAR (256) NULL,
    [ConcurrencyStamp] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Index [dbo].[AspNetRoles].[RoleNameIndex]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[AspNetRoles]([NormalizedName] ASC) WHERE ([NormalizedName] IS NOT NULL);


GO
PRINT N'Creating Table [dbo].[AspNetUserClaims]...';


GO
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (450) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Index [dbo].[AspNetUserClaims].[IX_AspNetUserClaims_UserId]...';


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId]
    ON [dbo].[AspNetUserClaims]([UserId] ASC);


GO
PRINT N'Creating Table [dbo].[AspNetUserLogins]...';


GO
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider]       NVARCHAR (128) NOT NULL,
    [ProviderKey]         NVARCHAR (128) NOT NULL,
    [ProviderDisplayName] NVARCHAR (MAX) NULL,
    [UserId]              NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC)
);


GO
PRINT N'Creating Index [dbo].[AspNetUserLogins].[IX_AspNetUserLogins_UserId]...';


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId]
    ON [dbo].[AspNetUserLogins]([UserId] ASC);


GO
PRINT N'Creating Table [dbo].[AspNetUserRoles]...';


GO
CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] NVARCHAR (450) NOT NULL,
    [RoleId] NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC)
);


GO
PRINT N'Creating Index [dbo].[AspNetUserRoles].[IX_AspNetUserRoles_RoleId]...';


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId]
    ON [dbo].[AspNetUserRoles]([RoleId] ASC);


GO
PRINT N'Creating Table [dbo].[AspNetUsers]...';


GO
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
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Index [dbo].[AspNetUsers].[EmailIndex]...';


GO
CREATE NONCLUSTERED INDEX [EmailIndex]
    ON [dbo].[AspNetUsers]([NormalizedEmail] ASC);


GO
PRINT N'Creating Index [dbo].[AspNetUsers].[UserNameIndex]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[AspNetUsers]([NormalizedUserName] ASC) WHERE ([NormalizedUserName] IS NOT NULL);


GO
PRINT N'Creating Index [dbo].[AspNetUsers].[IX_AspNetUsers_InvoiceAddressId]...';


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_InvoiceAddressId]
    ON [dbo].[AspNetUsers]([InvoiceAddressId] ASC);


GO
PRINT N'Creating Index [dbo].[AspNetUsers].[IX_AspNetUsers_CompanyId]...';


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_CompanyId]
    ON [dbo].[AspNetUsers]([CompanyId] ASC);


GO
PRINT N'Creating Index [dbo].[AspNetUsers].[IX_AspNetUsers_AddressId]...';


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_AddressId]
    ON [dbo].[AspNetUsers]([AddressId] ASC);


GO
PRINT N'Creating Table [dbo].[AspNetUserTokens]...';


GO
CREATE TABLE [dbo].[AspNetUserTokens] (
    [UserId]        NVARCHAR (450) NOT NULL,
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [Name]          NVARCHAR (128) NOT NULL,
    [Value]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED ([UserId] ASC, [LoginProvider] ASC, [Name] ASC)
);


GO
PRINT N'Creating Table [dbo].[ChipContents]...';


GO
CREATE TABLE [dbo].[ChipContents] (
    [Id]                INT IDENTITY (1, 1) NOT NULL,
    [FK_StandProductId] INT NOT NULL,
    [FK_ChipId]         INT NULL,
    [FK_ChipGroupId]    INT NULL,
    [Amount]            INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[ChipGroups]...';


GO
CREATE TABLE [dbo].[ChipGroups] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Chips]...';


GO
CREATE TABLE [dbo].[Chips] (
    [Id]             INT                IDENTITY (1, 1) NOT NULL,
    [HashedId]       NVARCHAR (50)      NOT NULL,
    [ValidFrom]      DATETIMEOFFSET (7) NOT NULL,
    [ValidTo]        DATETIMEOFFSET (7) NOT NULL,
    [FK_ChipGroupId] INT                NOT NULL,
    [FK_UserId]      INT                NULL,
    [FK_CompanyId]   INT                NOT NULL,
    [FK_EventId]     INT                NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Companies]...';


GO
CREATE TABLE [dbo].[Companies] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [Name]                NVARCHAR (50)  NOT NULL,
    [Logo]                NVARCHAR (255) NOT NULL,
    [CVR]                 NVARCHAR (8)   NOT NULL,
    [Email]               NVARCHAR (254) NOT NULL,
    [PhoneNumber]         NVARCHAR (30)  NOT NULL,
    [Active]              BIT            NOT NULL,
    [Note]                NVARCHAR (255) NOT NULL,
    [FK_AddressId]        INT            NOT NULL,
    [FK_InvoiceAddressId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[CompanyPermissions]...';


GO
CREATE TABLE [dbo].[CompanyPermissions] (
    [Id]              INT IDENTITY (1, 1) NOT NULL,
    [FK_CompanyId]    INT NOT NULL,
    [FK_PermissionId] INT NOT NULL,
    [Limit]           INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Events]...';


GO
CREATE TABLE [dbo].[Events] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50) NOT NULL,
    [FK_CompanyId] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[EventStands]...';


GO
CREATE TABLE [dbo].[EventStands] (
    [Id]                      INT           IDENTITY (1, 1) NOT NULL,
    [Name]                    NVARCHAR (50) NOT NULL,
    [FK_EventId]              INT           NOT NULL,
    [FK_StandFunctionalityId] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[Permissions]...';


GO
CREATE TABLE [dbo].[Permissions] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[StandFunctionalities]...';


GO
CREATE TABLE [dbo].[StandFunctionalities] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[StandProducts]...';


GO
CREATE TABLE [dbo].[StandProducts] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (50)   NULL,
    [Value]           DECIMAL (18, 2) NOT NULL,
    [FK_EventStandId] INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Default Constraint unnamed constraint on [dbo].[Companies]...';


GO
ALTER TABLE [dbo].[Companies]
    ADD DEFAULT '' FOR [Note];


GO
PRINT N'Creating Foreign Key [dbo].[FK_AspNetRoleClaims_AspNetRoles_RoleId]...';


GO
ALTER TABLE [dbo].[AspNetRoleClaims] WITH NOCHECK
    ADD CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating Foreign Key [dbo].[FK_AspNetUserClaims_AspNetUsers_UserId]...';


GO
ALTER TABLE [dbo].[AspNetUserClaims] WITH NOCHECK
    ADD CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating Foreign Key [dbo].[FK_AspNetUserLogins_AspNetUsers_UserId]...';


GO
ALTER TABLE [dbo].[AspNetUserLogins] WITH NOCHECK
    ADD CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating Foreign Key [dbo].[FK_AspNetUserRoles_AspNetRoles_RoleId]...';


GO
ALTER TABLE [dbo].[AspNetUserRoles] WITH NOCHECK
    ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating Foreign Key [dbo].[FK_AspNetUserRoles_AspNetUsers_UserId]...';


GO
ALTER TABLE [dbo].[AspNetUserRoles] WITH NOCHECK
    ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating Foreign Key [dbo].[FK_AspNetUsers_AddressModel_AddressId]...';


GO
ALTER TABLE [dbo].[AspNetUsers] WITH NOCHECK
    ADD CONSTRAINT [FK_AspNetUsers_AddressModel_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[AddressModel] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_AspNetUsers_AddressModel_InvoiceAddressId]...';


GO
ALTER TABLE [dbo].[AspNetUsers] WITH NOCHECK
    ADD CONSTRAINT [FK_AspNetUsers_AddressModel_InvoiceAddressId] FOREIGN KEY ([InvoiceAddressId]) REFERENCES [dbo].[AddressModel] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_AspNetUsers_CompanyModel_CompanyId]...';


GO
ALTER TABLE [dbo].[AspNetUsers] WITH NOCHECK
    ADD CONSTRAINT [FK_AspNetUsers_CompanyModel_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[CompanyModel] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_AspNetUserTokens_AspNetUsers_UserId]...';


GO
ALTER TABLE [dbo].[AspNetUserTokens] WITH NOCHECK
    ADD CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating Foreign Key [dbo].[FK_ChipContents_ToStandProducts]...';


GO
ALTER TABLE [dbo].[ChipContents] WITH NOCHECK
    ADD CONSTRAINT [FK_ChipContents_ToStandProducts] FOREIGN KEY ([FK_StandProductId]) REFERENCES [dbo].[StandProducts] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Chips_ToCompanies]...';


GO
ALTER TABLE [dbo].[Chips] WITH NOCHECK
    ADD CONSTRAINT [FK_Chips_ToCompanies] FOREIGN KEY ([FK_CompanyId]) REFERENCES [dbo].[Companies] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Chips_ToEvents]...';


GO
ALTER TABLE [dbo].[Chips] WITH NOCHECK
    ADD CONSTRAINT [FK_Chips_ToEvents] FOREIGN KEY ([FK_EventId]) REFERENCES [dbo].[Events] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Chips_ToChipGroups]...';


GO
ALTER TABLE [dbo].[Chips] WITH NOCHECK
    ADD CONSTRAINT [FK_Chips_ToChipGroups] FOREIGN KEY ([FK_ChipGroupId]) REFERENCES [dbo].[ChipGroups] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Companies_ToAddresses]...';


GO
ALTER TABLE [dbo].[Companies] WITH NOCHECK
    ADD CONSTRAINT [FK_Companies_ToAddresses] FOREIGN KEY ([FK_AddressId]) REFERENCES [dbo].[Addresses] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Companies_ToAddresses2]...';


GO
ALTER TABLE [dbo].[Companies] WITH NOCHECK
    ADD CONSTRAINT [FK_Companies_ToAddresses2] FOREIGN KEY ([FK_InvoiceAddressId]) REFERENCES [dbo].[Addresses] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_Events_ToCompanies]...';


GO
ALTER TABLE [dbo].[Events] WITH NOCHECK
    ADD CONSTRAINT [FK_Events_ToCompanies] FOREIGN KEY ([FK_CompanyId]) REFERENCES [dbo].[Companies] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_EventStands_ToEvents]...';


GO
ALTER TABLE [dbo].[EventStands] WITH NOCHECK
    ADD CONSTRAINT [FK_EventStands_ToEvents] FOREIGN KEY ([FK_EventId]) REFERENCES [dbo].[Events] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_EventStands_ToStandFunctionalities]...';


GO
ALTER TABLE [dbo].[EventStands] WITH NOCHECK
    ADD CONSTRAINT [FK_EventStands_ToStandFunctionalities] FOREIGN KEY ([FK_StandFunctionalityId]) REFERENCES [dbo].[StandFunctionalities] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_EventStandProducts_ToEventStands]...';


GO
ALTER TABLE [dbo].[StandProducts] WITH NOCHECK
    ADD CONSTRAINT [FK_EventStandProducts_ToEventStands] FOREIGN KEY ([FK_EventStandId]) REFERENCES [dbo].[EventStands] ([Id]);

