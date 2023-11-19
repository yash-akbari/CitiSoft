CREATE TABLE [dbo].[VendorInfo]
(
	[vid] INT NOT NULL PRIMARY KEY, 
    [compName] VARCHAR(20) NULL, 
    [compWeb] VARCHAR(40) NULL, 
    [desc] NVARCHAR(MAX) NULL, 
    [est] SMALLINT NULL, 
    [empCount] VARCHAR(20) NULL, 
    [intProfServ] BIT NULL, 
    [lstDemoDt] DATE NULL, 
    [lstRevDt] DATE NULL, 
    [cloud] BINARY(2) NULL, 
    [addnfo] NVARCHAR(MAX) NULL, 
    [docAttach] BIT NULL, 
    [finSerClieTyp] NVARCHAR(MAX) NULL
)
