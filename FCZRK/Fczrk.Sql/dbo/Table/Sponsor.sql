CREATE TABLE [dbo].[Sponsor]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [ImageUrl] NVARCHAR(50) NOT NULL, 
    [Text] NVARCHAR(MAX) NOT NULL, 
    [WebsiteUrl] NVARCHAR(50) NOT NULL, 
    [CategoryId] INT NOT NULL, 
    CONSTRAINT [FK_Sponsor_SponsorCategory] FOREIGN KEY ([CategoryId]) REFERENCES [SponsorCategory]([Id])
)
