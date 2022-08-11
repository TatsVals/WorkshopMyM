CREATE TABLE [dbo].[Bitacora_Ingresos]
(
	IdIngreso INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_IdIngreso PRIMARY KEY CLUSTERED(IdIngreso),
	Nombre_Usuario VARCHAR(50) NOT NULL,
	Fecha_Ingreso DateTime NOT NULL,
	Fecha_Salida DateTime NOT NULL
)
