using System;
using System.Collections.Generic;
using System.Text;
using TorneoPOO_JAnchundia.Generales;

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
        private string cedula;
        private int goles;
        private bool esTitular;
        private string fichado;
        private Equipo equipo_actual;
        private int id;

        public string Nombre { get => nombre; set => nombre = value; }
        
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
                    throw new Exception("El número de la camiseta no es válido");
                }
                numero = value;
            }
        }

        public string Posicion { get => posicion; set => posicion = value; }

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
        public string Cedula
        {
            get => cedula;
            set
            {
                if (value.Length != 10)
                {
                    throw new Exception("La cédula debe tener 10 dígitos");
                }
                cedula = value;
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
        public string Fichado { get => fichado; }
         
        public int Id { get => id; set => id = value;}


        //Constructor
        public Jugador(string nombre, int edad, int numero, string posicion, string nacionalidad, string cedula, int goles, bool esTitular)
        {

            this.Nombre = nombre;
            this.Edad = edad;
            this.Numero = numero;
            this.Posicion = posicion;
            this.nacionalidad = nacionalidad;
            this.Cedula = cedula;
            this.goles = goles;
            this.esTitular = esTitular;
            this.fichado = "N";
            if (Database.Jugadores.Count == 0)
            {
                this.id = 1;
            }
            else
            {
                this.id = Database.Jugadores.Max(x => x.id) + 1;
            }
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


        public void Imprimir()
        {
           
            string titularidad = this.EsTitular ? "Titular" : "Suplente";

            Console.WriteLine($"Cédula: {this.Cedula}");
            Console.WriteLine($"Nombre: {this.Nombre}");
            Console.WriteLine($"Edad: {this.Edad} años");
            Console.WriteLine($"Lugar de Nacimiento: {this.Nacionalidad}");
            Console.WriteLine($"Número de Camiseta: #{this.Numero}");
            Console.WriteLine($"Posición: {this.Posicion}");
            Console.WriteLine($"Goles Anotados: {this.Goles}");
            Console.WriteLine($"Condición: {titularidad}");
            Console.WriteLine($"Fichado en Sistema: {this.Fichado}"); 
            Console.WriteLine($"Equipo Actual: {(this.equipo_actual != null ? this.equipo_actual.Nombre : "Sin equipo")}");
        }

        public void Fichar(Equipo equipo)
        {
            this.fichado = "S";
            this.equipo_actual = equipo;
        }

    }
}
  