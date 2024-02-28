using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace ProyectoFutbol.Pages.Equipos
{
    public class IndexModel : PageModel
    {
        
        private readonly IEquipoRepositorio equipoRepositorio;

        [BindProperty(SupportsGet = true)]
        public string elementoABuscar { get; set; }

		public IndexModel(IEquipoRepositorio equipoRepositorio)
		{
			this.equipoRepositorio = equipoRepositorio;
		}
                
		public IEnumerable <Equipo> equipos { get; set; }
        public void OnGet()
        {
            equipos = equipoRepositorio.BuscarEquipo(elementoABuscar);
        }

        
    }
}
