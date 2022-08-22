CREATE PROCEDURE [dbo].[ProductsCreate]
	@UsuarioLogin VARCHAR(10),
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
	, @CantidadDisponible * @PrecioCompra
  )
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
			, 'INSERT'
			, 'Productos'
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

