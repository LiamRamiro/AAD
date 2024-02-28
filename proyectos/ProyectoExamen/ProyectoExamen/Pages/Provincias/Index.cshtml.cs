using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace ProyectoGeografia.Pages.Provincias
{
    public class IndexModel : PageModel
    {
        private readonly IProvinciaRepositorio provinciaRepositorio;

        public IEnumerable<Provincia> provincias { get; set; }


        [BindProperty(SupportsGet = true)]
        public string elementoABuscar { get; set; }
        public IndexModel(IProvinciaRepositorio provinciaRepositorio)
        {
            this.provinciaRepositorio = provinciaRepositorio;   

        }
        public void OnGet()
        {
            provincias = provinciaRepositorio.BuscarProvincias(elementoABuscar);
        }



    }
}