using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Bitacora_MovimientosEntity : DBEntity
    {
        public int IdMovimiento { get; set; }
        public string Nombre_Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Movimiento { get; set; }
        public string Detalle { get; set; }
    }
}
