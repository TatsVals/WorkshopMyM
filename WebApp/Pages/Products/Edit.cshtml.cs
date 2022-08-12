using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IProductsService producto;
        
        public EditModel(IProductsService producto)
        {
            this.producto = producto;
        }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        [FromBody]
        public ProductsEntity Entity { get; set; } = new ProductsEntity();

        public async Task<IActionResult> OnGet()
        {

            try
            {
                if (id.HasValue)
                {

                    Entity = await producto.GETBYID(new()
                    {
                        IdProducto = id
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
            try
            {
                var result = new DBEntity();
                //update
                if (Entity.IdProducto.HasValue) //si el idContacto tiene un valor (true) el metodo actuliza
                {
                    result = await producto.UPDATE(Entity);



                }
                else //Si el idContacto no tiene valor (false) el metodo inserta
                {
                    result = await producto.CREATE(Entity);


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
