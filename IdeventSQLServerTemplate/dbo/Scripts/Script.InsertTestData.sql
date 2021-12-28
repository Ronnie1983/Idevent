
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

-- Deprecated -- AddressModel (same as Addressses, but EF Core)
--INSERT INTO [AddressModel] (StreetAddress,City,Country,PostalCode)
--VALUES
--  ('288-4541 Turpis Rd.','Sweet Home Alabama City','Colombia','36951'),
--  ('Apostel Rd. 255','Elán','Peru','43029'),
--  ('Ballon Avenue 5B','Heranburg','Austria','2384'),
--  ('375-639 Proin St.','Reckon','Colombia','502464'),
--  ('Ap Egestasroad 712','Chapville','France','SM2M 1IC');
 
  -- Companies
INSERT INTO [Companies](Name,Logo,CVR,Email,PhoneNumber,Active,Note,AddressId,InvoiceAddressId)
VALUES
  ('Vitae Risus Duis Industries','images/mompanyname/S4YBNRT9BX.jpg','14030759','dapibus.gravida@icloud.net','+45 64498314','0','In condimentum. Donec at arcu. Vestibulum ante ipsum',2,3),
  ('Urna Incorporated','images/lompanyname/J8NNBJL2OF.jpg','34882358','non@hotmail.edu','+45 47328132','1','ridiculus mus. Aenean eget magna.',1,4),
  ('Auctor LLC','images/sompanyname/V9JPYED9PS.jpg','74896529','urna@aol.org','+45 08227768','0','Vivamus euismod urna. Nullam',4,4),
  ('Curabitur Vel Associates','images/jompanyname/G6PLOWY7KD.jpg','15962181','dolor.tempus@aol.edu','+45 79268841','0','tristique pharetra.',4,1),
  ('Donec Felis Incorporated','images/sompanyname/I7CDCIN6PC.jpg','68213164','quam.elementum@yahoo.net','+45 15442894','1','Phasellus ornare. Fusce mollis. Duis sit amet',2,1);
 

 -- Deprecated -- CompanyModel (same as Companies, but EF Core)
--INSERT INTO [CompanyModel](Name,Logo,CVR,Email,PhoneNumber,Active,Note,AddressId,InvoiceAddressId)
--VALUES
--  ('Vitae Risus Duis Industries','images/mompanyname/S4YBNRT9BX.jpg','14030759','dapibus.gravida@icloud.net','+45 64498314','0','In condimentum. Donec at arcu. Vestibulum ante ipsum',2,3),
--  ('Urna Incorporated','images/lompanyname/J8NNBJL2OF.jpg','34882358','non@hotmail.edu','+45 47328132','1','ridiculus mus. Aenean eget magna.',1,4),
--  ('Auctor LLC','images/sompanyname/V9JPYED9PS.jpg','74896529','urna@aol.org','+45 08227768','0','Vivamus euismod urna. Nullam',4,4),
--  ('Curabitur Vel Associates','images/jompanyname/G6PLOWY7KD.jpg','15962181','dolor.tempus@aol.edu','+45 79268841','0','tristique pharetra.',4,1),
--  ('Donec Felis Incorporated','images/sompanyname/I7CDCIN6PC.jpg','68213164','quam.elementum@yahoo.net','+45 15442894','1','Phasellus ornare. Fusce mollis. Duis sit amet',2,1);
 
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
  ('urna','2021-08-21 05:49:12','2022-01-31 08:21:28',3,4,3,2),
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
  -- UserData
INSERT INTO [AspNetUsers] (Id,UserName,NormalizedUserName,Email,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount,AddressId,CompanyId,InvoiceAddressId,Role)
VALUES
  ('5E99B1B2-BA7E-9B2E-2963-50CCB71AD64E','Henry Montoya','Channing Hendricks','cras.eget.nisi@hotmail.net','1','6A037268-0280-BED4-1A56-34C3C24275D8','90FDDBDA-113C-5279-72A6-19C5D4E1DAEE','B377CB9B-B193-AA56-05E4-E13293DED7C7','(066) 75481489','0','0','Sep 14, 2021','0',0,2,3,1,'Kane'),
  ('C8A6B352-F232-9C91-A55D-C5F648E5CD3B','Ella Adams','Gregory Wiley','dui.suspendisse@protonmail.net','1','56EDAD36-9D57-1668-5BD5-DB1ADD7D1F86','1C503685-A712-835A-221A-62666EEDE71A','29522A30-9E51-52C7-3348-476624785EA8','(0157) 40866878','1','1','May 25, 2021','1',0,5,2,4,'Callie'),
  ('29B43C8A-44D4-752C-C545-324A7BC6BD44','Donna Pittman','Whoopi Olson','sit@protonmail.couk','1','A4C599DB-8CA4-3869-B444-0A8B8E54764F','82593B5A-27CB-4B55-BC7A-B37F03015949','C23EDC8E-3404-6E4A-5C44-8601AB8FFA25','(0066) 66913754','1','0','Mar 8, 2021','1',0,1,4,2,'Rooney'),
  ('F1989682-6B8B-6271-58A4-8563DC7ED355','Ian Bender','Kiara Huber','vel.convallis.in@yahoo.couk','1','87A09081-4C91-889E-0800-FD8FE14B59A5','CB885C67-6B5F-2E29-2578-22812C55E731','CAB48FBF-22AE-BD9A-31CD-CA4C482AC13B','(040) 45737545','1','0','Feb 19, 2021','1',0,3,4,5,'Leila'),
  ('C8DE3773-1CAD-1A11-91AD-393D6119BAA3','Vaughan Page','Fay Holcomb','metus.urna@icloud.couk','1','C7CBBD58-65B9-AB1E-2910-93E45C3AB1EE','77C338A4-F1BD-A8C0-5A02-442032C0D62F','76DB9162-8AC2-3ABC-9C92-0B17779AA344','(050) 48456741','1','0','Dec 4, 2022','1',0,2,2,3,'Noble');
  -- RoleData
  INSERT INTO [AspNetRoles] (Id,Name,NormalizedName,ConcurrencyStamp)
VALUES
  ('DB33C481-0B77-6A86-7EB5-B544DCCC7AD7','SuperAdmin','SUPERADMIN','B133291B-A37F-EA14-3101-0C4444DD7591'),
  ('33BE8B38-21AD-B872-B6BC-C7918832FD46','Admin','ADMIN','210997C1-B7B5-C605-7BBE-83ED091EFA4A'),
  ('0E815761-FA6D-8459-3A87-4AE199D02187','User','USER','E4A27769-BC12-585D-082A-7C87EB6E109A'),
  ('40CE7355-8D01-16E7-779E-C75ECC479307','Operator','OPERATOR','D256CD93-E73B-3DA9-7A96-2EB58EA37A3B');
 --UserRolesData
 INSERT INTO [AspNetUserRoles] (UserId, RoleId)
 VALUES
 ('5E99B1B2-BA7E-9B2E-2963-50CCB71AD64E','DB33C481-0B77-6A86-7EB5-B544DCCC7AD7'),
 ('C8A6B352-F232-9C91-A55D-C5F648E5CD3B','33BE8B38-21AD-B872-B6BC-C7918832FD46'),
 ('29B43C8A-44D4-752C-C545-324A7BC6BD44','0E815761-FA6D-8459-3A87-4AE199D02187'),
 ('F1989682-6B8B-6271-58A4-8563DC7ED355','40CE7355-8D01-16E7-779E-C75ECC479307'),
 ('C8DE3773-1CAD-1A11-91AD-393D6119BAA3','40CE7355-8D01-16E7-779E-C75ECC479307');


 END 