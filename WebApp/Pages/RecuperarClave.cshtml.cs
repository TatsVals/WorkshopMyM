using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;


namespace WebApp.Pages
{
    public class RecuperarClaveModel : PageModel
    {

        private readonly IRecuperarClaveService recuperar;

        public RecuperarClaveModel(IRecuperarClaveService recuperar)
        {
            this.recuperar = recuperar;
        }

        [BindProperty]
        [FromBody]
        public RecuperarClaveEntity Entity { get; set; } = new RecuperarClaveEntity();
        public async Task<IActionResult> OnPost()
        {
            try
            {
                
                var result = new DBEntity();
                
               
                result = await recuperar.Recuperar(Entity);



               

                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
            
        }
     
    }
}
