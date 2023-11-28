CREATE TABLE [dbo].[Client] (
    [cid]      INT        IDENTITY (1, 1) NOT NULL,
    [compName] NCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([cid] ASC)
);

