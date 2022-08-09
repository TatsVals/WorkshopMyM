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
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (Entity.IdPermiso.HasValue)
                {
                    var result = await permisos.Update(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se actualizó correctamente";
                }
                else //Insertar
                {
                    var result = await permisos.Create(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se agregó correctamente";

                }


                return RedirectToPage("Grid");

            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }
    }
}
