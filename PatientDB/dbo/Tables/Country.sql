CREATE TABLE [dbo].[Country] (
    [CountryId]   INT          IDENTITY (1, 1) NOT NULL,
    [CountryCode] VARCHAR (50) NULL,
    [CountryName] VARCHAR (50) NULL,
    CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED ([CountryId] ASC)
);

