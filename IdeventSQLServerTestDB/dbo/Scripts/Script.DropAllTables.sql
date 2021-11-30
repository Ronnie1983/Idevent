﻿USE IdeventTestDB -- Name of the database to use.

-- https://www.mssqltips.com/sqlservertip/6798/drop-all-tables-sql-server/ (source on how to make this code)
-- Remove all contraints.
ALTER TABLE dbo.[AspNetRoleClaims] DROP CONSTRAINT[FK_AspNetRoleClaims_AspNetRoles_RoleId]
ALTER TABLE dbo.[AspNetUserClaims] DROP CONSTRAINT[FK_AspNetUserClaims_AspNetUsers_UserId]
ALTER TABLE dbo.[AspNetUserLogins] DROP CONSTRAINT[FK_AspNetUserLogins_AspNetUsers_UserId]
ALTER TABLE dbo.[AspNetUserRoles] DROP CONSTRAINT[FK_AspNetUserRoles_AspNetRoles_RoleId]
ALTER TABLE dbo.[AspNetUserRoles] DROP CONSTRAINT[FK_AspNetUserRoles_AspNetUsers_UserId]
ALTER TABLE dbo.[AspNetUserTokens] DROP CONSTRAINT[FK_AspNetUserTokens_AspNetUsers_UserId]
ALTER TABLE dbo.[ChipContents] DROP CONSTRAINT[FK_ChipContents_ToStandProducts]
ALTER TABLE dbo.[Chips] DROP CONSTRAINT[FK_Chips_ToChipGroups]
ALTER TABLE dbo.[Chips] DROP CONSTRAINT[FK_Chips_ToCompanies]
ALTER TABLE dbo.[Chips] DROP CONSTRAINT[FK_Chips_ToEvents]
ALTER TABLE dbo.[Companies] DROP CONSTRAINT[FK_Companies_ToAddresses]
ALTER TABLE dbo.[Companies] DROP CONSTRAINT[FK_Companies_ToAddresses2]
ALTER TABLE dbo.[Events] DROP CONSTRAINT[FK_Events_ToCompanies]
ALTER TABLE dbo.[EventStands] DROP CONSTRAINT[FK_EventStands_ToEvents]
ALTER TABLE dbo.[EventStands] DROP CONSTRAINT[FK_EventStands_ToStandFunctionalities]
ALTER TABLE dbo.[StandProducts] DROP CONSTRAINT[FK_EventStandProducts_ToEventStands]

-- Drop all the tables (apart from EFMigrations)
DROP TABLE [dbo].[Addresses]
DROP TABLE [dbo].[AspNetRoleClaims]
DROP TABLE [dbo].[AspNetRoles]
DROP TABLE [dbo].[AspNetUserClaims]
DROP TABLE [dbo].[AspNetUserLogins]
DROP TABLE [dbo].[AspNetUserRoles]
DROP TABLE [dbo].[AspNetUsers]
DROP TABLE [dbo].[AspNetUserTokens]
DROP TABLE [dbo].[ChipContents]
DROP TABLE [dbo].[ChipGroups]
DROP TABLE [dbo].[Chips]
DROP TABLE [dbo].[Companies]
DROP TABLE [dbo].[CompanyPermissions]
DROP TABLE [dbo].[Events]
DROP TABLE [dbo].[EventStands]
DROP TABLE [dbo].[Permissions]
DROP TABLE [dbo].[StandFunctionalities]
DROP TABLE [dbo].[StandProducts]