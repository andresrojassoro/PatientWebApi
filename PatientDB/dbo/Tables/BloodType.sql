CREATE TABLE [dbo].[BloodType] (
    [BloodTypeID]   INT          IDENTITY (1, 1) NOT NULL,
    [BloodTypeCode] VARCHAR (50) NULL,
    [BloodTypeName] VARCHAR (50) NULL,
    CONSTRAINT [PK_BloodType] PRIMARY KEY CLUSTERED ([BloodTypeID] ASC)
);

