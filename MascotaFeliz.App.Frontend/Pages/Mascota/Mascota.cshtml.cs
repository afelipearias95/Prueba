using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Persistencia;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class MascotaModel : PageModel
    {

        private readonly IRepositorioMascota repositorioMascota;

        [BindProperty]
        public Mascota Mascota { get; set; } 

        public MascotaModel(IRepositorioMascota repositorioMascota)
        {
            this.repositorioMascota = new RepositorioMascota(new MascotaFeliz.App.Persistencia.AppContext());
        }

        public IActionResult OnGet(int? mascotaId)
        {
            if (mascotaId.HasValue)
            {
                Mascota = repositorioMascota.GetMascota(mascotaId.Value);
            }
            else
            {
                Mascota = new Mascota();
            }
            if (Mascota == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();

        }

        
        public IActionResult OnPost()
        {
             if (ModelState.IsValid)
            {
                if (Mascota.Id > 0)
                {
                    repositorioMascota.UpdateMascota(Mascota);
                }
                else
                {
                    repositorioMascota.AddMascota(Mascota);
                }
                return RedirectToPage("./Consultar/ConsultarMat");
            }
            else
            {
                return Page();
            }
        }

    }
}
