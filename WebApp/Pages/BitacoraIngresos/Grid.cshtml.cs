using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.BitacoraIngresos
{
    public class GridModel : PageModel
    {
        private readonly IBitacoraIngresosService BIngresos;

        public GridModel(IBitacoraIngresosService BIngresos)
        {
            this.BIngresos = BIngresos;
        }

        public IEnumerable<BitacoraIngresosEntity> GridList { get; set; } = new List<BitacoraIngresosEntity>();


        public string Mensaje { get; set; } = "";


        public async Task<IActionResult> OnGet()
        {

            try
            {
                GridList = await BIngresos.Get();

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

        
    }
}
