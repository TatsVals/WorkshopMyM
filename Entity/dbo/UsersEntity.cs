using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class UsersEntity:DBEntity 
    {
        public int? IdUsuarios { get; set; }
        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public string Primer_Apellido { get; set; }
          
        public string Segundo_Apellido { get; set; }

        public string Nombre_Usuario { get; set; }

        public string Clave { get; set; }
    }
}
