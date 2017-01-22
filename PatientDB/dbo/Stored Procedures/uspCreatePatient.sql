CREATE PROCEDURE [dbo].[uspCreatePatient]
    @LastName varchar(50),   
    @FirstName varchar(50),
	@IdNumber varchar(50),
	@PhoneNumber varchar(50),
	@Diseases varchar(50),
	@CountryId int,
	@BloodTypeId int
AS
    SET NOCOUNT ON;  
	
	INSERT INTO Patient (FirstName, LastName,IdNumber,PhoneNumber, Diseases,CountryId,BloodTypeId)	
	VALUES (@FirstName, @LastName,@IdNumber,@PhoneNumber, @Diseases,@CountryId,@BloodTypeId)	


