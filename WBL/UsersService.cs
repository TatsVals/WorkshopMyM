using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IUsersService
    {
        Task<DBEntity> Create(UsersEntity entity);
        Task<DBEntity> Delete(UsersEntity entity);
        Task<IEnumerable<UsersEntity>> Get();
        Task<UsersEntity> GetById(UsersEntity entity);
        Task<UsersEntity> Login(UsersEntity entity);
        Task<DBEntity> Logout();
        Task<DBEntity> Update(UsersEntity entity);
    }

    public class UsersService : IUsersService
    {
        private readonly IDataAccess sql;

        public UsersService(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<UsersEntity> Login(UsersEntity entity)
        {
            try
            {
                var result = await sql.QueryFirstAsync<UsersEntity>("Login", new
                {

                    entity.Nombre_Usuario,
                    entity.Clave

                });

                return result;


            }
            catch (Exception ex)
            {

                throw;
            }


        }



        public async Task<DBEntity> Logout()
        {
            try
            {
                var result = await sql.QueryFirstAsync<UsersEntity>("Logout");
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        #region MetodosCRUD

        // Metodo GET
        public async Task<IEnumerable<UsersEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<UsersEntity, RolesEntity>("dbo.UsersObtener", "IdUsuario, IdRol");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        //Metodo GetById
        public async Task<UsersEntity> GetById(UsersEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<UsersEntity>("dbo.UsersObtener", new { entity.IdUsuario });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }



        //Metodo Create
        public async Task<DBEntity> Create(UsersEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.UsersInsertar", new
                {
                     entity.Cedula
                    ,entity.Nombre
                    ,entity.Primer_Apellido
                    ,entity.Segundo_Apellido
                    ,entity.Nombre_Usuario
                    ,entity.Clave
                    ,entity.IdRol
                    ,entity.UsuarioLogin

                }
                    );

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        //Metodo Update
        public async Task<DBEntity> Update(UsersEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.UsersActualizar", new
                {
                     entity.IdUsuario
                    ,entity.Cedula
                    ,entity.Nombre
                    ,entity.Primer_Apellido
                    ,entity.Segundo_Apellido
                    ,entity.Nombre_Usuario
                    ,entity.Clave
                    ,entity.IdRol
                    ,entity.UsuarioLogin

                }
                    );

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        //Metodo Delete
        public async Task<DBEntity> Delete(UsersEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.UsersEliminar", new
                {
                    entity.IdUsuario                  
                   ,entity.Cedula
                   ,entity.UsuarioLogin
                }
                 );

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

    }
}
