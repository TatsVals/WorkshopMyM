CREATE PROCEDURE [dbo].[UsersActualizar]
		@IdUsuario INT,
		@Cedula VARCHAR(9), 
		@Nombre VARCHAR(250),
		@Primer_Apellido VARCHAR(250),
		@Segundo_Apellido VARCHAR(250), 
		@Nombre_Usuario VARCHAR(30), 		
		@IdRol INT,
		@UsuarioLogin VARCHAR(50)
AS

BEGIN

	SET NOCOUNT ON

	BEGIN TRANSACTION TRASA
	BEGIN TRY
	
  IF ( @IdUsuario = 1) BEGIN
  SELECT -1 AS CodeError, 'Este Usuario no se puede Editar' AS MsgError
  END
	ELSE IF EXISTS( SELECT Cedula FROM dbo.Users WHERE @Cedula=Cedula) AND (@Cedula != (SELECT Cedula FROM dbo.Users WHERE @IdUsuario=IdUsuario)) BEGIN
		SELECT -1 AS CodeError, 'Esta Cedula se encuentra registrada por favor ingresar otra cedula!' AS MsgError
	END
	ELSE IF EXISTS( SELECT @Nombre_Usuario FROM dbo.Users WHERE @Nombre_Usuario=Nombre_Usuario) AND (@Nombre_Usuario != (SELECT Nombre_Usuario FROM dbo.Users WHERE @IdUsuario=IdUsuario)) BEGIN
		SELECT -1 AS CodeError, 'Este Usuario se encuentra en uso por favor ingresar otro usuario!' AS MsgError
	END
	 ELSE BEGIN
	
	
		UPDATE dbo.Users SET
			 Cedula	= @Cedula
			,Nombre = @Nombre
			,Primer_Apellido = @Primer_Apellido 
			,Segundo_Apellido = @Segundo_Apellido 
			,Nombre_Usuario = @Nombre_Usuario			
			,IdRol = @IdRol
		WHERE
			IdUsuario = @IdUsuario	
		INSERT INTO	dbo.Bitacora_Movimientos
		(
			 Nombre_Usuario
			,Fecha, Movimiento
			,Tabla
		    ,Detalle
		)
		VALUES
		(
			 @UsuarioLogin
			,GETDATE()
			, 'UPDATE'
			,'Usuarios'
			, '=>Cedula: ' + @Cedula + ' =>Nombre: ' + @Nombre +' =>Apellidos: ' + @Primer_Apellido + ' ' + @Segundo_Apellido + ' =>Usuario: ' + @Nombre_Usuario
		)
		END
	
		
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