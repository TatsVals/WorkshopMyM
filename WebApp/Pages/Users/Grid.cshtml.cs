using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Users
{
    public class GridModel : PageModel
    {
        private readonly IUsersService usersService;

        public GridModel(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IEnumerable<UsersEntity> GridList { get; set; } = new List<UsersEntity>();

        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await usersService.Get();

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
                var result = await usersService.Delete( new()                
                {
                    IdUsuario = id
                }               
                );

                if (result.CodeError!=0)
                {
                    throw new Exception(result.MsgError);
                }

                TempData["Msg"] = "El usuario se eliminó correctamente";

                return Redirect("Grid");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }



    }
}
