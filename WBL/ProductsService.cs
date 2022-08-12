using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;

namespace WBL
{
    public interface IProductsService
    {
        Task<DBEntity> CREATE(ProductsEntity entity);
        Task<DBEntity> DELETE(ProductsEntity entity);
        Task<IEnumerable<ProductsEntity>> GET();
        Task<ProductsEntity> GETBYID(ProductsEntity entity);
        Task<DBEntity> UPDATE(ProductsEntity entity);
    }

    public class ProductsService : IProductsService
    {
        private readonly IDataAccess sql;

        public ProductsService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region MetodosCRUD

        //Metodo Get
        public async Task<IEnumerable<ProductsEntity>> GET()
        {
            try
            {
                var result = sql.QueryAsync<ProductsEntity>("dbo.ProductsRead");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }
        
        //MetodoGetById
        public async Task<ProductsEntity> GETBYID(ProductsEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<ProductsEntity>("dbo.ProductsRead", new { entity.IdProducto });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        //Metodo Create
        public async Task<DBEntity> CREATE(ProductsEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ProductsCreate", new
                {
                    entity.Codigo,
                    entity.Descripcion,
                    entity.Unidad,
                    entity.CantidadDisponible,
                    entity.PrecioCompra,
                    entity.PrecioVenta
                    
                });


                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        //Metodo Update
        public async Task<DBEntity> UPDATE(ProductsEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ProductsUpdate", new
                {
                    entity.IdProducto,
                    entity.Codigo,
                    entity.Descripcion,
                    entity.Unidad,
                    entity.CantidadDisponible,
                    entity.PrecioCompra,
                    entity.PrecioVenta
                });


                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Delete
        public async Task<DBEntity> DELETE(ProductsEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ProductsDelete", new
                {
                    entity.IdProducto

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
