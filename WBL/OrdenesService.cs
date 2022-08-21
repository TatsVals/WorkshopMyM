using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;

namespace WBL
{
    public interface IOrdenesService
    {
        Task<DBEntity> CREATE(OrdenesEntity entity);
        Task<DBEntity> DELETE(OrdenesEntity entity);
        Task<IEnumerable<OrdenesEntity>> GET();
        Task<OrdenesEntity> GETBYID(OrdenesEntity entity);
        Task<DBEntity> UPDATE(OrdenesEntity entity);
    }

    public class OrdenesService : IOrdenesService
    {
        private readonly IDataAccess sql;

        public OrdenesService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region MetodosCRUD

        //Metodo Get
        public async Task<IEnumerable<OrdenesEntity>> GET()
        {
            try
            {
                var result = sql.QueryAsync<OrdenesEntity>("dbo.OrdenRead");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        //MetodoGetById
        public async Task<OrdenesEntity> GETBYID(OrdenesEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<OrdenesEntity>("dbo.OrdenRead", new { entity.IdOrden });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        //Metodo Create
        public async Task<DBEntity> CREATE(OrdenesEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.OrdenCreate", new
                {
                    entity.NombreCliente,
                    entity.PlacaVehiculo,
                    entity.MarcaVehiculo,
                    entity.ModeloVehiculo,
                    entity.AnoVehiculo,
                    entity.ManodeObra,
                    entity.Productos,
                    entity.PrecioProductos,
                    entity.Estado

                });


                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        //Metodo Update
        public async Task<DBEntity> UPDATE(OrdenesEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.OrdenUpdate", new
                {
                    entity.IdOrden,
                    entity.NombreCliente,
                    entity.PlacaVehiculo,
                    entity.MarcaVehiculo,
                    entity.ModeloVehiculo,
                    entity.AnoVehiculo,
                    entity.ManodeObra,
                    entity.Productos,
                    entity.PrecioProductos,
                    entity.Estado
                });


                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Delete
        public async Task<DBEntity> DELETE(OrdenesEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.OrdenDelete", new
                {
                    entity.IdOrden

                });


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