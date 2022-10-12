using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class BitacoraIngresosEntity
    {
        public int IdIngreso { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string FechaSalida { get; set; }
    }
}
