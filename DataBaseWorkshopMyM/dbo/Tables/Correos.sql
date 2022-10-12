CREATE TABLE [dbo].[Correos]
(
	IdCorreo INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Correo PRIMARY KEY CLUSTERED([IdCorreo]),
	CorreoEnvio varchar(250),
	Pase varchar(250)
)
