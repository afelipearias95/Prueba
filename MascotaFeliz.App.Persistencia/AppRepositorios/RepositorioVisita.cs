using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioVisita : IRepositorioVisita
    {
        private readonly AppContext _appContext;

        public RepositorioVisita(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Visita AddVisita(Visita visita)
        {
            var visitaNuevo = _appContext.Visitas.Add(visita);
            _appContext.SaveChanges();
            return visitaNuevo.Entity;
        }

        public Visita UpdateVisita(Visita visita)
        {
            var visitaEncontrado = _appContext.Visitas.FirstOrDefault(d => d.Id == visita.Id);
            if(visitaEncontrado != null)
            {
                visitaEncontrado.Temperatura = visita.Temperatura;
                visitaEncontrado.Peso = visita.Peso;
                visitaEncontrado.FrecuenciaRespiratoria = visita.FrecuenciaRespiratoria;
                visitaEncontrado.FrecuenciaCardiaca = visita.FrecuenciaCardiaca;
                visitaEncontrado.EstadoAnimo = visita.EstadoAnimo;
                visitaEncontrado.FechaVisita = visita.FechaVisita;
                visitaEncontrado.Recomendaciones = visita.Recomendaciones;
                visitaEncontrado.IdVeterinario = visita.IdVeterinario;
                _appContext.SaveChanges();
            }
            return visitaEncontrado;
        }

        public void DeleteVisita(int idVisita)
        {
            var visitaEncontrado = _appContext.Visitas.FirstOrDefault(d => d.Id == idVisita);
            if (visitaEncontrado == null)
                return;
            _appContext.Visitas.Remove(visitaEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Visita> GetAllVisitas()
        {
            return GetAllVisitas_();
        }

        public IEnumerable<Visita> GetVisitaFiltro(Visita visita)
        {
            var visitas = GetAllVisitas();
            if (visitas != null)
            {
                if(!String.IsNullOrEmpty(visita.EstadoAnimo))
                {
                    visitas = visitas.Where(s => s.EstadoAnimo.Contains(visita.EstadoAnimo));
                }
            }
            return visitas;
        }
        
        public IEnumerable<Visita> GetAllVisitas_()
        {
            return _appContext.Visitas;
        }

        public Visita GetVisita(int idVisita)
        {
            return _appContext.Visitas.FirstOrDefault(d => d.Id == idVisita);
        }

    }
}