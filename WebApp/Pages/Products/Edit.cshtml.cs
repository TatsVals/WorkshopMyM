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

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (Entity.IdProducto.HasValue)
                {
                    var result = await producto.UPDATE(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se actualizó correctamente";
                }
                else //Insertar
                {
                    var result = await producto.CREATE(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se agregó correctamente";

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
