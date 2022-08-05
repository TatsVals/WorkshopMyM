CREATE TABLE [dbo].[Productos]
(
	[IdProducto] INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Proveedor PRIMARY KEY CLUSTERED(IDPRODUCTO),
	[Codigo] [varchar](10) NOT NULL ,
	[Descripcion] [varchar](300) NOT NULL,
	[Unidad] [varchar](20) NOT NULL,
	[CantidadDisponible] [float] NOT NULL,
	[PrecioCompra] [float] NOT NULL,
	[PrecioVenta] [float] NOT NULL,
	[CostoTotal] [float] NOT NULL 
)
