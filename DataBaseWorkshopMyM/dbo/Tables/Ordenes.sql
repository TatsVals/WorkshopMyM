CREATE TABLE [dbo].[Ordenes]
(
	[IdOrden] INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Orden PRIMARY KEY CLUSTERED(IdOrden),
	[NombreCliente] [varchar](250) NOT NULL ,
	[PlacaVehiculo] [varchar](50) NOT NULL,
	[MarcaVehiculo] [varchar](50) NOT NULL,
	[ModeloVehiculo] [varchar](50) NOT NULL,
	[AnoVehiculo] [varchar](50) NOT NULL,
	[ManodeObra] [float](50) NOT NULL,
	[Productos] [varchar](150) NOT NULL, 
	[PrecioProductos] [float](50) NOT NULL,
	[Estado] [varchar](50) NOT NULL,
)
