CREATE PROCEDURE [dbo].[RolesList]
AS
BEGIN 
	SET NOCOUNT ON

	SELECT 
	       IdRol
		 , Rol
		 
	FROM
	    dbo.Roles

END