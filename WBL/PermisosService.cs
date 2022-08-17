using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;

namespace WBL
{
    public interface IPermisosService
    {
        Task<DBEntity> Create(PermisosEntity entity);
        Task<DBEntity> Delete(PermisosEntity entity);
        Task<IEnumerable<PermisosEntity>> Get();
        Task<PermisosEntity> GetById(PermisosEntity entity);
        Task<IEnumerable<string>> GETLISTA(int IdRol);
        Task<DBEntity> Update(PermisosEntity entity);
    }

    public class PermisosService : IPermisosService
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
                var result = sql.QueryAsync<PermisosEntity, RolesEntity>("dbo.PermisosRead", "IdPermiso, IdRol");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        //Metodo GetById
        public async Task<PermisosEntity> GetById(PermisosEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<PermisosEntity>("dbo.PermisosRead", new { entity.IdPermiso });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }



        //Metodo Create
        public async Task<DBEntity> Create(PermisosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.PermisosCreate", new
                {
                    entity.IdRol
                    ,
                    entity.AccesoTaller




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
        public async Task<DBEntity> Update(PermisosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.PermisosUpdate", new
                {
                    entity.IdPermiso
                    ,
                    entity.IdRol
                    ,
                    entity.AccesoTaller



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
        public async Task<DBEntity> Delete(PermisosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.PermisosDelete", new
                {
                    entity.IdPermiso

                }
                    );

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<String>> GETLISTA(int IdRol)
        {
            try
            {
                var result = sql.QueryAsync<String>("dbo.PermisosList", IdRol);
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
