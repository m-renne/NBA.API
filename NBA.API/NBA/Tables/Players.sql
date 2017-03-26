CREATE TABLE [dbo].[Players]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[FirstName] varchar(MAX) NOT NULL,
	[LastName] varchar(MAX) NOT NULL,
	[JerseyNumber] INT NOT NULL
)
