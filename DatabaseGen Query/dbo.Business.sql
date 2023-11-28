CREATE TABLE [dbo].[Business] (
    [businessId]   INT           IDENTITY (1, 1) NOT NULL,
    [sid]          INT           NOT NULL,
    [BusinessArea] NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([businessId] ASC),
    CONSTRAINT [FK_Business_SoftName] FOREIGN KEY ([sid]) REFERENCES [dbo].[SoftName] ([sid]) ON DELETE CASCADE
);

