execute msdb.dbo.sysmail_add_profile_sp
@profile_name='EmailClave',
@description='Este perfil es utilizado para enviar claves temporales utilizando Gmail'


execute msdb.dbo.sysmail_add_principalprofile_sp
	@profile_name='EmailClave',
	@principal_name='public',
	@is_default=1


execute msdb.dbo.sysmail_add_account_sp
	@account_name='EnvioClave',
	@description='Cuenta de email utilizada para enviar claves temporales',
	@email_address='workshopmymrecuperacion@gmail.com',
	@display_name='Clave Temporal',
	@mailserver_name='smtp.gmail.com',
	@port=587,
	@enable_ssl=1,
	@username='workshopmymrecuperacion@gmail.com',
	@password='lbfdnveqyqbiljwc'

execute msdb.dbo.sysmail_add_profileaccount_sp
	@profile_name='EmailClave',
	@account_name='EnvioClave',
	@sequence_number=1
