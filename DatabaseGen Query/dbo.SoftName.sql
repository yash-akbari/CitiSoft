CREATE TABLE [dbo].[SoftName] (
    [vid]      INT            NOT NULL,
    [sid]      INT            IDENTITY (1, 1) NOT NULL,
    [SoftName] VARCHAR (30)   NOT NULL,
    [softWeb]  VARCHAR (40)   NULL,
    [desc]     NVARCHAR (255) NULL,
    [cloud]    NVARCHAR (10)  NULL,
    [addInfo]  NVARCHAR (255) NULL,
    CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED ([sid] ASC),
    CONSTRAINT [FK_SoftName_VendorInfo] FOREIGN KEY ([vid]) REFERENCES [dbo].[VendorInfo] ([vid]) ON DELETE CASCADE
);

