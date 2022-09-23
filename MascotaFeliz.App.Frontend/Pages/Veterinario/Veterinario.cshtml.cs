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
    public class VeterinarioModel : PageModel
    {

        private readonly IRepositorioVeterinario repositorioVeterinario;

        [BindProperty]
        public Veterinario Veterinario  { get; set; } 

        public VeterinarioModel(IRepositorioVeterinario repositorioVeterinario)
        {
            this.repositorioVeterinario=new RepositorioVeterinario(new MascotaFeliz.App.Persistencia.AppContext());
        }

        public IActionResult OnGet(int? veterinarioId)
        {
            if (veterinarioId.HasValue)
            {
                Veterinario = repositorioVeterinario.GetVeterinario(veterinarioId.Value);
            }
            else
            {
                Veterinario = new Veterinario();
            }
            if (Veterinario == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();

        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(Veterinario.Id>0)
            {
            Veterinario = repositorioVeterinario.UpdateVeterinario(Veterinario);
            }
            else
            {
             repositorioVeterinario.AddVeterinario(Veterinario);
            }
            return Page();
        }
    }
}
