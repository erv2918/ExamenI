using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;
using Entity.dbo;

namespace WebApplicationCore.Pages.Puestos
{
    public class EditModel : PageModel
    {
        private readonly IPuestosService puestosService;

        public EditModel(IPuestosService puestosService)
        {
            this.puestosService = puestosService;
        }
        [BindProperty]
        public PuestosEntity Entity { get; set; } = new PuestosEntity();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }


        public async Task<IActionResult> OnGet()
        {

            try
            {
                if (id.HasValue)
                {
                    Entity = await puestosService.GetById(new() { Id_Puesto = id });
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
                if (Entity.Id_Puesto.HasValue)
                {
                    //Actualizar 
                    var result = await puestosService.Update(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se actualiz� correctamente";
                }
                else
                {
                    //Nuevo 
                    var result = await puestosService.Create(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se agreg� correctamente";

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
