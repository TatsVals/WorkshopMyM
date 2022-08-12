CREATE TABLE [dbo].[Ordenes]
(
	[IdOrden] INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Orden PRIMARY KEY CLUSTERED(IdOrden),
	[NombreCliente] [varchar](250) NOT NULL ,
	[PlacaVehiculo] [varchar](50) NOT NULL,
	[MarcaVehiculo] [varchar](50) NOT NULL,
	[ModeloVehiculo] [varchar](50) NOT NULL,
	[AnoVehiculo] [varchar](50) NOT NULL,
	[ManodeObra] [varchar](50) NOT NULL,
	[Productos] [varchar](50) NOT NULL, 
	[Estado] [Bit] NOT NULL,
)
