using System;
using System.Collections.Generic;
using System.Text;
using TorneoPOO_JAnchundia.Models;

namespace TorneoPOO_JAnchundia.Generales
{
    public static class Database
    {

        private static readonly string rutaCarpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Datos");
        private static readonly string rutaArchivoJugadores = Path.Combine(rutaCarpeta, "jugadores.json");
        private static readonly string rutaArchivoEquipos = Path.Combine(rutaCarpeta, "equipos.json");
        private static readonly string rutaArchivoPartidos = Path.Combine(rutaCarpeta, "partidos.json");



        public static List<Jugador> Jugadores { get; set; } = new List<Jugador>();
        public static List<Equipo> Equipos { get; set; } = new List<Equipo>();
        public static List<Partido> Partido { get; set; } = new List<Partido>();

        public static void CargarDatos()
        {
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }
            Jugadores = ArchivoJson.LeerArchivo<Jugador>(rutaArchivoJugadores);
            Equipos = ArchivoJson.LeerArchivo<Equipo>(rutaArchivoEquipos);
            Partido = ArchivoJson.LeerArchivo<Partido>(rutaArchivoPartidos);
        }
        public static void GuardarDatos()
        {
            ArchivoJson.Guardar(rutaArchivoJugadores, Jugadores);
            ArchivoJson.Guardar(rutaArchivoEquipos, Equipos);
            ArchivoJson.Guardar(rutaArchivoPartidos, Partido);
        }
        public static void GuardarJugadores()
        {
            ArchivoJson.Guardar(rutaArchivoJugadores, Jugadores);
        }
        public static void GuardarEquipos()
        {
            ArchivoJson.Guardar(rutaArchivoEquipos, Equipos);
        }
        public static void GuardarPartidos()
        {
            ArchivoJson.Guardar(rutaArchivoPartidos, Partido);
        }
    }
}
