using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;


namespace WebApp.Pages.Users
{
    public class EditModel : PageModel
    {
        
        private readonly IUsersService users;
        private readonly IRolesService roles;
        public EditModel(IUsersService users, IRolesService roles)
        {
            this.users = users;
            this.roles = roles;
        }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        [FromBody]
        public UsersEntity Entity { get; set; } = new UsersEntity();
        public IEnumerable<RolesEntity> RolesLista { get; set; } = new List<RolesEntity>();
        public async Task<IActionResult> OnGet()
        {

            try
            {
                if (id.HasValue)
                {

                    Entity = await users.GetById(new()
                    {
                        IdUsuario = id
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
                if (Entity.IdUsuario.HasValue) //si el idContacto tiene un valor (true) el metodo actuliza
                {
                    result = await users.Update(Entity);



                }
                else //Si el idContacto no tiene valor (false) el metodo inserta
                {
                    result = await users.Create(Entity);


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
