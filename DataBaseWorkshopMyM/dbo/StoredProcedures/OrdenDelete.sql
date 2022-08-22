CREATE PROCEDURE [dbo].[OrdenDelete]
@IdOrden INT
,@PlacaVehiculo VARCHAR(50)
,@UsuarioLogin VARCHAR(50)

AS
 BEGIN
  SET NOCOUNT ON

  BEGIN TRANSACTION TRASA

  BEGIN TRY

   DELETE FROM dbo.Ordenes
   WHERE IdOrden = @IdOrden
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
			, 'Ordenes'
			, '=>Orden placa Vehiculo: ' + @PlacaVehiculo  
		)
  COMMIT TRANSACTION TRASA
  SELECT 0 AS CodeError, '' AS MsgError

  END TRY

	  BEGIN CATCH
		SELECT 
			   ERROR_NUMBER() AS CodeError,
			   ERROR_MESSAGE() AS MsgError

	  ROLLBACK TRANSACTION TRASA
  
  END CATCH

  END 