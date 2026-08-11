using System;
using System.Collections.Generic;
using System.Text;
using TorneoPOO_JAnchundia.Generales;

namespace TorneoPOO_JAnchundia.Models
{
    public class Equipo
    {
        private string nombre;
        private string ciudad;
        private List<Jugador> jugadores;
        private string directorTecnico;
        private int puntos;
        private string estadio;
        private int id;



        public string Nombre { get => nombre; set => nombre = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public List<Jugador> Jugadores { get => jugadores; set => jugadores = value; }
        public string DirectorTecnico { get => directorTecnico; set => directorTecnico = value; }
        public int Puntos { get => puntos; set => puntos = value; }
        public string Estadio { get => estadio; set => estadio = value; }
        public int Id { get => id; set => id = value; }



        public Equipo(string nombre, string ciudad, string directorTecnico, int puntos, string estadio)
        {
            this.Nombre = nombre;
            this.Ciudad = ciudad;
            this.Jugadores = new List<Jugador>();
            this.directorTecnico = directorTecnico;
            this.puntos = puntos;
            this.estadio = estadio;

        }
        public Equipo()
        {
            jugadores = new List<Jugador>();

        }
        

        public void AgregarJugador(Jugador objJugador)
        {
            this.Jugadores.Add(objJugador);
            Console.WriteLine($"Jugador {objJugador.Nombre} agregado correctamente");
        }
        public void ListarPlantilla()
        {
            Console.WriteLine($"\nLa lista de jugadores del equipo {this.Nombre} es:");

            if (Jugadores == null || Jugadores.Count == 0)
            {
                Console.WriteLine("No hay jugadores registrados en este equipo.");
                return;
            }

            foreach (Jugador objJugador in Jugadores)
            {
                objJugador.Imprimir();
                Console.WriteLine("----------------------------------");
            }
        }
        public void Imprimir()
        {
            Console.WriteLine($"Nombre del equipo: {this.Nombre}");
            Console.WriteLine($"Ciudad del equipo: {this.Ciudad}");
            Console.WriteLine($"Nombre del Director técnico: {this.directorTecnico}");
            Console.WriteLine($"Cuantos puntos tiene: {this.puntos}");
            Console.WriteLine($"Nombre del estadio: {this.estadio}");
        }

    }
}
