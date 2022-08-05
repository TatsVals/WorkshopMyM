CREATE PROCEDURE [dbo].[ProductsCreate]
	@Codigo VARCHAR(10),
	@Descripcion VARCHAR(300),
	@Unidad VARCHAR(20),
	@CantidadDisponible FLOAT,
	@PrecioCompra FLOAT,
	@PrecioVenta FLOAT,
	@CostoTotal FLOAT 

AS
 BEGIN
  SET NOCOUNT ON

  BEGIN TRANSACTION TRASA

  BEGIN TRY


  INSERT INTO dbo.Productos
  (
     Codigo
  	, Descripcion		  
	, Unidad
	, CantidadDisponible
	, PrecioCompra
	, PrecioVenta
	, CostoTotal  
  )
  VALUES
  (
      @Codigo		  
	, @Descripcion
	, @Unidad
	, @CantidadDisponible
	, @PrecioCompra
	, @PrecioVenta
	, @CostoTotal
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

