CREATE PROCEDURE [dbo].[BitacoraIngresosRead]
AS
BEGIN
	SET NOCOUNT ON

	SELECT
		 IdIngreso
 		,NombreUsuario 
		,FechaIngreso
		,FechaSalida
		

		FROM 
			 dbo.BitacoraIngresos
			 
END