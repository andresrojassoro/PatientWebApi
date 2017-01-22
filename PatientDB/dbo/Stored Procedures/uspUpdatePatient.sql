CREATE PROCEDURE [dbo].[uspUpdatePatient]
	@PatientId int,
    @FirstName varchar(50),
	@LastName varchar(50),   
	@IdNumber varchar(50),
	@PhoneNumber varchar(50),
	@Diseases varchar(50),
	@CountryId int,
	@BloodTypeId int

AS
    SET NOCOUNT ON;  
	
	UPDATE Patient
	SET FirstName = @FirstName, 
	LastName = @LastName,
	IdNumber = @IdNumber,
	PhoneNumber = @PhoneNumber,
	Diseases = @Diseases,
	CountryId = @CountryId,
	BloodTypeId = @BloodTypeId
	WHERE PatientId = @PatientId
