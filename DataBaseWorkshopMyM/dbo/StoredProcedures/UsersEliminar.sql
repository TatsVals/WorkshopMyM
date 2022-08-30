CREATE PROCEDURE [dbo].[UsersEliminar]
	@IdUsuario INT
   ,@Cedula VARCHAR(50)
   ,@UsuarioLogin VARCHAR(50)

AS
BEGIN
	
	SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	
	BEGIN TRY
  IF ( @IdUsuario != 1) BEGIN
		DELETE FROM dbo.Users WHERE IdUsuario=@IdUsuario
		INSERT INTO	dbo.Bitacora_Movimientos
		(
			 Nombre_Usuario
			,Fecha
			,Movimiento
			,Tabla
		    ,Detalle
		)
		VALUES
		(
			 @UsuarioLogin
			,GETDATE()
			, 'DELETE'
			, 'Usuarios'
			,'=>Usuario Cedula: ' + @Cedula  
		)
		
		END 
  ELSE BEGIN 
  SELECT -1 AS CodeError, 'Este Usuario no se puede borrar' AS MsgError

  
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
