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


        //Constructor
        public Jugador(string nombre, int edad, int numero, string posicion)
        {
            if (!EsMayorEdad(edad))
            {
                throw new Exception("El jugador debe ser mayor de edad");
            }
            if (!EsNumeroValido(numero))
            {
                throw new Exception("El número de la camiseta no es válido");
            }

            this.Nombre = nombre;
            this.Edad = edad;
            this.Numero = numero;
            this.Posicion = posicion;
        }



        //METODOS, COMPORTAMIENTOS O FUNCIONES
        public void Presentar()
        {
            Console.WriteLine($"Hola soy {this.Nombre} tengo {this.Edad} años y mi número es el {this.Numero}");
        }

        public Boolean EsMayorEdad(int edad)
        {
            if (edad >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean EsNumeroValido(int numero)
        {
            if (numero > 0 && numero < 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void CambiarNumeroCamiseta(int nuevoNumero)
        {
            if (nuevoNumero <= 0 || nuevoNumero > 99)
            {
                Console.WriteLine($"Número inválido: {nuevoNumero}. Debe estar entre 1 y 99.");
                return;
            }

            this.Numero = nuevoNumero;
            Console.WriteLine($"{Nombre} ahora tiene la camiseta número {nuevoNumero}");
        }


    }
}