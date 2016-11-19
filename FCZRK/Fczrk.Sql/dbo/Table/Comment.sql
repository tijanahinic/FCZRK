CREATE TABLE [dbo].[Comment]
(
	[Id] INT NOT NULL  IDENTITY(1,1) PRIMARY KEY, 
    [Text] NVARCHAR(MAX) NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Active] BIT NOT NULL, 
    [DateCreated] DATE NOT NULL, 
    [ProjectId] INT NOT NULL, 
    CONSTRAINT [FK_Comment_Project] FOREIGN KEY ([ProjectId]) REFERENCES [Project]([Id])
)
