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

  -- Add more data via the https://generatedata.com/generator

IF NOT EXISTS (SELECT * FROM Addresses WHERE Addresses.Id = 1)

BEGIN

-- Addresses
INSERT INTO [Addresses] (Id,StreetAddress,Country,PostalCode)
VALUES
  (1,'288-4541 Turpis Rd.','Colombia','36951'),
  (2,'Ap #825-8071 Id Rd.','Peru','65377-36223'),
  (3,'Ap #482-7550 Velit. Avenue','Austria','2384'),
  (4,'375-639 Proin St.','Colombia','502464'),
  (5,'Ap #368-3068 Egestas. Road','France','SM2M 1IC');
 
 -- Companies
INSERT INTO [Companies] (Id,Name,Logo,CVR,Email,PhoneNumber,Active,Note,FK_AddressId,FK_InvoiceAddressId)
VALUES
  (3,'Vitae Risus Duis Industries','images/mompanyname/S4YBNRT9BX.jpg','14030759','dapibus.gravida@icloud.net','+45 64498314','0','In condimentum. Donec at arcu. Vestibulum ante ipsum',2,3),
  (2,'Urna Incorporated','images/lompanyname/J8NNBJL2OF.jpg','34882358','non@hotmail.edu','+45 47328132','1','ridiculus mus. Aenean eget magna.',1,4),
  (5,'Auctor LLC','images/sompanyname/V9JPYED9PS.jpg','74896529','urna@aol.org','+45 08227768','0','Vivamus euismod urna. Nullam',4,4),
  (2,'Curabitur Vel Associates','images/jompanyname/G6PLOWY7KD.jpg','15962181','dolor.tempus@aol.edu','+45 79268841','0','tristique pharetra.',4,1),
  (2,'Donec Felis Incorporated','images/sompanyname/I7CDCIN6PC.jpg','68213164','quam.elementum@yahoo.net','+45 15442894','1','Phasellus ornare. Fusce mollis. Duis sit amet',2,1);
 
 -- StandFunctionalities
 INSERT INTO StandFunctionalities(Id, Name)
VALUES
  (1,'Products'),
  (2,'Entré');

 -- EventStands

 -- StandProducts

 -- ChipGroups

 -- Chips
 INSERT INTO Chips(Id,HashedId,ValidFrom,ValidTo,FK_ChipGroupId,FK_UserId,FK_CompanyId,FK_EventId)
VALUES
  (2,'urna,','2021-08-21 05:49:12','2022-01-31 08:21:28',3,4,3,3),
  (2,'mauris.','2021-10-08 14:22:23','2022-01-30 17:11:37',3,5,2,8),
  (3,'sapien','2021-09-19 23:01:21','2022-01-25 13:12:05',2,2,3,8),
  (1,'nunc','2021-10-01 05:26:11','2022-01-22 04:17:35',3,3,3,2),
  (3,'enim.','2021-10-28 12:57:59','2022-01-29 03:27:12',1,2,2,1);

 -- ChipContents

 -- Permissions

 -- CompanyPermissions
 
 END