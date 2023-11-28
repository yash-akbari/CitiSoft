CREATE TABLE [dbo].[ClientTypes] (
    [clientTypesId]  INT           IDENTITY (1, 1) NOT NULL,
    [sid]            INT           NOT NULL,
    [finSerCliTypes] NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([clientTypesId] ASC),
    CONSTRAINT [FK_ClientTypes_SoftName] FOREIGN KEY ([sid]) REFERENCES [dbo].[SoftName] ([sid]) ON DELETE CASCADE
);

