﻿CREATE TABLE [dbo].[Contacts]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[FirstName] NVARCHAR(100) NOT NULL,
	[LastName] NVARCHAR(100) NOT NULL,
	[Email] NVARCHAR(100) NOT NULL,
	[Phone] NVARCHAR(100) NULL,
	[Message] NVARCHAR(MAX) NOT NULL,
	[Archived] BIT NOT NULL DEFAULT(0)
)
