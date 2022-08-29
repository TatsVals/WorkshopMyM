using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CambioClaveEntity : DBEntity
    {

        public string Nombre_Usuario { get; set; }
        public string ClaveActual { get; set; }
        public string ClaveNueva { get; set; }
        public string UsuarioLogin { get; set; }
    }
}
