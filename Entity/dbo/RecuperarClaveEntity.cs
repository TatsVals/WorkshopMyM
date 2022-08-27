using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RecuperarClaveEntity : DBEntity
    {
        public string Nombre_Usuario { get; set; }

        public string Correo { get; set; }
    }
}
