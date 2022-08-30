using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RolesEntity : DBEntity
    {
        public int? IdRol { get; set; }
        public string Rol { get; set; }
        public Boolean AccesoTaller { get; set; }
        public string Taller { get; set; }
        public Boolean AccesoPersonal { get; set; }
        public string Personal { get; set; }
        public Boolean AccesoBitacoras { get; set; }
        public string Bitacoras { get; set; }
        public string UsuarioLogin { get; set; }
    }
}
