using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioPropietario
    {
        IEnumerable<Dueno> GetAllPropietarios();

        Dueno AddPropietario (Dueno propietario);

        Dueno UpdatePropietario (Dueno propietario);

        void DeletePropietario (int idPropietario);

        Dueno GetPropietario(int idPropietario);

        IEnumerable<Dueno> GetPropietarioFiltro(Dueno propietario);
    }
}