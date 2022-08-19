CREATE PROCEDURE [dbo].[OrdenCreate]
	@NombreCliente VARCHAR(250),
	@PlacaVehiculo VARCHAR(50),
	@MarcaVehiculo VARCHAR(50),
	@ModeloVehiculo VARCHAR(50),
	@AnoVehiculo VARCHAR(50),
	@ManodeObra VARCHAR(50),
	@Productos VARCHAR(50),
	@Estado BIT,
	@UsuarioLogin VARCHAR(50)
	

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
	, @Estado
	
  )

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
			, 'INSERT'
			, '=>Nombre Cliente: ' + @NombreCliente + '   =>Placa Vehículo: ' + @PlacaVehiculo +'   =>Marca Vehiculo: ' + @MarcaVehiculo + '   =>Modelo Vehículo: ' + @ModeloVehiculo + '   =>Año Vehículo: ' +  @AnoVehiculo  + '   =>Mano de Obra: ' + @ManodeObra+ '   =>Productos: ' + @Productos+ '   =>Estado: ' + Convert(Varchar, @Estado)
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

