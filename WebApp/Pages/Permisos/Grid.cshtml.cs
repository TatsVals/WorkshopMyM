using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Permisos
{
    public class GridModel : PageModel
    {
        private readonly IPermisosService permisos;

        public GridModel(IPermisosService permisos)
        {
            this.permisos = permisos;
        }

        public IEnumerable<PermisosEntity> GridList { get; set; } = new List<PermisosEntity>();

        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await permisos.Get();

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

            try
            {
                var result = await permisos.Delete(new()
                { IdPermiso = id });


                return new JsonResult(result);
            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }

        }

        

    }
}
