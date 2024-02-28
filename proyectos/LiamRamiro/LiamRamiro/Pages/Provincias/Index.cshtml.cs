using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace LiamRamiro.Pages.Provincias
{
    public class IndexModel : PageModel
    {
        private readonly IProvinciaRepositorio ProvinciaRepositorio;

        public IEnumerable<Provincia> provincia { get; set; }


        
        public IndexModel(IProvinciaRepositorio provinciaRepositorio)
        {
            this.ProvinciaRepositorio = provinciaRepositorio;

        }
        public void OnGet()
        {
            provincia = ProvinciaRepositorio.GetProvincias();
        }



    }
}