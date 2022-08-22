CREATE PROCEDURE [dbo].[OrdenUpdate]
	@IdOrden VARCHAR(250),
	@NombreCliente VARCHAR(250),
	@PlacaVehiculo VARCHAR(50),
	@MarcaVehiculo VARCHAR(50),
	@ModeloVehiculo VARCHAR(50),
	@AnoVehiculo VARCHAR(50),
	@ManodeObra float(50),
	@Productos VARCHAR(50),
	@PrecioProductos float(50),
	@Estado VARCHAR(50),
	@UsuarioLogin VARCHAR(50)
AS
 BEGIN
  SET NOCOUNT ON

  BEGIN TRANSACTION TRASA

  BEGIN TRY

  UPDATE dbo.Ordenes SET
      NombreCliente = @NombreCliente
	, PlacaVehiculo = @PlacaVehiculo
	, MarcaVehiculo = @MarcaVehiculo
	, ModeloVehiculo = @ModeloVehiculo
	, AnoVehiculo = @AnoVehiculo
	, ManodeObra = @ManodeObra 
	, Productos = @Productos 
	, PrecioProductos = @PrecioProductos
	, Estado = @Estado
  WHERE
     IdOrden = @IdOrden
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
			, 'Ordenes'
			, '=>NombreCliente: ' + @NombreCliente + ' =>PlacaVehiculo: ' + @PlacaVehiculo +' =>MarcaVehiculo: ' + @MarcaVehiculo + ' =>ModeloVehiculo: ' + @ModeloVehiculo + ' =>AnoVehiculo: ' + @AnoVehiculo + ' =>ManodeObra: ' + Convert(Varchar, @ManodeObra) + ' =>Productos: ' + @Productos + ' =>PrecioProductos: ' + Convert(Varchar, @PrecioProductos) + ' =>Estado: ' + @Estado
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