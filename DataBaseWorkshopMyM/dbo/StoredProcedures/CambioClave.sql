CREATE PROCEDURE [dbo].[CambioClave]		 
		@Nombre_Usuario VARCHAR(30), 
		@ClaveActual VARCHAR(30),
		@ClaveNueva VARCHAR(30),
		@UsuarioLogin VARCHAR(50)
AS

BEGIN

	SET NOCOUNT ON

	BEGIN TRANSACTION TRASA
	BEGIN TRY
	DECLARE @ContrasenaActualSHA1 VARBINARY(MAX)=(SELECT HASHBYTES('SHA1',@ClaveActual));
	DECLARE @ContrasenaNuevaSHA1 VARBINARY(MAX)=(SELECT HASHBYTES('SHA1',@ClaveNueva));

	IF NOT EXISTS( SELECT Nombre_Usuario FROM dbo.Users WHERE @Nombre_Usuario=Nombre_Usuario) BEGIN
		SELECT -1 AS CodeError, 'Este Usuario no se encuentra registrado por favor revisar!' AS MsgError
	END
	ELSE IF  NOT EXISTS( SELECT * FROM Users WHERE Nombre_Usuario=@Nombre_Usuario and Clave=@ContrasenaActualSHA1 ) BEGIN
 
	SELECT -1 AS CodeError, 'La contraseña actual es incorrecta por favor volver a intentar!' AS MsgError
	END
	ELSE IF  ( @ClaveActual = @ClaveNueva ) BEGIN
 
	SELECT -1 AS CodeError, 'La contraseña nueva no puede ser la misma que la actual!' AS MsgError
	END
	 ELSE BEGIN
	
	
		UPDATE dbo.Users SET
			
			Clave	= @ContrasenaNuevaSHA1			

		WHERE
			Nombre_Usuario = @Nombre_Usuario	
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
			, 'Se cambió la clave del usuario: ' + @Nombre_Usuario
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