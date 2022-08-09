CREATE PROCEDURE [dbo].[PermisosUpdate]
		@IdPermiso INT,
		@IdRol INT,
		@Mantenimiento VARCHAR(50),
		@Acceso VARCHAR(50)
		
AS

BEGIN

	SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
		UPDATE dbo.Permisos SET
			 IdRol	= @IdRol
			,Mantenimiento = @Mantenimiento
			,Acceso = @Acceso 
			
		WHERE
			IdPermiso = @IdPermiso
		
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