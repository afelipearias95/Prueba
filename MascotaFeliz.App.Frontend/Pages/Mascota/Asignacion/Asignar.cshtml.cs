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
    public class AsignarModel : PageModel
    {
        
        private readonly IRepositorioMascota repositorioMascota;
        private static IRepositorioPropietario repositorioPropietario = new RepositorioPropietario(new Persistencia.AppContext());
        private static IRepositorioVeterinario repositorioVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());

        [BindProperty]
        public Mascota Mascota { get; set; }
        public Dueno propietario { get; set; }
        public Veterinario veterinario { get; set; }

        public IEnumerable<Dueno> propietarios {get; set;}
        public IEnumerable<Veterinario> veterinarios {get; set;}

        public AsignarModel()
        {
            this.repositorioMascota = new RepositorioMascota(new MascotaFeliz.App.Persistencia.AppContext());
        }

        public void OnGet(int? mascotaId)
        {
            propietarios = repositorioPropietario.GetAllPropietarios();
            veterinarios = repositorioVeterinario.GetAllVeterinarios();

            if (mascotaId.HasValue)
            {
                Mascota = repositorioMascota.GetMascota(mascotaId.Value);
            }

            if (Mascota == null)
            {
                RedirectToPage("./NotFound");
            }
            else
            {
                Page();
            }

        }

        public IActionResult OnPost(Mascota mascota, int propietarioId, int veterinarioId)
        {
            if (ModelState.IsValid)
            {
                propietario = repositorioPropietario.GetPropietario(propietarioId);
                veterinario = repositorioVeterinario.GetVeterinario(veterinarioId);

                if (mascota.Id > 0)
                {
                    mascota.Veterinario = veterinario;
                    mascota.Dueno = propietario;
                    repositorioMascota.UpdateMascota(mascota);
                }

                return RedirectToPage("../Consultar/ConsultarMat");
            }
            else
            {
                return Page();
            }
        }
    }
}
