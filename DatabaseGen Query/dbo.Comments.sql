﻿CREATE TABLE [dbo].[Comments] (
    [sid]       INT           NOT NULL,
    [commentId] INT           NOT NULL,
    [comment]   NVARCHAR (50) NOT NULL,
    [lstDemoDt] DATE          NULL,
    [lstRevInt] SMALLINT      NULL,
    [lstRevDt]  DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([commentId] ASC),
    CONSTRAINT [FK_Comments_SoftName] FOREIGN KEY ([sid]) REFERENCES [dbo].[SoftName] ([sid]) ON DELETE CASCADE
);

