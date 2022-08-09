CREATE PROCEDURE [dbo].[PermisosList]
	AS
BEGIN 
	SET NOCOUNT ON

	SELECT 
	       IdPermiso
		 , IdRol
		 , Mantenimiento
		 , Acceso
		 
	FROM
	    dbo.Permisos

END