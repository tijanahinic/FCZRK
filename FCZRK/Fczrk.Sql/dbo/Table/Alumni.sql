CREATE TABLE [dbo].[Alumni]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [DateOfBirth] DATE NOT NULL, 
    [ImageUrl] NVARCHAR(50) NULL, 
    [Occupation] NVARCHAR(100) NOT NULL, 
    [Duration] INT NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL
)
