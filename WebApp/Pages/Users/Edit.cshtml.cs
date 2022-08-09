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
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (Entity.IdUsuario.HasValue)
                {
                    var result = await users.Update(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se actualiz� correctamente";
                }
                else //Insertar
                {
                    var result = await users.Create(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se agreg� correctamente";

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
