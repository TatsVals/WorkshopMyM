using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Permisos
{
    public class EditModel : PageModel
    {

        private readonly IPermisosService permiso;
        private readonly IRolesService roles;
        public EditModel(IPermisosService users, IRolesService roles)
        {
            this.permiso = users;
            this.roles = roles;
        }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }


        [BindProperty]
        [FromBody]
        public PermisosEntity Entity { get; set; } = new PermisosEntity();

        public IEnumerable<RolesEntity> RolesLista { get; set; } = new List<RolesEntity>();
        public async Task<IActionResult> OnGet()
        {

            try
            {
                if (id.HasValue)
                {

                    Entity = await permiso.GetById(new()
                    {
                        IdPermiso = id
                    });
                }

                RolesLista = await roles.GETLISTA();
                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

        //metodo update insert
        public async Task<IActionResult> OnPost()
        {
            Entity.UsuarioLogin = User.Identity.Name;
            try
            {




                var result = new DBEntity();
                //update
                if (Entity.IdPermiso.HasValue)
                {
                    result = await permiso.Update(Entity);



                }
                else
                {
                    result = await permiso.Create(Entity);


                }

                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }
    }
}
