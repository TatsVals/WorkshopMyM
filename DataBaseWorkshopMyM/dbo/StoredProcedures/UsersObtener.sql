CREATE PROCEDURE [dbo].[UsersObtener]
	@IdUsuario INT = NULL
	
AS
BEGIN

	SET NOCOUNT ON
		 

	SELECT
	
		 U.IdUsuario
		,U.Cedula 
		,U.Nombre 
		,U.Primer_Apellido 
		,U.Segundo_Apellido 
		,U.Nombre_Usuario 
		,'***************'
		,R.IdRol
		,R.Rol

		FROM 
			 dbo.Users U
		INNER JOIN dbo.Roles R
		ON U.IdRol = R.IdRol
		WHERE
			(@IdUsuario IS NULL OR U.IdUsuario = @IdUsuario)
END


