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

 -- Events

 -- StandFunctionalities

 -- EventStands

 -- StandProducts

 -- ChipGroups

 -- Chips

 -- ChipContents

 -- Permissions

 -- CompanyPermissions
 
 END