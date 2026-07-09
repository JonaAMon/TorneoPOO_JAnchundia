using System;
using System.Collections.Generic;
using System.Text;

namespace TorneoPOO_JAnchundia.Models
{
   
    public class Partido
    {
        public Equipo Local { get; set; }
        public Equipo Visitante { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }

        public Partido(Equipo local, Equipo visitante, DateTime fecha, string lugar)
        {
            if (local == null || visitante == null)
            {
                throw new ArgumentException("Los equipos no pueden ser nulos.");
            }

            if (local.Nombre == visitante.Nombre)
            {
                throw new ArgumentException("El equipo local y visitante deben ser distintos.");
            }
            
            this.Local = local;
            this.Visitante = visitante;
            this.Fecha = fecha;
            this.Lugar = lugar;
        }

        public void MostrarResumen()
        {
            Console.WriteLine($"Hay un partido programado entre el local {this.Local.Nombre} y el visitante {this.Visitante.Nombre} en el lugar {this.Lugar}");
        }



    }
}