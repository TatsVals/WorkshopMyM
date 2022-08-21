CREATE PROCEDURE [dbo].[Logout]

AS 
BEGIN
SET NOCOUNT  ON

BEGIN
	
	
	TRY	
		
		
		UPDATE	dbo.BitacoraIngresos
		SET
			 FechaSalida = GETDATE()

		WHERE NombreUsuario = (SELECT NombreUsuario FROM BitacoraIngresos WHERE FechaSalida = '11/11/11') and FechaSalida = '11/11/11' 
		SELECT 0 AS CodeError, '' as MsgError


	END TRY

	BEGIN CATCH
		SELECT 
			ERROR_NUMBER() AS CodeRrror,
			ERROR_MESSAGE() AS MsgError

		ROLLBACK TRANSACTION TRASA
	END CATCH
END
