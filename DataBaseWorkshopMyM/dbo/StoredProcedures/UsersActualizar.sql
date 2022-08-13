CREATE PROCEDURE [dbo].[UsersActualizar]
		@IdUsuario INT,
		@Cedula VARCHAR(9), 
		@Nombre VARCHAR(250),
		@Primer_Apellido VARCHAR(250),
		@Segundo_Apellido VARCHAR(250), 
		@Nombre_Usuario VARCHAR(30), 
		@Clave VARCHAR(30),
		@IdRol INT
AS

BEGIN

	SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
		UPDATE dbo.Users SET
			 Cedula	= @Cedula
			,Nombre = @Nombre
			,Primer_Apellido = @Primer_Apellido 
			,Segundo_Apellido = @Segundo_Apellido 
			,Nombre_Usuario = @Nombre_Usuario
			,Clave	= ENCRYPTBYPASSPHRASE('password', @Clave)
			,IdRol = @IdRol
		WHERE
			IdUsuario = @IdUsuario	
		
		COMMIT TRANSACTION TRASA
		SELECT 0 AS CodeError, '' as MsgError
	END TRY

	BEGIN CATCH
		SELECT 
			ERROR_NUMBER() AS CodeRrror,
			ERROR_MESSAGE() AS MsgError

		ROLLBACK TRANSACTION TRASA
	END CATCH

END