CREATE TABLE [dbo].[Address] (
    [addressId]    INT           IDENTITY (1, 1) NOT NULL,
    [vid]          INT           NOT NULL,
    [addressLine1] NVARCHAR (30) NULL,
    [addressLine2] NVARCHAR (30) NULL,
    [City]         NVARCHAR (20) NULL,
    [Country]      NVARCHAR (20) NULL,
    [Postcode]     NVARCHAR (12) NULL,
    [Email]        NVARCHAR (50) NULL,
    [Telephone]    NVARCHAR (15) NULL,
    PRIMARY KEY CLUSTERED ([addressId] ASC),
    CONSTRAINT [FK_Address_VendorInfo] FOREIGN KEY ([vid]) REFERENCES [dbo].[VendorInfo] ([vid]) ON DELETE CASCADE
);

