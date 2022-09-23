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
    public class PropietarioModel : PageModel
    {

        private readonly IRepositorioPropietario repositorioPropietario;

        [BindProperty]
        public Dueno Propietario  { get; set; } 

        public PropietarioModel(IRepositorioPropietario repositorioPropietario)
        {
            this.repositorioPropietario=new RepositorioPropietario(new MascotaFeliz.App.Persistencia.AppContext());
        }

        public IActionResult OnGet(int? propietarioId)
        {
            if (propietarioId.HasValue)
            {
                Propietario = repositorioPropietario.GetPropietario(propietarioId.Value);
            }
            else
            {
                Propietario = new Dueno();
            }
            if (Propietario == null)
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
            if(Propietario.Id>0)
            {
            Propietario = repositorioPropietario.UpdatePropietario(Propietario);
            }
            else
            {
             repositorioPropietario.AddPropietario(Propietario);
            }
            return Page();
        } 
    }
}
