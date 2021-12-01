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

BEGIN

-- Addresses
INSERT INTO [Addresses] (Id,StreetAddress,City,Country,PostalCode)
VALUES
  (1,'288-4541 Turpis Rd.','Sweet Home Alabama City','Colombia','36951'),
  (2,'Ap #825-8071 Id Rd.','Elán','Peru','43029'),
  (3,'Ap #482-7550 Velit. Avenue','Heranburg','Austria','2384'),
  (4,'375-639 Proin St.','Reckon','Colombia','502464'),
  (5,'Ap #368-3068 Egestas. Road','Chapville','France','SM2M 1IC');
 
 -- Companies
INSERT INTO [Companies] (Id,Name,Logo,CVR,Email,PhoneNumber,Active,Note,FK_AddressId,FK_InvoiceAddressId)
VALUES
  (1,'Vitae Risus Duis Industries','images/mompanyname/S4YBNRT9BX.jpg','14030759','dapibus.gravida@icloud.net','+45 64498314','0','In condimentum. Donec at arcu. Vestibulum ante ipsum',2,3),
  (2,'Urna Incorporated','images/lompanyname/J8NNBJL2OF.jpg','34882358','non@hotmail.edu','+45 47328132','1','ridiculus mus. Aenean eget magna.',1,4),
  (3,'Auctor LLC','images/sompanyname/V9JPYED9PS.jpg','74896529','urna@aol.org','+45 08227768','0','Vivamus euismod urna. Nullam',4,4),
  (4,'Curabitur Vel Associates','images/jompanyname/G6PLOWY7KD.jpg','15962181','dolor.tempus@aol.edu','+45 79268841','0','tristique pharetra.',4,1),
  (5,'Donec Felis Incorporated','images/sompanyname/I7CDCIN6PC.jpg','68213164','quam.elementum@yahoo.net','+45 15442894','1','Phasellus ornare. Fusce mollis. Duis sit amet',2,1);
 
 -- Events
 INSERT INTO [Events] (Id,Name,FK_CompanyId)
VALUES
  (1,'Vuugruxw Yfpc 2021',4),
  (2,'Xgujdnjn Uhlm 2022',5),
  (3,'Kdjyfcnq Xlsq 2021',2),
  (4,'Sdgokkop Zqeg 2022',4),
  (5,'Hpknfttj Slgl 2022',5);

 -- StandFunctionalities
 INSERT INTO StandFunctionalities(Id, Name)
VALUES
  (1,'Products'),
  (2,'Entré');

 -- EventStands
 INSERT INTO [EventStands] (Id,Name,FK_EventId, FK_StandFunctionalityId)
VALUES
  (1,'Magma',1,2),
  (2,'Et magnis dis',2,1),
  (3,'Ipsum cursus',2,1),
  (4,'Accumsan sed',1,1),
  (5,'Accumsan interdum',2,1);
 -- StandProducts
 INSERT INTO [StandProducts] (Id,Name,Value,FK_EventStandId)
VALUES
  (1,'ullamcorper, velit',88,2),
  (2,'ipsum',34,1),
  (3,'risus odio,',51,2),
  (4,'lacus. Nulla',9,4),
  (5,'mauris',9,4);
 -- ChipGroups
 INSERT INTO [ChipGroups] (Id,Name)
VALUES
  (1,'ullamcorper, velit'),
  (2,'ipsum'),
  (3,'risus odio,'),
  (4,'lacus. Nulla'),
  (5,'mauris');
 -- Chips
 INSERT INTO Chips(Id,HashedId,ValidFrom,ValidTo,FK_ChipGroupId,FK_UserId,FK_CompanyId,FK_EventId)
VALUES
  (1,'urna,','2021-08-21 05:49:12','2022-01-31 08:21:28',3,4,3,3),
  (2,'mauris.','2021-10-08 14:22:23','2022-01-30 17:11:37',3,5,2,4),
  (3,'sapien','2021-09-19 23:01:21','2022-01-25 13:12:05',2,2,3,5),
  (4,'nunc','2021-10-01 05:26:11','2022-01-22 04:17:35',3,3,3,2),
  (5,'enim.','2021-10-28 12:57:59','2022-01-29 03:27:12',1,2,2,1);

 -- ChipContents
 INSERT INTO [ChipContents] (Id,FK_StandProductId,FK_ChipId,FK_ChipGroupId,Amount)
VALUES
  (1,2,4,1,10),
  (2,4,1,1,10),
  (3,4,3,1,6),
  (4,3,3,3,8),
  (5,4,2,5,4);
 -- Permissions
 INSERT INTO [Permissions] (Id,Name)
VALUES
  (1,'Permission 1'), -- Maybe some other 'names' for meaningful permissions
  (2,'Permission 2'),
  (3,'Permission 3'),
  (4,'Permission 4'),
  (5,'Permission 5');
 -- CompanyPermissions
 INSERT INTO [CompanyPermissions] (Id,FK_CompanyId,FK_PermissionId,Limit)
VALUES
  (1,1,4,null),
  (2,5,5,null),
  (3,3,2,null),
  (4,1,4,null),
  (5,4,5,null);

END