CREATE TABLE [dbo].[Addresses]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [StreetAddress] NVARCHAR(100) NOT NULL, 
    [City] NVARCHAR(50) NOT NULL, 
    [Country] NVARCHAR(50) NOT NULL, 
    [PostalCode] NVARCHAR(10) NOT NULL
)
