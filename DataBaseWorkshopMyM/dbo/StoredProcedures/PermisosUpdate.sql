CREATE PROCEDURE [dbo].[PermisosUpdate]
		@IdPermiso INT,
		@IdRol INT,
		@Taller VARCHAR(50)= '',	
		@AccesoTaller BIT
		
AS

BEGIN

	SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
	IF (@AccesoTaller = 1) BEGIN SET @Taller = 'Acceso Taller' END
	ELSE BEGIN  SET @Taller = 'Sin Acceso a Taller' END

		UPDATE dbo.Permisos SET
			 IdRol	= @IdRol
			,Taller = @Taller
			
			
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