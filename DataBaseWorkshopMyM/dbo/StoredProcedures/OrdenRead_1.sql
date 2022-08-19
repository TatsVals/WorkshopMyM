CREATE PROCEDURE [dbo].[OrdenRead]
    
    @IdOrden INT = NULL
AS
BEGIN
    SET NOCOUNT ON



   SELECT
      IdOrden
    , NombreCliente
      , PlacaVehiculo          
    , MarcaVehiculo
    , ModeloVehiculo
    , AnoVehiculo
    , ManodeObra
    , Productos  
    , Estado
    FROM
        dbo.Ordenes
    WHERE
        (@IdOrden IS NULL OR IdOrden = @IdOrden)
          



END
