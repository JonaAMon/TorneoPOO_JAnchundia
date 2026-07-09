using System;
using System.Collections.Generic;
using System.Text;

namespace TorneoPOO_JAnchundia.Models
{
    public class Equipo
    {
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public List<Jugador> Jugadores { get; set; }

        public Equipo(string nombre, string ciudad)
        {
            this.Nombre = nombre;
            this.Ciudad = ciudad;
            this.Jugadores = new List<Jugador>();
        }


        public void AgregarJugador(Jugador objJugador)
        {
            if (objJugador == null)
            {
                Console.WriteLine("No se puede agregar un jugador nulo.");
                return;
            }

            this.Jugadores.Add(objJugador);
            Console.WriteLine($"Jugador {objJugador.Nombre} agregado correctamente");
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
