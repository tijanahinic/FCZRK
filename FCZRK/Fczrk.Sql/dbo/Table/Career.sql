CREATE TABLE [dbo].[Career]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Position] NVARCHAR(50) NOT NULL, 
    [Company] NVARCHAR(50) NOT NULL, 
    [CompanyUrl] NVARCHAR(50) NOT NULL, 
    [DateFrom] DATE NOT NULL, 
    [DateTo] DATE NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Job] BIT NOT NULL
)
