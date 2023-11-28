CREATE TABLE [dbo].[CustAddress] (
    [addressId]    INT           IDENTITY (1, 1) NOT NULL,
    [cid]          INT           NOT NULL,
    [phone]        NVARCHAR (15) NULL,
    [email]        NVARCHAR (30) NULL,
    [AddressLine1] NVARCHAR (30) NULL,
    [AddressLine2] NVARCHAR (30) NULL,
    [City]         NVARCHAR (30) NULL,
    [Country]      NVARCHAR (30) NULL,
    [PostCode]     NVARCHAR (30) NULL,
    CONSTRAINT [FK_CustAddress_Client] FOREIGN KEY ([cid]) REFERENCES [dbo].[Client] ([cid]) ON DELETE CASCADE, 
    CONSTRAINT [PK_CustAddress] PRIMARY KEY ([addressId])
);

