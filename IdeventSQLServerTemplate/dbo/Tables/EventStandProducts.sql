CREATE TABLE [dbo].[EventStandProducts]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] NVARCHAR(50) NULL, 
    [Value] DECIMAL(18, 2) NOT NULL, 
    [FK_EventStandId] INT NOT NULL
)
