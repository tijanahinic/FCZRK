CREATE TABLE [dbo].[Member]
(
	[UserId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [MemberSince] INT NOT NULL, 
    [ImageUrl] NVARCHAR(50) NULL, 
    [LinkedInUrl] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [SectionId] INT NOT NULL, 
    CONSTRAINT [FK_Member_Section] FOREIGN KEY ([SectionId]) REFERENCES [Section]([Id]),
	CONSTRAINT [FK_Member_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])

)
