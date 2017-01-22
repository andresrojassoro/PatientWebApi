CREATE PROCEDURE uspDeletePatient
	@PatientId varchar(50)

AS
    SET NOCOUNT ON;  
	
	Delete Patient
	WHERE PatientId = @PatientId
