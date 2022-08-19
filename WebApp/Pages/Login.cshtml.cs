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
using System.Reflection;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUsersService usuarioService;
        private readonly IRolesService rolesService;
        public LoginModel(IUsersService usuarioService, IRolesService rolesService)
        {

            this.usuarioService = usuarioService;
            this.rolesService = rolesService;
        }
       

        [FromBody]
        [BindProperty]
        public UsersEntity Entity { get; set; } = new UsersEntity();

        public RolesEntity role { get; set; } = new RolesEntity();

        // public IEnumerable<String> permisosLista { get; set; } = new List<String>();
        
        public List<String> permisosLista = new List<String>();

        public async Task<IActionResult> OnPost()
        {

            try
            {
                var result = await usuarioService.Login(Entity); 
                var role = await rolesService.GETPERMISOS(result.IdRol); //inicializa la entidad
                PropertyInfo[] lst = typeof(RolesEntity).GetProperties(); //lista las propiedades de la entidad
                foreach (PropertyInfo property in lst)  //para cada propiedad de la lista
                {
                    string NombreAtributo = property.Name; //guarde el nombre de la propiedad () 
                    if (NombreAtributo == "Taller" || NombreAtributo == "Personal" || NombreAtributo == "Bitacoras") //filtro para solo las que queremos
                    {
                        string Valor = property.GetValue(role).ToString();// obtener el valor de las propiedades que queremos ya filtradas
                        permisosLista.Add(Valor);//agrega el valor a la lista
                    }
                    
                }


                if (result.CodeError == 0)
                {
                    #region AUTENTICACTION
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, result.Nombre),
                    new Claim("Nombre_Usuario", result.Nombre_Usuario),
                    //new Claim(ClaimTypes.Role, result.Permisos.Taller) //agrega solo un rol o acceso
                };
                    foreach (string permiso in permisosLista) //para trabajar con varios permisos a un mismo user
                    {
                        claims.Add(new Claim(ClaimTypes.Role, permiso));
                    }

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
        public  async Task<IActionResult> OnGetSalir()
        {
            await usuarioService.Logout();
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login");
        }

    }
}
