CREATE PROCEDURE [dbo].[spEmployee_Update]
	@Id int,
	@FirstName nvarchar(50),
	@MiddleName nvarchar(50),
	@LastName nvarchar(50)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE dbo.[Employee]
	SET FirstName = @FirstName,
		MiddleName = @MiddleName,
		LastName = @LastName
	WHERE Id = @Id

END