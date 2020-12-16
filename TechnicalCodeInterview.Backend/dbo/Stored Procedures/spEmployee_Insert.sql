CREATE PROCEDURE [dbo].[spEmployee_Insert]
	@FirstName nvarchar(50),
	@MiddleName nvarchar(50),
	@LastName nvarchar(50)
AS
BEGIN
	
	SET NOCOUNT ON;
	
	INSERT INTO dbo.[Employee](FirstName, MiddleName, LastName)
	VALUES (@FirstName, @MiddleName, @LastName)

END
