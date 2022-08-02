﻿CREATE TABLE [dbo].[Users]
(
	IdUsuario INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_IdUsuario PRIMARY KEY CLUSTERED(IdUsuario),
	Cedula VARCHAR(9) NOT NULL,
	Nombre VARCHAR(250) NOT NULL,
	Primer_Apellido VARCHAR(250)NOT NULL,
	Segundo_Apellido VARCHAR(250) NOT NULL,
	Nombre_Usuario VARCHAR(50) NOT NULL,
	Clave VARCHAR(50) NOT NULL
)
WITH (DATA_COMPRESSION = PAGE)
GO