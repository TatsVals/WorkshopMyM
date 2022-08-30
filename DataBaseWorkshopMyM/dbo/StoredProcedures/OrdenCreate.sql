CREATE PROCEDURE [dbo].[OrdenCreate]
	@UsuarioLogin VARCHAR(250),
	@NombreCliente VARCHAR(50),
	@PlacaVehiculo VARCHAR(50),
	@MarcaVehiculo VARCHAR(50),
	@ModeloVehiculo VARCHAR(50),
	@AnoVehiculo VARCHAR(50),
	@ManodeObra float(50),
	@Productos VARCHAR(50),
	@PrecioProductos float(50),
	@Estado VARCHAR(50)
	

AS
 BEGIN
  SET NOCOUNT ON

  BEGIN TRANSACTION TRASA

  BEGIN TRY


  INSERT INTO dbo.Ordenes
  (
     NombreCliente
  	, PlacaVehiculo		  
	, MarcaVehiculo
	, ModeloVehiculo
	, AnoVehiculo
	, ManodeObra
	, Productos
	, PrecioProductos
	, Estado
  )
  VALUES
  (
      @NombreCliente		  
	, @PlacaVehiculo
	, @MarcaVehiculo
	, @ModeloVehiculo
	, @AnoVehiculo
	, @ManodeObra
	, @Productos
	, @PrecioProductos
	, @Estado
	
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
			, 'Ordenes'
			, '=>Nombre Cliente: ' + @NombreCliente + '   =>Placa Vehículo: ' + @PlacaVehiculo +'   =>Marca Vehiculo: ' + @MarcaVehiculo + '   =>Modelo Vehículo: ' + @ModeloVehiculo + '   =>Año Vehículo: ' +  @AnoVehiculo  + '   =>Mano de Obra: ' + Convert(Varchar,@ManodeObra )+ '   =>Productos: ' + @Productos+ + '   =>Precio de Productos: ' + Convert(Varchar,@PrecioProductos )+'   =>Estado: ' + @Estado
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

