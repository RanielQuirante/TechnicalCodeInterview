CREATE PROCEDURE [dbo].[spEmployee_All]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, FirstName, MiddleName, LastName
	FROM dbo.Employee;

END
