CREATE PROCEDURE [dbo].[Logout]

AS 
BEGIN
SET NOCOUNT  ON

BEGIN
	
	
	TRY	
		
		
		UPDATE	dbo.BitacoraIngresos
		SET
			 FechaSalida = CAST(GETDATE()AS VARCHAR)

		WHERE FechaSalida = 'Usuario En Sesión'
		SELECT 0 AS CodeError, '' as MsgError


	END TRY

	BEGIN CATCH
		SELECT 
			ERROR_NUMBER() AS CodeRrror,
			ERROR_MESSAGE() AS MsgError

		ROLLBACK TRANSACTION TRASA
	END CATCH
END
