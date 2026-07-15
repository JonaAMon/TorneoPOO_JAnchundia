using System;
using System.Collections.Generic;
using System.Text;

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

        public string Nombre
        {
            get => nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("El nombre del equipo no puede estar vacío.");
                }
                nombre = value;
            }
        }

        public string Ciudad
        {
            get => ciudad;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("La ciudad de origen del equipo no puede estar vacía.");
                }
                ciudad = value;
            }
        }

        public List<Jugador> Jugadores
        {
            get => jugadores;
            set => jugadores = value ?? new List<Jugador>(); 
        }

        public string DirectorTecnico
        {
            get => directorTecnico;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("El nombre del Director Técnico no puede estar vacío.");
                }
                directorTecnico = value;
            }
        }

        public int Puntos
        {
            get => puntos;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Los puntos del equipo en el torneo no pueden ser negativos.");
                }
                puntos = value;
            }
        }

        public string Estadio
        {
            get => estadio;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("El nombre del estadio no puede estar vacío.");
                }
                estadio = value;
            }
        }
        public Equipo(string nombre, string ciudad, string directorTecnico, int puntos, string estadio)
        {
            this.Nombre = nombre;
            this.Ciudad = ciudad;
            this.Jugadores = new List<Jugador>();
            this.directorTecnico = directorTecnico;
            this.puntos = puntos;
            this.estadio = estadio;
        }


        public void ListarPlantilla()
        {
            Console.WriteLine($"La lista de jugadores del equipo {this.Nombre} de la ciudad de {this.Ciudad} es:");
            foreach (Jugador objJugador in Jugadores)
            {
                objJugador.Presentar();
            }
        }
        public void ContarJugadores()
        {
            Console.WriteLine($"El equipo {Nombre} tiene {Jugadores.Count} jugadores.");
        }

        public Jugador BuscarJugadorPorNumero(int numero)
        {
            foreach (Jugador j in Jugadores)
            {
                if (j.Numero == numero)
                {
                    Console.WriteLine($"Jugador encontrado: {j.Nombre}");
                    return j;
                }
            }
            Console.WriteLine("No se encontró jugador con ese número.");
            return null;
        }

    }
}
