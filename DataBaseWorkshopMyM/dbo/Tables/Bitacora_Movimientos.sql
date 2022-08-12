﻿CREATE TABLE [dbo].[Bitacora_Movimientos]
(
	IdMovimiento INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_IdMovimiento PRIMARY KEY CLUSTERED(IdMovimiento),
	Nombre_Usuario VARCHAR(50) NOT NULL,
	Fecha DateTime NOT NULL,
	Movimiento VARCHAR(50) NOT NULL,
	Detalle VARCHAR(100) NOT NULL
)