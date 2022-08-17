using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PermisosEntity : DBEntity
    {
        public PermisosEntity()
        {
            Roles = Roles ?? new RolesEntity();
        }

        public int? IdPermiso { get; set; }
        public string IdRol { get; set; }
        public virtual RolesEntity Roles { get; set; }
        public Boolean AccesoTaller { get; set; }
        public string Taller { get; set; }
        public string UsuarioLogin { get; set; }
        
    }
}
