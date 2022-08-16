CREATE PROCEDURE [dbo].[UsersEliminar]
	@IdUsuario INT
   ,@Cedula VARCHAR(50)
   ,@UsuarioLogin VARCHAR(50)

AS
BEGIN
	
	SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY

		DELETE FROM dbo.Users WHERE IdUsuario=@IdUsuario

		
		
		SELECT 0 AS CodeError, '' as MsgError
		INSERT INTO	dbo.Bitacora_Movimientos
		(
			 Nombre_Usuario
			,Fecha
			,Movimiento
		    ,Detalle
		)
		VALUES
		(
			 @UsuarioLogin
			,GETDATE()
			, 'DELETE', 'Usuario Cedula: ' + @Cedula  
		)
		COMMIT TRANSACTION TRASA
	END TRY

	BEGIN CATCH
		SELECT 
			ERROR_NUMBER() AS CodeRrror,
			ERROR_MESSAGE() AS MsgError

		ROLLBACK TRANSACTION TRASA
	END CATCH

END
