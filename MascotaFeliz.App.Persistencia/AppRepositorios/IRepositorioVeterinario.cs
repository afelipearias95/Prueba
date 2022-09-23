using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioVeterinario
    {
        IEnumerable<Veterinario> GetAllVeterinarios();
         
        Veterinario AddVeterinario (Veterinario veterinario);

        Veterinario UpdateVeterinario (Veterinario veterinario);

        void DeleteVeterinario (int idVeterinario);

        Veterinario GetVeterinario(int idVeterinario);

        IEnumerable<Veterinario> GetVeterinarioFiltro(Veterinario veterinario);
    }
}