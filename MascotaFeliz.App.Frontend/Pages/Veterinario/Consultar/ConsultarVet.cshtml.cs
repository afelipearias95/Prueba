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
    public class ConsultarVetModel : PageModel
    {
        private readonly IRepositorioVeterinario repositorioVeterinario;

        [BindProperty(SupportsGet = true)]
        public Veterinario Veterinario  { get; set; } 

        public Veterinario VaterinarioDel  { get; set; }

        public IEnumerable<Veterinario> veterinarios {get;set;}

        public ConsultarVetModel(IRepositorioVeterinario repositorioVeterinario)
        {
            this.repositorioVeterinario = new RepositorioVeterinario(new MascotaFeliz.App.Persistencia.AppContext());
        }

        public void OnGet(int idVeterinario, Veterinario veterinario)
        {

            Veterinario = veterinario;
            veterinarios = repositorioVeterinario.GetVeterinarioFiltro(Veterinario); 

            VaterinarioDel = repositorioVeterinario.GetVeterinario(idVeterinario);
            if (VaterinarioDel == null)
            {
                RedirectToPage("./NotFound");
            }
            else
            {
                repositorioVeterinario.DeleteVeterinario(VaterinarioDel.Id);
                Page();
            } 
        }
    }
}
