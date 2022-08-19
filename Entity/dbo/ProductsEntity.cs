using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProductsEntity : DBEntity
    {
        public int? IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public float CantidadDisponible { get; set; }
        public float PrecioCompra { get; set; }
        public float PrecioVenta { get; set; }
        public float CostoTotal { get; set; }
        public string UsuarioLogin { get; set; }
    }
}
