CREATE PROCEDURE [dbo].[RolesRead]
@IdRol INT = NULL
AS
BEGIN 
	SET NOCOUNT ON

	SELECT 
	  Rol
	  
	FROM
	    dbo.Roles
	WHERE
	    (@IdRol IS NULL OR IdRol = @IdRol)
	      

END