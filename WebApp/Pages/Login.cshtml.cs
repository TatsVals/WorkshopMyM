using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUsersService usuarioService;

        public LoginModel(IUsersService usuarioService)
        {

            this.usuarioService = usuarioService;
        }

        [FromBody]
        [BindProperty]
        public UsersEntity Entity { get; set; } = new UsersEntity();

        public async Task<IActionResult> OnPost()
        {

            try
            {
                var result = await usuarioService.Login(Entity);

                if (result.CodeError == 0)
                {

                    HttpContext.Session.Set<UsersEntity>(IApp.UsuarioSession, result);
                    return new JsonResult(result);
                }
                else
                {
                    return new JsonResult(result);

                }


            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });

                throw;
            }


        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Clear();

            return Redirect("../Login");
        }
        public void OnGet()
        {
        }
    }
}
