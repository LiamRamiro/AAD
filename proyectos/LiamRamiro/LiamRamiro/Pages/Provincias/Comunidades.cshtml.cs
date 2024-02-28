using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace LiamRamiro.Pages.Provincias
{
    public class IndexModel : PageModel
    {
        private readonly IProvinciaRepositorio ProvinciaRepositorio;
        public IEnumerable<Provincia> Provincias;

        [BindProperty(SupportsGet = true)]
        public Comunidad elementoABuscar { get; set; }

        public IndexModel(IProvinciaRepositorio ProvinciaRepositorio)
        {
            this.ProvinciaRepositorio = ProvinciaRepositorio;
        }

        public void OnGet()
        {
            Provincias = ProvinciaRepositorio.BuscarProvinciasPorComunidad(elementoABuscar);
        }
    }
}
