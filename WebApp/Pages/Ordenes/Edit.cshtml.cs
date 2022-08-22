using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.Ordenes
{
    public class EditModel : PageModel
    {
        private readonly IOrdenesService orden;

        public EditModel(IOrdenesService orden)
        {
            this.orden = orden;
        }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        [FromBody]
        public OrdenesEntity Entity { get; set; } = new OrdenesEntity();

        public async Task<IActionResult> OnGet()
        {

            try
            {
                if (id.HasValue)
                {

                    Entity = await orden.GETBYID(new()
                    {
                        IdOrden = id
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
                if (Entity.IdOrden.HasValue) //si el idContacto tiene un valor (true) el metodo actuliza
                {
                    result = await orden.UPDATE(Entity);



                }
                else //Si el idContacto no tiene valor (false) el metodo inserta
                {
                    result = await orden.CREATE(Entity);


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
