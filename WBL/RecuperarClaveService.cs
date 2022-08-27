using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;

namespace WBL
{
    public interface IRecuperarClaveService
    {
        Task<RecuperarClaveEntity> Recuperar(RecuperarClaveEntity entity);
    }

    public class RecuperarClaveService : IRecuperarClaveService
    {
        private readonly IDataAccess sql;

        public RecuperarClaveService(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<RecuperarClaveEntity> Recuperar(RecuperarClaveEntity entity)
        {
            try
            {
                var result = await sql.QueryFirstAsync<RecuperarClaveEntity>("EnvioClaveTemporal", new
                {

                    entity.Nombre_Usuario,
                    entity.Correo

                });

                return result;


            }
            catch (Exception ex)
            {

                throw;
            }


        }
    }
}
