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
    public class VisitaModel : PageModel
    {
        private readonly IRepositorioVisita repositorioVisita;
        private static IRepositorioVeterinario repositorioVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());

        [BindProperty]
        public Visita Visita  { get; set; } 

        public IEnumerable<Veterinario> veterinarios {get; set;}

        public VisitaModel(IRepositorioVisita repositorioVisita)
        {
            this.repositorioVisita = new RepositorioVisita(new MascotaFeliz.App.Persistencia.AppContext());
        }

        public IActionResult OnGet(int? visitaId)
        {   
            veterinarios = repositorioVeterinario.GetAllVeterinarios();
            
            if (visitaId.HasValue)
            {
                Visita = repositorioVisita.GetVisita(visitaId.Value);
            }
            else
            {
                Visita = new Visita();
            }
            if (Visita == null)
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
                if(Visita.Id>0)
                {
                    Visita = repositorioVisita.UpdateVisita(Visita);
                }
                else
                {
                    repositorioVisita.AddVisita(Visita);
                }
                return Page();
            }
            else
            {            
                return Page();
            }
        } 
    }
}
