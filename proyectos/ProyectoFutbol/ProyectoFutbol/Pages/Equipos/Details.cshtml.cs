using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace ProyectoFutbol.Pages.Equipos
{
    public class DetailsModel : PageModel
    {
        public Equipo equipo { get; set; }

        private readonly IEquipoRepositorio equipoRepositorio;

        public DetailsModel(IEquipoRepositorio equipoRepositorio)
        {
            this.equipoRepositorio = equipoRepositorio;
        }

        public void OnGet(int Id)
        {
            equipo = equipoRepositorio.GetEquipoById(Id);

        }
    }
}
