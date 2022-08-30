using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.Users
{
    public class CambioClaveModel : PageModel
    {
        private readonly ICambioClaveService CambioClave;
        public CambioClaveModel(ICambioClaveService CambioClave)
        {
            this.CambioClave = CambioClave;
            
        }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }


        [BindProperty]
        [FromBody]
        public CambioClaveEntity Entity { get; set; } = new CambioClaveEntity();

        
        public async Task<IActionResult> OnPost()
        {
            Entity.UsuarioLogin = User.Identity.Name;
            try
            {
                var result = new DBEntity();
                
             
                    result = await CambioClave.UPDATE(Entity);

                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }
    }
}
