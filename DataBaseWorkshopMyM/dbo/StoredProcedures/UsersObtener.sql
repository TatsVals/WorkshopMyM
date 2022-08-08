CREATE PROCEDURE [dbo].[UsersObtener]
	@IdUsuario INT = NULL
AS
BEGIN
	SET NOCOUNT ON

	SELECT
		 IdUsuario
		,Cedula 
		,Nombre 
		,Primer_Apellido 
		,Segundo_Apellido 
		,Nombre_Usuario 
		,Clave
		,IdRol

		FROM 
			dbo.Users
		WHERE
			(@IdUsuario IS NULL OR IdUsuario = @IdUsuario)
END
