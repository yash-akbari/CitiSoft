CREATE TABLE [dbo].[Accessibility] (
    [uid]        INT     NOT NULL,
    [VendorInfo] TINYINT NULL,
    [softName]   TINYINT NULL,
    [comment]    TINYINT NULL,
    [Customer]   TINYINT NULL,
    [Problem]    TINYINT NULL,
    [user]       TINYINT NULL,
    PRIMARY KEY CLUSTERED ([uid] ASC),
    CONSTRAINT [FK_Accessibility_User] FOREIGN KEY ([uid]) REFERENCES [dbo].[User] ([uid]) ON DELETE CASCADE
);

