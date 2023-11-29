CREATE TABLE [dbo].[User] (
    [uid]   INT           IDENTITY (1, 1) NOT NULL,
    [fn]    NVARCHAR (30) NOT NULL,
    [ln]    NVARCHAR (30) NOT NULL,
    [phone] NVARCHAR (15) NOT NULL,
    [email] NVARCHAR (50) NOT NULL,
    [pwd]   NVARCHAR (30) NOT NULL,
    [uType] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([uid] ASC)
);

