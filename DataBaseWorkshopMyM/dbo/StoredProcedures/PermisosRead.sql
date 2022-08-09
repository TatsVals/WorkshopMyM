CREATE PROCEDURE [dbo].[PermisosRead]
		@IdPermiso INT = NULL
AS
BEGIN
	SET NOCOUNT ON

	SELECT
		 P.IdPermiso
		,R.IdRol
		,P.Mantenimiento 
		,P.Acceso
		,R.IdRol
		,R.Rol

		FROM 
			 dbo.Permisos P
		INNER JOIN dbo.Roles R
		ON P.IdRol = R.IdRol
		WHERE
			(@IdPermiso IS NULL OR P.IdPermiso = @IdPermiso)
END
