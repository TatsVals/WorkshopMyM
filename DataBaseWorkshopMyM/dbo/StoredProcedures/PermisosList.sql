CREATE PROCEDURE [dbo].[PermisosList]
	@Rol INT 

	AS
BEGIN 
	SET NOCOUNT ON

	SELECT 
	     
		 Taller
		 
		 
	FROM
	    dbo.Permisos
		WHERE
	    ( IdRol = @Rol)

END
