using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;

namespace WBL
{
    public interface IBitacoraIngresosService
    {
        Task<IEnumerable<BitacoraIngresosEntity>> Get();
    }

    public class BitacoraIngresosService : IBitacoraIngresosService
    {
        private readonly IDataAccess sql;
        public BitacoraIngresosService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region MetodosCRUD

        // Metodo GET
        public async Task<IEnumerable<BitacoraIngresosEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<BitacoraIngresosEntity>("dbo.BitacoraIngresosRead");
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


