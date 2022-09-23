using System;

namespace MascotaFeliz.App.Dominio
{
    public class Visita
    {
        public int Id {get; set;}
        public float Temperatura {get; set;}
        public float Peso {get; set;}
        public float FrecuenciaRespiratoria {get; set;}
        public float FrecuenciaCardiaca {get; set;}
        public string EstadoAnimo {get; set;}
        public DateTime FechaVisita {get; set;}
        public string Recomendaciones {get; set;}
        public int IdVeterinario {get; set;}
    }
}