using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;

namespace WBL
{
    public interface IRolesService
    {
        Task<DBEntity> CREATE(RolesEntity entity);
        Task<DBEntity> DELETE(RolesEntity entity);
        Task<IEnumerable<RolesEntity>> GET();
        Task<RolesEntity> GETBYID(RolesEntity entity);
        Task<IEnumerable<RolesEntity>> GETLISTA();

Task<RolesEntity> GETPERMISOS(int IdRol);
        Task<DBEntity> UPDATE(RolesEntity entity);
    }

    public class RolesService : IRolesService
    {
        private readonly IDataAccess sql;

        public RolesService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region MetodosCRUD

        //Metodo Get
        public async Task<IEnumerable<RolesEntity>> GET()
        {
            try
            {
                var result = sql.QueryAsync<RolesEntity>("dbo.RolesRead");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        //MetodoGetById
        public async Task<RolesEntity> GETBYID(RolesEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<RolesEntity>("dbo.RolesRead", new { entity.IdRol });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        //Metodo Create
        public async Task<DBEntity> CREATE(RolesEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.RolesCreate", new
                {
                    entity.Rol,
                    entity.AccesoTaller,
                    entity.AccesoPersonal,
                    entity.AccesoBitacoras

                });


                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        //Metodo Update
        public async Task<DBEntity> UPDATE(RolesEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.RolesUpdate", new
                {
                    entity.IdRol,
                    entity.Rol,
                    entity.AccesoTaller,
                    entity.AccesoPersonal,
                    entity.AccesoBitacoras
                });


                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Delete
        public async Task<DBEntity> DELETE(RolesEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.RolesDelete", new
                {
                    entity.IdRol

                });


                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<RolesEntity>> GETLISTA()
        {
            try
            {
                var result = sql.QueryAsync<RolesEntity>("dbo.RolesList");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<IEnumerable<String>> GETPERMISOSs(int IdRol)
        {
            try
            {
                var result = sql.QueryAsync<String>("dbo.PermisosList", new { IdRol });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }


           
            

        }

        public async Task<RolesEntity> GETPERMISOS(int IdRol)
        {
            try
            {
                var result = sql.QueryFirstAsync<RolesEntity>("dbo.RolesRead", new { IdRol });

             
                return await result;
            }
            catch (Exception)
            {

                throw;
            }


     
        }
    }
    #endregion
}
