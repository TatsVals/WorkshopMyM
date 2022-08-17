CREATE PROCEDURE [dbo].[PermisosList]
	AS
BEGIN 
	SET NOCOUNT ON

	SELECT 
	       IdPermiso
		 , IdRol
		 , Taller
		 
		 
	FROM
	    dbo.Permisos

END