using System;
using System.Collections.Generic;
using System.Text;

namespace TorneoPOO_JAnchundia.Models
{
   
    public class Partido
    {
        private Equipo local;
        private Equipo visitante; 
        private DateTime fecha; 
        private string lugar;
        private int asistenciaEspectadores;
        private int duracionMinutos;
        private string estado;

        public Equipo Local { get => local; set => local = value; }
        public Equipo Visitante { get => visitante; set => visitante = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Lugar { get => lugar; set => lugar = value; }
        public int AsistenciaEspectadores { get => asistenciaEspectadores; set => asistenciaEspectadores = value; }
        public int DuracionMinutos { get => duracionMinutos; set => duracionMinutos = value; }
        public string Estado { get => estado; set => estado = value; }

       
        public Partido(Equipo local, Equipo visitante, DateTime fecha, string lugar, int asistenciaEspectadores, int duracionMinutos, string estado)
        { 

            this.Local = local;
            this.Visitante = visitante;
            this.Fecha = fecha;
            this.Lugar = lugar;
            this.asistenciaEspectadores = asistenciaEspectadores;
            this.duracionMinutos = duracionMinutos;
            this.estado = estado;
        }


        public void MostrarResumen()
        {
            Console.WriteLine($"Hay un partido [{this.Estado}] entre el local {this.Local.Nombre} y el visitante {this.Visitante.Nombre} en el lugar {this.Lugar} el día {this.Fecha.ToShortDateString()}. Duración: {this.DuracionMinutos} min | Asistencia: {this.AsistenciaEspectadores:N0} personas.");
        }

        //AÑADIR IMPRIMIR PARTIDO
    }
}