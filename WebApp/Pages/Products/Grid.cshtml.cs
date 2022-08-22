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
    public class GridModel : PageModel
    {

        private readonly IProductsService products;

        public GridModel(IProductsService products)
        {
            this.products = products;
        }

        public IEnumerable<ProductsEntity> GridList { get; set; } = new List<ProductsEntity>();

        public ProductsEntity Entity { get; set; } = new ProductsEntity();
        public string Mensaje { get; set; } = "";


        public async Task<IActionResult> OnGet()
        {

            try
            {
                GridList = await products.GET();

                if (TempData.ContainsKey("Msg"))
                {
                    Mensaje = TempData["Msg"] as string;
                }

                TempData.Clear();

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

        public async Task<JsonResult> OnDeleteEliminar(int id)
        {
            Entity = await products.GETBYID(new()
            {
                IdProducto = id
            });
            try
            {
                var result = await products.DELETE(new()
                { IdProducto = id,
                  Codigo = Entity.Codigo,
                  UsuarioLogin = User.Identity.Name
                });


                return new JsonResult(result);
            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }

        }
    }
}
