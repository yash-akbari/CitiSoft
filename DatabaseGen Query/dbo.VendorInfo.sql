CREATE TABLE [dbo].[VendorInfo] (
    [vid]         INT             IDENTITY (1, 1) NOT NULL,
    [compName]    VARCHAR (20)    NOT NULL,
    [est]         SMALLINT        NULL,
    [empCount]    NVARCHAR (25)   NULL,
    [intProfServ] VARCHAR (3)     NULL,
    [lstDemoDt]   DATE            NULL,
    [lstRevInt]   SMALLINT        NULL,
    [lstRevDt]    DATE            NULL,
    [docAttach]   VARBINARY (MAX) NULL,
    PRIMARY KEY CLUSTERED ([vid] ASC)
);

