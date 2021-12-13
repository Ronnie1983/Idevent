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
IF NOT EXISTS (SELECT * FROM AddressModel
               WHERE AddressModel.StreetAddress = 'Demo Addresstreet 123' OR
               AddressModel.StreetAddress = 'Demo Street 2B')
          
BEGIN
    INSERT INTO dbo.AddressModel(StreetAddress, City, Country, PostalCode)
    VALUES ('Demo Addresstreet 123', 'København N', 'Denmark', '2200'), 
            ('Demo Street 2B', 'Skævinge', 'Denmark', '3320')


/* Company Data */
    IF NOT EXISTS (SELECT * FROM CompanyModel
               WHERE CompanyModel.Name = 'Demo Company' OR 
               CompanyModel.Name = 'Demo Company 2')
    INSERT INTO CompanyModel (CompanyModel.Name, CVR, PhoneNumber, Email, Logo, Note, Active, AddressId, InvoiceAddressId)
    VALUES ('Demo Company', '12345678', '+45 55 33 22 11','demo@mail.dk', 'images/logo-1' ,'Nem at snakke med', 1, 1, 1), 
            ('Demo Company 2', '87654321', '+45 99 99 99 99','demo2@mail.dk', 'images/logo-2' ,'', 0, 1, 1)

/* Event Data */ 
    IF NOT EXISTS (SELECT * FROM Events
               WHERE Events.Name = 'Demo Event' OR 
               Events.Name = 'Demo Event 2' OR 
               Events.Name = 'Demo Event 3')
    INSERT INTO dbo.Events (Events.Name, Events.FK_CompanyId)
    VALUES ('Demo Event', 1), ('Demo Event 2', 1), ('Demo Event 3', 2)

/* StandFunctionality */
    IF NOT EXISTS(SELECT * FROM StandFunctionalities AS SF WHERE SF.Name = 'Default')
    INSERT INTO StandFunctionalities(Name)
                            VALUES('Default')

/* EventStand Data */
    IF NOT EXISTS(SELECT * FROM EventStands AS ES WHERE ES.Name = 'Food')
    INSERT INTO EventStands VALUES('Food',1,1)

/* Chips Data */
    IF NOT EXISTS(SELECT * FROM Chips AS CH WHERE CH.HashedId = 'hash')
    INSERT INTO Chips VALUES('hash','11-11-2020','11-11-2022',null,'3bfd3335-2b1c-4e5e-b88f-e2f5b8b12f4e',1,1)

/* Product Data */
    IF NOT EXISTS(SELECT * FROM StandProducts AS PR WHERE PR.Name = 'Pizza')
    INSERT INTO StandProducts VALUES('Pizza',10,1)
END
