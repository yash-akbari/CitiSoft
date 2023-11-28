CREATE TABLE [dbo].[ProblemHistory] (
    [pid]        INT            IDENTITY (1, 1) NOT NULL,
    [cid]        INT            NULL,
    [uid]        INT            NULL,
    [date]       DATE           NULL,
    [desc]       NVARCHAR (255) NULL,
    [isClosed]   BIT            NULL,
    [lstRevDate] DATE           NULL,
    PRIMARY KEY CLUSTERED ([pid] ASC),
    CONSTRAINT [FK_ProblemHistory_Client] FOREIGN KEY ([cid]) REFERENCES [dbo].[Client] ([cid]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProblemHistory_User] FOREIGN KEY ([uid]) REFERENCES [dbo].[User] ([uid]) ON DELETE CASCADE
);

