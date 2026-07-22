using System;
using System.Collections.Generic;
using System.Text;
using TorneoPOO_JAnchundia.Generales;

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
        private int id;
       

        public Equipo Local { get => local; set => local = value; }
        public Equipo Visitante { get => visitante; set => visitante = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Lugar { get => lugar; set => lugar = value; }
        public int AsistenciaEspectadores { get => asistenciaEspectadores; set => asistenciaEspectadores = value; }
        public int DuracionMinutos { get => duracionMinutos; set => duracionMinutos = value; }
        public string Estado { get => estado; set => estado = value; }

        public int Id { get => id; set => id = value; }


        public Partido(Equipo local, Equipo visitante, DateTime fecha, string lugar, int asistenciaEspectadores, int duracionMinutos, string estado)
        {

            this.Local = local;
            this.Visitante = visitante;
            this.Fecha = fecha;
            this.Lugar = lugar;
            this.asistenciaEspectadores = asistenciaEspectadores;
            this.duracionMinutos = duracionMinutos;
            this.estado = estado;
            if (Database.Partido.Count == 0)
            {
                this.id = 1;
            }
            else
            {
                this.id = Database.Partido.Max(x => x.id) + 1;
            }
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