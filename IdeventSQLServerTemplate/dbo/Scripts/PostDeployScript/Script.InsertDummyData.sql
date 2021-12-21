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


/* Company Data */
    IF NOT EXISTS (SELECT * FROM Companies
               WHERE Companies.Name = 'Demo Company' OR 
               Companies.Name = 'Demo Company 2')
    INSERT INTO Companies (Companies.Name, CVR, PhoneNumber, Email, Logo, Note, Active, AddressId, InvoiceAddressId)
    VALUES ('Demo Company', 'demo@mail.dk', 1, 1,'12345678', '+45 55 33 22 11','Nem at snakke med', 1,'images/logo-1')
            

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


    											
/* User Data */
    IF NOT EXISTS(SELECT * FROM AspNetUsers AS US WHERE US.UserName = 'ronnie1983@hotmail.dk')
    INSERT INTO AspNetUsers VALUES('3bfd3335-2b1c-4e5e-b88f-e2f5b8b12f4e','ronnie1983@hotmail.dk','RONNIE1983@HOTMAIL.DK','ronnie1983@hotmail.dk','RONNIE1983@HOTMAIL.DK',True,'AQAAAAEAACcQAAAAEAUjcMkLgTMqGy7QHSCR7WzDug9UrcrO7WRQYahH/sE5vuqwLsLZW7Cm7me/YBeKKg==','3F72AKMTAYP4UHRVHDEGRL5VBQR2ISIS','1f77c8a3-4706-4186-a33c-91b79314ba07',NULL,False,	False,NULL,True,0,NULL,1,NULL,NULL,'3bfd3335-2b1c-4e5e-b88f-e2f5b8b12f4e','ronnie1983@hotmail.dk','RONNIE1983@HOTMAIL.DK','ronnie1983@hotmail.dk','RONNIE1983@HOTMAIL.DK',True,'AQAAAAEAACcQAAAAEAUjcMkLgTMqGy7QHSCR7WzDug9UrcrO7WRQYahH/sE5vuqwLsLZW7Cm7me/YBeKKg==','3F72AKMTAYP4UHRVHDEGRL5VBQR2ISIS','1f77c8a3-4706-4186-a33c-91b79314ba07',NULL,False,False,NULL,True,0,NULL,1,NULL,NULL)
END
