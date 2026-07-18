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
        private static int contadorId = 1;

        public int Id { get; }


        public Equipo Local { get => local; set => local = value; }
        public Equipo Visitante { get => visitante; set => visitante = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Lugar { get => lugar; set => lugar = value; }
        public int AsistenciaEspectadores { get => asistenciaEspectadores; set => asistenciaEspectadores = value; }
        public int DuracionMinutos { get => duracionMinutos; set => duracionMinutos = value; }
        public string Estado { get => estado; set => estado = value; }

       
        public Partido(Equipo local, Equipo visitante, DateTime fecha, string lugar, int asistenciaEspectadores, int duracionMinutos, string estado)
        {

            this.Id = contadorId++;
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
            Console.WriteLine($"[ID: {this.Id}] Partido [{this.Estado}] entre {this.Local.Nombre} y {this.Visitante.Nombre}...");
        }

        //AÑADIR IMPRIMIR PARTIDO
        public void Imprimir()
        {
            Console.WriteLine($"ID Único: {this.Id}"); // 4. Mostramos el ID numérico
            Console.WriteLine($"Partido: {this.Local.Nombre} vs {this.Visitante.Nombre}");
            Console.WriteLine($"Fecha: {this.Fecha.ToShortDateString()}");
            Console.WriteLine($"Lugar: {this.Lugar}");
            Console.WriteLine($"Espectadores: {this.AsistenciaEspectadores:N0}");
            Console.WriteLine($"Duración: {this.DuracionMinutos} minutos");
            Console.WriteLine($"Estado: {this.Estado}");
        }
    }
}