﻿CREATE PROCEDURE [dbo].[uspGetPatients]
AS   

   SELECT p.PatientId, p.FirstName, p.LastName, p.DateOfBirth,  p.Diseases, p.PhoneNumber, c.CountryId, C.CountryName, b.BloodTypeID, B.BloodTypeName
   FROM Patient as p
   LEFT JOIN Country as c on p.CountryId = c.CountryId
   LEFT JOIN BloodType as b on p.CountryId = b.BloodTypeID
