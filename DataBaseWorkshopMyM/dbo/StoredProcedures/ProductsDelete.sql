CREATE PROCEDURE [dbo].[ProductsDelete]
   @IdProducto INT
  ,@Codigo varchar(10)
  ,@UsuarioLogin VARCHAR(50)

AS
 BEGIN
  SET NOCOUNT ON

  BEGIN TRANSACTION TRASA

  BEGIN TRY

   DELETE FROM dbo.Productos
   WHERE IdProducto = @IdProducto

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
			, 'DELETE', 'Producto código ' + @Codigo  + ' eliminado'
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