using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Roles
{
    public class EditModel : PageModel
    {
        private readonly IRolesService roles;

        public EditModel(IRolesService roles)
        {
            this.roles = roles;
        }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        public RolesEntity Entity { get; set; } = new RolesEntity();

        public async Task<IActionResult> OnGet()
        {

            try
            {
                if (id.HasValue)
                {

                    Entity = await roles.GETBYID(new()
                    {
                        IdRol = id
                    });
                }


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
                if (Entity.IdRol.HasValue)
                {
                    var result = await roles.UPDATE(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se actualizó correctamente";
                }
                else //Insertar
                {
                    var result = await roles.CREATE(Entity);

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
