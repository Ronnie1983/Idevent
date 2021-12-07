
  -- Add more data via the https://generatedata.com/generator

BEGIN

-- Addresses
INSERT INTO [Addresses] (StreetAddress,City,Country,PostalCode)
VALUES
  ('288-4541 Turpis Rd.','Sweet Home Alabama City','Colombia','36951'),
  ('Apostel Rd. 255xxx','Elán','Peru','43029'),
  ('Ballon Avenue 5xxx','Heranburg','Austria','2384'),
  ('375-639 Proin St.','Reckon','Colombia','502464'),
  ('Ap Egestas. Road','Chapville','France','SM2M 1IC');

-- AddressModel (same as Addressses, but EF Core)
INSERT INTO [AddressModel] (StreetAddress,City,Country,PostalCode)
VALUES
  ('288-4541 Turpis Rd.','Sweet Home Alabama City','Colombia','36951'),
  ('Apostel Rd. 255','Elán','Peru','43029'),
  ('Ballon Avenue 5B','Heranburg','Austria','2384'),
  ('375-639 Proin St.','Reckon','Colombia','502464'),
  ('Ap Egestasroad 712','Chapville','France','SM2M 1IC');
 
  -- Companies
INSERT INTO [Companies](Name,Logo,CVR,Email,PhoneNumber,Active,Note,FK_AddressId,FK_InvoiceAddressId)
VALUES
  ('Vitae Risus Duis Industries','images/mompanyname/S4YBNRT9BX.jpg','14030759','dapibus.gravida@icloud.net','+45 64498314','0','In condimentum. Donec at arcu. Vestibulum ante ipsum',2,3),
  ('Urna Incorporated','images/lompanyname/J8NNBJL2OF.jpg','34882358','non@hotmail.edu','+45 47328132','1','ridiculus mus. Aenean eget magna.',1,4),
  ('Auctor LLC','images/sompanyname/V9JPYED9PS.jpg','74896529','urna@aol.org','+45 08227768','0','Vivamus euismod urna. Nullam',4,4),
  ('Curabitur Vel Associates','images/jompanyname/G6PLOWY7KD.jpg','15962181','dolor.tempus@aol.edu','+45 79268841','0','tristique pharetra.',4,1),
  ('Donec Felis Incorporated','images/sompanyname/I7CDCIN6PC.jpg','68213164','quam.elementum@yahoo.net','+45 15442894','1','Phasellus ornare. Fusce mollis. Duis sit amet',2,1);
 

 -- CompanyModel (same as Companies, but EF Core)
INSERT INTO [CompanyModel](Name,Logo,CVR,Email,PhoneNumber,Active,Note,AddressId,InvoiceAddressId)
VALUES
  ('Vitae Risus Duis Industries','images/mompanyname/S4YBNRT9BX.jpg','14030759','dapibus.gravida@icloud.net','+45 64498314','0','In condimentum. Donec at arcu. Vestibulum ante ipsum',2,3),
  ('Urna Incorporated','images/lompanyname/J8NNBJL2OF.jpg','34882358','non@hotmail.edu','+45 47328132','1','ridiculus mus. Aenean eget magna.',1,4),
  ('Auctor LLC','images/sompanyname/V9JPYED9PS.jpg','74896529','urna@aol.org','+45 08227768','0','Vivamus euismod urna. Nullam',4,4),
  ('Curabitur Vel Associates','images/jompanyname/G6PLOWY7KD.jpg','15962181','dolor.tempus@aol.edu','+45 79268841','0','tristique pharetra.',4,1),
  ('Donec Felis Incorporated','images/sompanyname/I7CDCIN6PC.jpg','68213164','quam.elementum@yahoo.net','+45 15442894','1','Phasellus ornare. Fusce mollis. Duis sit amet',2,1);
 
 -- Events
 INSERT INTO [Events] (Name,FK_CompanyId)
VALUES
  ('Vuugruxw Yfpc 2021',4),
  ('Xgujdnjn Uhlm 2022',5),
  ('Kdjyfcnq Xlsq 2021',2),
  ('Sdgokkop Zqeg 2022',4),
  ('Hpknfttj Slgl 2022',5);

 -- StandFunctionalities
 INSERT INTO StandFunctionalities( Name)
VALUES
  ('Products'),
  ('Entré');

 -- EventStands
 INSERT INTO [EventStands] (Name,FK_EventId, FK_StandFunctionalityId)
VALUES
  ('Magma',1,2),
  ('Et magnis dis',2,1),
  ('Ipsum cursus',2,1),
  ('Accumsan sed',1,1),
  ('Accumsan interdum',2,1);
 -- StandProducts
 INSERT INTO [StandProducts] (Name,Value,FK_EventStandId)
VALUES
  ('ullamcorper, velit',88,2),
  ('ipsum',34,1),
  ('risus odio,',51,2),
  ('lacus. Nulla',9,4),
  ('mauris',9,4);
 -- ChipGroups
 INSERT INTO [ChipGroups] (Name, FK_EventId)
VALUES
  ('ullamcorper, velit', 1),
  ('ipsum', 5),
  ('risus odio,', 2),
  ('lacus. Nulla', 4),
  ('mauris', 3);
 -- Chips
 INSERT INTO Chips(HashedId,ValidFrom,ValidTo,FK_ChipGroupId,FK_UserId,FK_CompanyId,FK_EventId)
VALUES
  ('urna,','2021-08-21 05:49:12','2022-01-31 08:21:28',3,4,3,2),
  ('mauris.','2021-10-08 14:22:23','2022-01-30 17:11:37',3,5,2,2),
  ('sapien','2021-09-19 23:01:21','2022-01-25 13:12:05',2,2,3,5),
  ('nunc','2021-10-01 05:26:11','2022-01-22 04:17:35',3,3,3,2),
  ('enim.','2021-10-28 12:57:59','2022-01-29 03:27:12',1,2,2,1);

 -- ChipContents
 INSERT INTO [ChipContents] (FK_StandProductId,FK_ChipId,FK_ChipGroupId,Amount)
VALUES
  (2,4,1,10),
  (4,1,1,10),
  (4,3,1,6),
  (3,3,3,8),
  (4,2,5,4);
 -- Permissions
 INSERT INTO [Permissions] (Name)
VALUES
  ('Permission 1'), -- Maybe some other 'names' for meaningful permissions
  ('Permission 2'),
  ('Permission 3'),
  ('Permission 4'),
  ('Permission 5');
 -- CompanyPermissions
 INSERT INTO [CompanyPermissions] (FK_CompanyId,FK_PermissionId,Limit)
VALUES
  (1,4,null),
  (5,5,null),
  (3,2,null),
  (1,4,null),
  (4,5,null);

END