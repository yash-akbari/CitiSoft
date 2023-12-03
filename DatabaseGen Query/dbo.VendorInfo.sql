CREATE TABLE [dbo].[VendorInfo] (
    [vid]         INT             IDENTITY (1, 1) NOT NULL,
    [compName]    VARCHAR (20)    NOT NULL,
    [est]         SMALLINT        NULL,
    [empCount]    NVARCHAR (25)   NULL,
    [intProfServ] BIT             NULL,
    [docName]     NVARCHAR (20)   NULL,
	[docType]	NVARCHAR(10) NULL,
    [docAttach]   VARBINARY (MAX) NULL,
    PRIMARY KEY CLUSTERED ([vid] ASC)
);

