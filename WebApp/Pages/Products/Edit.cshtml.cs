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
        private readonly IProductsService proveedor;

        public EditModel(IProductsService proveedor)
        {
            this.proveedor = proveedor;
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

                    Entity = await proveedor.GETBYID(new()
                    {
                        IdProduct = id
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
                if (Entity.IdProduct.HasValue)
                {
                    var result = await proveedor.UPDATE(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se actualizó correctamente";
                }
                else //Insertar
                {
                    var result = await proveedor.CREATE(Entity);

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
