using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class OrdenesEntity : DBEntity
    {
        public int? IdOrden { get; set; }
        public string NombreCliente { get; set; }
        public string PlacaVehiculo { get; set; }
        public string MarcaVehiculo { get; set; }
        public string ModeloVehiculo { get; set; }
        public string AnoVehiculo { get; set; }
        public float ManodeObra { get; set; }
        public string Productos { get; set; }
        public float PrecioProductos { get; set; }
        public string Estado { get; set; }

    }
}
