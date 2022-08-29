CREATE PROCEDURE [dbo].[ProductsUpdate]
	@UsuarioLogin VARCHAR(50),
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
  IF EXISTS( SELECT Codigo FROM dbo.Productos WHERE @Codigo=Codigo) AND (@Codigo != (SELECT Codigo FROM dbo.Productos WHERE @IdProducto=IdProducto)) BEGIN
		SELECT -1 AS CodeError, 'Este rol se encuentra registrado por favor ingresar otra cedula!' AS MsgError
	END
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
			,Tabla
		    ,Detalle
		)
		VALUES
		(
			 @UsuarioLogin
			,GETDATE()
			, 'UPDATE'
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