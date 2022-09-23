using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioVisita
    {
        IEnumerable<Visita> GetAllVisitas();

        Visita AddVisita (Visita visita);

        Visita UpdateVisita (Visita visita);

        void DeleteVisita (int idVisita);

        Visita GetVisita(int idVisita);

        IEnumerable<Visita> GetVisitaFiltro(Visita visita);
    }
}