using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Ordenes
{
    public class GridModel : PageModel
    {
        private readonly IOrdenesService ordenes;

        public GridModel(IOrdenesService ordenes)
        {
            this.ordenes = ordenes;
        }

        public IEnumerable<OrdenesEntity> GridList { get; set; } = new List<OrdenesEntity>();

        public UsersEntity Entity { get; set; } = new UsersEntity();
        public OrdenesEntity ordenesEntity { get; set; } = new OrdenesEntity();
        public string Mensaje { get; set; } = "";


        public async Task<IActionResult> OnGet()
        {

            try
            {
                GridList = await ordenes.GET();

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

            ordenesEntity = await ordenes.GETBYID(new()
            {
                IdOrden = id
            });
            try
            {
                var result = await ordenes.DELETE(new()
                {
                    IdOrden = id,
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
