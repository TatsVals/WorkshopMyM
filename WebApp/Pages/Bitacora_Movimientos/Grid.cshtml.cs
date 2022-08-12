using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.dbo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Bitacora_Movimientos
{
    public class GridModel : PageModel
    {
        private readonly IBitacora_MovimientosService bitacora_MovimientosService;

        public GridModel(IBitacora_MovimientosService bitacora_MovimientosService)
        {
            this.bitacora_MovimientosService = bitacora_MovimientosService;
        }


        public IEnumerable<Bitacora_MovimientosEntity> GridList { get; set; } = new List<Bitacora_MovimientosEntity>();

        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await bitacora_MovimientosService.Get();

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
