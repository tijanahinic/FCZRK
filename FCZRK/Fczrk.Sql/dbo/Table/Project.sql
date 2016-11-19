CREATE TABLE [dbo].[Project]
(
	[Id] INT NOT NULL  IDENTITY(1,1) PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [LogoUrl] NVARCHAR(50) NOT NULL, 
    [Year] INT NOT NULL, 
    [Active] BIT NOT NULL, 
    [ProjectImagesId] INT NOT NULL, 
    CONSTRAINT [FK_Project_ProjectImages] FOREIGN KEY ([ProjectImagesId]) REFERENCES [ProjectImages]([Id]), 
)
