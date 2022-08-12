CREATE PROCEDURE [dbo].[ProductsUpdate]
	@IdProducto INT,
	@Codigo VARCHAR(10),
	@Descripcion VARCHAR(300),
	@Unidad VARCHAR(20),
	@CantidadDisponible FLOAT,
	@PrecioCompra FLOAT,
	@PrecioVenta FLOAT
	

AS
 BEGIN
  SET NOCOUNT ON

  BEGIN TRANSACTION TRASA

  BEGIN TRY

  UPDATE dbo.Productos SET
      Codigo = @Codigo
	, Descripcion = @Descripcion
	, Unidad = @Unidad
	, CantidadDisponible = @CantidadDisponible
	, PrecioCompra = @PrecioCompra
	, PrecioVenta = @PrecioVenta 
	, CostoTotal = @CantidadDisponible * @PrecioCompra
  WHERE
     IdProducto = @IdProducto

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