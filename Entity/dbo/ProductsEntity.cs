﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProductsEntity : DBEntity
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public string CantidadDisponible { get; set; }
        public float PrecioCompra { get; set; }
        public float PrecioVenta { get; set; }
        public float CostoTotal { get; set; }
    }
}
