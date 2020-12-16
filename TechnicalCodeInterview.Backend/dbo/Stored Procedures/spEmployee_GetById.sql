CREATE PROCEDURE [dbo].[spEmployee_GetById]
	@Id int
AS
BEGIN

	SET NOCOUNT ON;

	SELECT Id, FirstName, MiddleName, LastName
	FROM dbo.[Employee]
	WHERE Id = @Id

END
