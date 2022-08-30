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
        [FromBody]
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
        public async Task<IActionResult> OnPost()
        {
            Entity.UsuarioLogin = User.Identity.Name;
            try
            {
                var result = new DBEntity();
                //update
                if (Entity.IdRol.HasValue) //si el idContacto tiene un valor (true) el metodo actuliza
                {
                    result = await roles.UPDATE(Entity);



                }
                else //Si el idContacto no tiene valor (false) el metodo inserta
                {
                    result = await roles.CREATE(Entity);


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
