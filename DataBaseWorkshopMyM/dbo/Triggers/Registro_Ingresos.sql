﻿--CREATE TRIGGER [Registro_Ingresos]
--	ON dbo.Users 
--	AFTER INSERT
--	AS
--	BEGIN
--		SET NOCOUNT ON
--		INSERT INTO Bitacora_Ingresos (IdUsuario, Fecha_Ingreso, Fecha_Salida)
--		Select
--			 U.Nombre_Usuario
--			,B.Fecha_Ingreso
--			,B.Fecha_Salida
--		FROM dbo.Users U INNER JOIN dbo.Bitacora_Ingresos B
--		ON U.IdUsuario = B.IdUsuario
		
--	END
