using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Roles
{
    public class GridModel : PageModel
    {
        private readonly IRolesService roles;

        public GridModel(IRolesService roles)
        {
            this.roles = roles;
        }

        public IEnumerable<RolesEntity> GridList { get; set; } = new List<RolesEntity>();


        public string Mensaje { get; set; } = "";


        public async Task<IActionResult> OnGet()
        {

            try
            {
                GridList = await roles.GET();

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
                var result = await roles.DELETE(new()
                { IdRol = id });


                return new JsonResult(result);
            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }

        }
    }
}
