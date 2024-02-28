using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace ProyectoFutbol.Pages.Equipos
{
    public class EditModel : PageModel

    {
        [BindProperty]
        public Equipo Equipo { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        private readonly IEquipoRepositorio equipoRepositorio;

        public IWebHostEnvironment HostEnvironment { get; }

        public EditModel(IEquipoRepositorio equipoRepositorio, IWebHostEnvironment hostEnvironment)
        {
            this.equipoRepositorio = equipoRepositorio;
            HostEnvironment = hostEnvironment;
        }

        public IActionResult OnGet(int? Id)
        {
            if (Id.HasValue)
            {
                Equipo = equipoRepositorio.GetEquipoById(Id.Value);
            }
            else
            {
                Equipo = new Equipo();
            }
            return Page();
            
        }

        public IActionResult OnPost(Equipo equipo)
        {
            if (ModelState.IsValid)
            {

                if (Photo != null)
                {
                    {
                        if (equipo.foto != null)
                        {
                            string filePath = Path.Combine(HostEnvironment.WebRootPath, "images", equipo.foto);
                            System.IO.File.Delete(filePath);
                        }
                    }
                    equipo.foto = ProcessUploadedFile();
                }

                if (equipo.Id != 0)
                    equipoRepositorio.Update(equipo);
                else
                    equipoRepositorio.Add(equipo);
                return RedirectToPage("Index");
            }
            else
                return Page();
        }
        private string ProcessUploadedFile()
        {
            string uploadsFolder = Path.Combine(HostEnvironment.WebRootPath, "images");//lo primero nos devuelve el path a wwwroot
            string filePath = Path.Combine(uploadsFolder, Photo.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Photo.CopyTo(fileStream);
            }
            return Photo.FileName;

        }





    }
}
