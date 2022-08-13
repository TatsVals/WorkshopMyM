using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;
using Entity.dbo;

namespace WBL
{
    public interface IBitacora_MovimientosService
    {
        Task<IEnumerable<Bitacora_MovimientosEntity>> Get();
    }

    public class Bitacora_MovimientosService : IBitacora_MovimientosService
    {
        private readonly IDataAccess sql;

        public Bitacora_MovimientosService(IDataAccess _sql)
        {
            sql = _sql;
        }


        #region MetodosCRUD

        // Metodo GET
        public async Task<IEnumerable<Bitacora_MovimientosEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<Bitacora_MovimientosEntity>("dbo.Bitacora_MovimientosObtener");
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
