using System;
using System.Collections.Generic;
using System.Text;

namespace TorneoPOO_JAnchundia.Models
{
    public class Jugador
    {
        //ATRIBUTOS O CARACTERISTICAS
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int Numero { get; set; }
        public string Posicion { get; set; }

        //METODOS, COMPORTAMIENTOS O FUNCIONES
        public void Presentar()
        {
            Console.WriteLine($"Hola soy {this.Nombre} tengo {this.Edad} años y mi número es el {this.Numero}");
        }
    }
}