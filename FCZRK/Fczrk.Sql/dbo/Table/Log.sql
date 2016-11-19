CREATE TABLE [dbo].[Log]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Operation] NVARCHAR(50) NOT NULL, 
    [ChangedBy] INT NOT NULL, 
    CONSTRAINT [FK_Log_User] FOREIGN KEY ([ChangedBy]) REFERENCES [User]([Id])
)
