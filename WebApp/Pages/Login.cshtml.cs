using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

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
                    #region AUTENTICACTION
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, result.Nombre),
                    new Claim("Nombre_Usuario", result.Nombre_Usuario),
                    new Claim(ClaimTypes.Role, result.Permisos.Taller) //agrega solo un rol o acceso
                };
                    /*foreach (string rol in result.Permisos.) //para trabajar con varios permisos a un mismo user
                    {
                        claims.Add(new Claim(ClaimTypes.Role, rol));
                    }*/

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    #endregion
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
        public  IActionResult OnGetLogout()
        {
            HttpContext.Session.Clear();
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            

            return Redirect("Login");
        }

    }
}
