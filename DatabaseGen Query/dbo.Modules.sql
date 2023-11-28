CREATE TABLE [dbo].[Modules] (
    [modulesId] INT           IDENTITY (1, 1) NOT NULL,
    [sid]       INT           NOT NULL,
    [modules]   NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([modulesId] ASC),
    CONSTRAINT [FK_Modules_SoftName] FOREIGN KEY ([sid]) REFERENCES [dbo].[SoftName] ([sid]) ON DELETE CASCADE
);

