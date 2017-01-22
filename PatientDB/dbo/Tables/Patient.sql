CREATE TABLE [dbo].[Patient] (
    [PatientId]   INT          IDENTITY (1, 1) NOT NULL,
    [IdNumber]    VARCHAR (50) NULL,
    [FirstName]   VARCHAR (50) NULL,
    [LastName]    VARCHAR (50) NULL,
    [DateOfBirth] VARCHAR (50) NULL,
    [CountryId]   INT          NULL,
    [Diseases]    VARCHAR (50) NULL,
    [PhoneNumber] VARCHAR (50) NULL,
    [BloodTypeId] INT          NULL,
    CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED ([PatientId] ASC)
);

