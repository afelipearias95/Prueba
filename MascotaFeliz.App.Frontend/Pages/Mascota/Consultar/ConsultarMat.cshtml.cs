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
    public class ConsultarMatModel : PageModel
    {

        private readonly IRepositorioMascota repositorioMascota;

        [BindProperty(SupportsGet = true)]
        public Mascota Mascota  { get; set; } 

        [BindProperty(SupportsGet = true)]
        public Veterinario Veterinario  { get; set; } 

        [BindProperty(SupportsGet = true)]
        public Dueno Propietario  { get; set; } 

        public Mascota MascotaDel  { get; set; } 

        public IEnumerable<Mascota> mascotas {get;set;}

        public ConsultarMatModel(IRepositorioMascota repositorioMascota)
        {
            this.repositorioMascota = new RepositorioMascota(new MascotaFeliz.App.Persistencia.AppContext());
        }

        public void OnGet(int idMascota, Mascota mascota)
        {

            Mascota = mascota;
            Mascota.Dueno = Propietario;
            Mascota.Veterinario = Veterinario;
            mascotas = repositorioMascota.GetMascotaFiltro(Mascota); 

            MascotaDel = repositorioMascota.GetMascota(idMascota);
            if (MascotaDel == null)
            {
                RedirectToPage("./NotFound");
            }
            else
            {
                repositorioMascota.DeleteMascota(MascotaDel.Id);
                Page();
            } 
        }
    }
}
