using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioVeterinario : IRepositorioVeterinario
    {
        private readonly AppContext _appContext;

        public RepositorioVeterinario(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Veterinario AddVeterinario(Veterinario veterinario)
        {
            var veterinarioNuevo = _appContext.Veterinarios.Add(veterinario);
            _appContext.SaveChanges();
            return veterinarioNuevo.Entity;
        }

        public Veterinario UpdateVeterinario(Veterinario veterinario)
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(d => d.Id == veterinario.Id);
            if(veterinarioEncontrado != null)
            {
                veterinarioEncontrado.Nombres = veterinario.Nombres;
                veterinarioEncontrado.Apellidos = veterinario.Apellidos;
                veterinarioEncontrado.Direccion = veterinario.Direccion;
                veterinarioEncontrado.Telefono = veterinario.Telefono;
                veterinarioEncontrado.TarjetaProfesional = veterinario.TarjetaProfesional;
                _appContext.SaveChanges();
            }
            return veterinarioEncontrado;
        }

        public void DeleteVeterinario(int idVeterinario)
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(d => d.Id == idVeterinario);
            if (veterinarioEncontrado == null)
                return;
            _appContext.Veterinarios.Remove(veterinarioEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Veterinario> GetAllVeterinarios()
        {
            return GetAllVeterinarios_();
        }

        public IEnumerable<Veterinario> GetVeterinarioFiltro(Veterinario veterinario)
        {
            var veterinarios = GetAllVeterinarios();
            if (veterinarios != null)
            {
                if(!String.IsNullOrEmpty(veterinario.Nombres))
                {
                    veterinarios = veterinarios.Where(s => s.Nombres.Contains(veterinario.Nombres));
                }
                if(!String.IsNullOrEmpty(veterinario.Apellidos))
                {
                    veterinarios = veterinarios.Where(s => s.Apellidos.Contains(veterinario.Apellidos));
                }
                if(!String.IsNullOrEmpty(veterinario.TarjetaProfesional))
                {
                    veterinarios = veterinarios.Where(s => s.TarjetaProfesional.Contains(veterinario.TarjetaProfesional));
                }
            }
            return veterinarios;
        }

        public IEnumerable<Veterinario> GetAllVeterinarios_()
        {
            return _appContext.Veterinarios;
        }

        public Veterinario GetVeterinario(int idVeterinario)
        {
            return _appContext.Veterinarios.FirstOrDefault(d => d.Id == idVeterinario);
        }
    }
}