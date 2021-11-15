/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/* Address Data */
IF NOT EXISTS (SELECT * FROM Addresses
               WHERE Addresses.StreetAddress = 'Demo Addresstreet 123' OR
               Addresses.StreetAddress = 'Demo Street 2B')
          
BEGIN
    INSERT INTO dbo.Addresses(StreetAddress, City, Country, PostalCode)
    VALUES ('Demo Addresstreet 123', 'København N', 'Denmark', '2200'), 
            ('Demo Street 2B', 'Skævinge', 'Denmark', '3320')
END


/* Company Data */
IF NOT EXISTS (SELECT * FROM Companies
               WHERE CompanyName = 'Demo Company' OR 
               CompanyName = 'Demo Company 2')
BEGIN
    INSERT INTO Companies (CompanyName, CVR, PhoneNumber, Email, Logo, Note, Active, FK_AddressId, FK_InvoiceAddressId)
    VALUES ('Demo Company', '12345678', '+45 55 33 22 11','demo@mail.dk', 'images/logo-1' ,'Nem at snakke med', 1, 1, 1), 
            ('Demo Company 2', '87654321', '+45 99 99 99 99','demo2@mail.dk', 'images/logo-2' ,'', 0, 1, 1)
END

/* Event Data */ 
IF NOT EXISTS (SELECT * FROM Events
               WHERE Events.Name = 'Demo Event' OR 
               Events.Name = 'Demo Event 2' OR 
               Events.Name = 'Demo Event 3')
BEGIN
    INSERT INTO dbo.Events (Events.Name, Events.FK_CompanyId)
    VALUES ('Demo Event', 1), ('Demo Event 2', 1), ('Demo Event 3', 2)
END

/* EventStand Data */
