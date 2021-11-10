CREATE TABLE [dbo].[Companies]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [CompanyName] NVARCHAR(50) NOT NULL, 
    [Logo] NVARCHAR(100) NOT NULL, 
    [CVR] NVARCHAR(8) NOT NULL, 
    [Email] NVARCHAR(254) NOT NULL, 
    [PhoneNumber] NVARCHAR(30) NOT NULL, 
    [Active] BIT NOT NULL, 
    [Note] NVARCHAR(255) NOT NULL DEFAULT '', 
    [FK_AddressId] INT NOT NULL, 
    [FK_InvoiceAddressId] INT NOT NULL, 
    CONSTRAINT [FK_Companies_ToAddresses] FOREIGN KEY (FK_AddressId) REFERENCES [Addresses]([Id]),
    CONSTRAINT [FK_Companies_ToAddresses2] FOREIGN KEY (FK_InvoiceAddressId) REFERENCES [Addresses]([Id])
)
