CREATE TABLE [dbo].[ProjectSponsor]
(
	[ProjectId] INT NOT NULL , 
    [SponsorId] INT NOT NULL, 
    CONSTRAINT [FK_ProjectSponsor_Project] FOREIGN KEY ([ProjectId]) REFERENCES [Project]([Id]), 
    CONSTRAINT [FK_ProjectSponsor_Sponsor] FOREIGN KEY ([SponsorId]) REFERENCES [Sponsor]([Id]), 
    PRIMARY KEY ([ProjectId], [SponsorId])
)
