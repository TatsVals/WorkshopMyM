using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Products
{
    public class ProductsModel : PageModel
    {
        private readonly IProductsService products;

        public GridModel(IProductsService products)
        {
            this.products = products;
        }

        public IEnumerable<ProductsEntity> GridList { get; set; } = new List<ProductsEntity>();


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

        public async Task<IActionResult> OnGetEliminar(int id)
        {

            try
            {
                var result = await products.DELETE(new()
                { IdProduct = id });

                if (result.CodeError != 0)
                {
                    throw new Exception(result.MsgError);
                }

                TempData["Msg"] = "El registro fue eliminado satisfactoriamente";

                return Redirect("Grid");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }
    }
}
