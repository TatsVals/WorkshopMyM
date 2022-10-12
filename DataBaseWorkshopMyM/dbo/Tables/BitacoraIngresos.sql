CREATE TABLE [dbo].[BitacoraIngresos]
(
	IdIngreso INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_IdIngreso PRIMARY KEY CLUSTERED(IdIngreso),
	NombreUsuario VARCHAR(50) NOT NULL,
	FechaIngreso DateTime NOT NULL,
	FechaSalida VARCHAR(50) 
)
