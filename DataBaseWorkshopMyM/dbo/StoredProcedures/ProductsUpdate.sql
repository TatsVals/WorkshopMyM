CREATE PROCEDURE [dbo].[ProductsUpdate]
	@IdProducto INT,
	@Codigo VARCHAR(10),
	@Descripcion VARCHAR(300),
	@Unidad VARCHAR(20),
	@CantidadDisponible FLOAT,
	@PrecioCompra FLOAT,
	@PrecioVenta FLOAT,
	@UsuarioLogin VARCHAR(50)

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
			, 'UPDATE'
			, '=>Codigo: ' + Convert(Varchar, @Codigo) + '   =>Descripcion: ' + @Descripcion +'   =>Unidad: ' + @Unidad + '   =>Cantidad Disponible: ' + Convert(Varchar, @CantidadDisponible) + '   =>Precio de Compra: ' + Convert(Varchar, @PrecioCompra)  + '   =>Precio de Venta: ' + Convert(Varchar, @PrecioVenta)+ '   =>Costo Total: ' + Convert(Varchar, @CantidadDisponible * @PrecioCompra)
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