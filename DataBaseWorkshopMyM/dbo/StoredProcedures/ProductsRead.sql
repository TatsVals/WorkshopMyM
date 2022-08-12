CREATE PROCEDURE [dbo].[ProductsRead]
	@IdProducto INT = NULL
AS
BEGIN 
	SET NOCOUNT ON

	SELECT 
	  IdProducto
	, Codigo
  	, Descripcion		  
	, Unidad
	, CantidadDisponible
	, PrecioCompra
	, PrecioVenta
	, CostoTotal  
	FROM
	    dbo.Productos
	WHERE
	    (@IdProducto IS NULL OR IdProducto = @IdProducto)
	      

END
