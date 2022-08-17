CREATE PROCEDURE [dbo].[PermisosList]
	@IdRol INT 

	AS
BEGIN 
	SET NOCOUNT ON

	SELECT 
	     
		 Taller
		 
		 
	FROM
	    dbo.Roles
		WHERE
	    ( IdRol = @IdRol)

END
