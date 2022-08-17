CREATE PROCEDURE [dbo].[PermisosList]
	@IdRol INT 

	AS
BEGIN 
	SET NOCOUNT ON

	SELECT 
	     
		 Taller
		 ,Personal
		 ,Bitacoras
		 
		 
	FROM
	    dbo.Roles
		WHERE
	    ( IdRol = @IdRol)

END
