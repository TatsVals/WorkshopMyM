CREATE PROCEDURE [dbo].[PermisosList]
	AS
BEGIN 
	SET NOCOUNT ON

	SELECT 
	       IdPermiso
		 , IdRol
		 , Mantenimiento
		 
		 
	FROM
	    dbo.Permisos

END