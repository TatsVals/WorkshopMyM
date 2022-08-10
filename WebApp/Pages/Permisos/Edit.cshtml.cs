using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;

namespace WebApp.Pages.Permisos
{
    public class EditModel : PageModel
    {

        private readonly IPermisosService permisos;
        private readonly IRolesService roles;
        public EditModel(IPermisosService permisos, IRolesService roles)
        {
            this.permisos = permisos;
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

                    Entity = await permisos.GetById(new()
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
            try
            {
                var result = new DBEntity();
                //update
                if (Entity.IdPermiso.HasValue) //si el idContacto tiene un valor (true) el metodo actuliza
                {
                    result = await permisos.Update(Entity);



                }
                else //Si el idContacto no tiene valor (false) el metodo inserta
                {
                    result = await permisos.Create(Entity);


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
