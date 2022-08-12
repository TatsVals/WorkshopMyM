CREATE PROCEDURE [dbo].[PermisosCreate]
 
		@IdRol INT,
		@Mantenimiento VARCHAR(50)
		
		
AS
BEGIN
	
	SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
		INSERT INTO	dbo.Permisos
		(
			 IdRol 
			,Mantenimiento 
			 
			
		)
		VALUES
		(
			 @IdRol 
			,@Mantenimiento 
			 
			
		)

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