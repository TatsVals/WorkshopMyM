CREATE PROCEDURE [dbo].[OrdenCreate]
	@NombreCliente VARCHAR(250),
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

