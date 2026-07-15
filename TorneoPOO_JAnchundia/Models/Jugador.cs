using System;
using System.Collections.Generic;
using System.Text;

namespace TorneoPOO_JAnchundia.Models
{
    public class Jugador
    {
        //ATRIBUTOS O CARACTERISTICAS
        private string nombre;
        private int edad;
        private int numero;
        private string posicion;
        private string nacionalidad;
        private int goles;
        private bool esTitular;

        public string Nombre
        {
            get => nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("El nombre no puede estar vacío.");
                }
                nombre = value;
            }
        }

        public int Edad
        {
            get => edad;
            set
            {
                if (!EsMayorEdad(value))
                {
                    throw new Exception("El jugador debe ser mayor de edad.");
                }
                edad = value;
            }
        }

        public int Numero
        {
            get => numero;
            set
            {
                if (!EsNumeroValido(value))
                {
                    throw new Exception("El número de la camiseta debe estar entre 1 y 99.");
                }
                numero = value;
            }
        }

        public string Posicion
        {
            get => posicion;
            set
            {
                string pos = value?.ToLower().Trim();
                if (pos != "portero" && pos != "defensa" && pos != "mediocampista" && pos != "delantero")
                {
                    throw new Exception("Posición inválida. Debe ser: Portero, Defensa, Mediocampista o Delantero.");
                }
                posicion = value;
            }
        }

        public string Nacionalidad
        {
            get => nacionalidad;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("La nacionalidad no puede estar vacía.");
                }
                nacionalidad = value;
            }
        }

        public int Goles
        {
            get => goles;
            set
            {
                if (value < 0)
                {
                    throw new Exception("La cantidad de goles no puede ser negativa.");
                }
                goles = value;
            }
        }

        public bool EsTitular
        {
            get => esTitular;
            set => esTitular = value;
        }


        //Constructor
        public Jugador(string nombre, int edad, int numero, string posicion, string nacionalidad, int goles, bool esTitular)
        {

            this.Nombre = nombre;
            this.Edad = edad;
            this.Numero = numero;
            this.Posicion = posicion;
            this.nacionalidad = nacionalidad;
            this.goles = goles;
            this.esTitular = esTitular;
        }



        //METODOS, COMPORTAMIENTOS O FUNCIONES
        public void Presentar()
        {
            string titularidad = this.EsTitular ? "Titular" : "Suplente";
            Console.WriteLine($"Hola, soy {this.Nombre} ({this.Nacionalidad}), tengo {this.Edad} años, juego de {this.Posicion}, mi número es el {this.Numero}, llevo {this.Goles} goles y soy {titularidad}.");
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