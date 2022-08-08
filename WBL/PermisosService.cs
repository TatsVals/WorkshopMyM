using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;

namespace WBL
{
   

    public class PermisosService 
    {
        private readonly IDataAccess sql;

        public PermisosService(IDataAccess _sql)
        {
            sql = _sql;
        }


        #region MetodosCRUD

        // Metodo GET
        public async Task<IEnumerable<PermisosEntity>> Get()
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
                    ,
                    entity.Nombre
                    ,
                    entity.Primer_Apellido
                    ,
                    entity.Segundo_Apellido
                    ,
                    entity.Nombre_Usuario
                    ,
                    entity.Clave
                    ,
                    entity.IdRol

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
                    ,
                    entity.Cedula
                    ,
                    entity.Nombre
                    ,
                    entity.Primer_Apellido
                    ,
                    entity.Segundo_Apellido
                    ,
                    entity.Nombre_Usuario
                    ,
                    entity.Clave
                    ,
                    entity.IdRol

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
