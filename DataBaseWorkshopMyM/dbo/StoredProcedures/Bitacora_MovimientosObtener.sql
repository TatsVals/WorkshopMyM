CREATE PROCEDURE [dbo].[Bitacora_MovimientosObtener]
AS
BEGIN
	SET NOCOUNT ON

	SELECT
		 IdMovimiento
 		,Nombre_Usuario 
		,Fecha
		,Movimiento
		,Detalle

		FROM 
			 dbo.Bitacora_Movimientos
			 
END