CREATE TABLE [dbo].[SoftTypes] (
    [softTypesId] INT           IDENTITY (1, 1) NOT NULL,
    [sid]         INT           NOT NULL,
    [softTypes]   NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([softTypesId] ASC),
    CONSTRAINT [FK_SoftType_SoftName] FOREIGN KEY ([sid]) REFERENCES [dbo].[SoftName] ([sid]) ON DELETE CASCADE
);

