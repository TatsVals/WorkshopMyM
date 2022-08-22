CREATE PROCEDURE [dbo].[ProductsDelete]
  @UsuarioLogin VARCHAR (50),
  @Codigo VARCHAR (50),
  @IdProducto INT

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
			,Tabla
		    ,Detalle
		)
		VALUES
		(
			 @UsuarioLogin
			,GETDATE()		
			, 'DELETE'
			,'Productos'
			, 'Producto código ' + @Codigo  + ' eliminado'
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