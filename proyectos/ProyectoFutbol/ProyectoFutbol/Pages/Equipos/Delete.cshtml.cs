using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace ProyectoFutbol.Pages.Equipos
{
    public class DeleteModel : PageModel
    {
        private readonly IEquipoRepositorio equipoRepositorio;

        public DeleteModel(IEquipoRepositorio equipoRepositorio)
        {
            this.equipoRepositorio = equipoRepositorio;
        }

        [BindProperty]
        public Equipo equipo { get; set; }
        public void OnGet(int Id)
        {

            equipo = equipoRepositorio.GetEquipoById(Id);

        }
        public IActionResult OnPost(int Id)
        {
            equipoRepositorio.Delete(equipo.Id);
            return RedirectToPage("Index");
        }
    }
}
