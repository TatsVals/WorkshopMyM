using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;

namespace WBL
{
    public interface ICambioClaveService
    {
        Task<DBEntity> UPDATE(CambioClaveEntity entity);
    }

    public class CambioClaveService : ICambioClaveService
    {

        private readonly IDataAccess sql;

        public CambioClaveService(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<DBEntity> UPDATE(CambioClaveEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.CambioClave", new
                {
                    entity.Nombre_Usuario,
                    entity.ClaveActual,
                    entity.ClaveNueva,
                    entity.UsuarioLogin
                });


                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
