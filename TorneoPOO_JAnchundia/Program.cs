using System;
using TorneoPOO_JAnchundia.Models;

namespace TorneoPOO_JAnchundia
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== INICIANDO SISTEMA DE TORNEO POO ===\n");

            try 
            {
                // CREACIÓN DE JUGADORES
                Jugador objJugador1 = new Jugador("Piero Hincapié", 24, 4, "Defensa", "Ecuatoriana", 0, true);
                Jugador objJugador2 = new Jugador("Enner Valencia", 32, 90, "Delantero", "Ecuatoriana", 8, true);
                Jugador objJugador3 = new Jugador("Moisés Caicedo", 23, 5, "Mediocampista", "Ecuatoriana", 3, true);
                Jugador objJugador4 = new Jugador("Neiser Reascos", 45, 24, "Defensa", "Ecuatoriana", 1, false);

                // CREACIÓN DE EQUIPOS
                Equipo objEquipo1 = new Equipo("Emelec", "Guayaquil", "Leonel Álvarez", 0, "Estadio George Capwell");
                Equipo objEquipo2 = new Equipo("Barcelona", "Guayaquil", "Segundo Castillo", 3, "Estadio Monumental");

                // ASOCIACIÓN DE JUGADORES A EQUIPOS
                objEquipo1.Jugadores.Add(objJugador1);
                objEquipo1.Jugadores.Add(objJugador2);

                // Simular validación de jugador nulo
                Jugador objJugadorNulo = null;
                if (objJugadorNulo == null)
                {
                    Console.WriteLine("No se puede agregar un jugador nulo.");
                }

                objEquipo1.ListarPlantilla();

                objEquipo2.Jugadores.Add(objJugador3);
                objEquipo2.Jugadores.Add(objJugador4);
                objEquipo2.ListarPlantilla();

                // PRUEBA DE CAMBIO DE NÚMERO
                objJugador1.CambiarNumeroCamiseta(10);  
                objJugador1.CambiarNumeroCamiseta(150);  

                // CREACIÓN Y CONTROL DEL PARTIDO
                Partido objPartido1 = new Partido(
                    local: objEquipo1,
                    visitante: objEquipo2,
                    fecha: DateTime.Now,
                    lugar: "Estadio Monumental",
                    asistenciaEspectadores: 35000,
                    duracionMinutos: 0,
                    estado: "Programado"
                );

                objPartido1.MostrarResumen();

                // Probar reprogramación de partido
                objPartido1.CambiarLugar("Estadio Capwell");
                objPartido1.PosponerPartido(DateTime.Now.AddDays(5));   // Válido
                objPartido1.PosponerPartido(DateTime.Now.AddDays(-3));  // Inválido

                // 6. PRUEBA DE CONTROL DE ERRORES (Mismo equipo local y visitante)
                try
                {
                   
                    Partido objPartidoInvalido = new Partido(
                        local: objEquipo1,
                        visitante: objEquipo1,
                        fecha: DateTime.Now,
                        lugar: "Estadio Capwell",
                        asistenciaEspectadores: 1000,
                        duracionMinutos: 0,
                        estado: "Programado"
                    );
                    objPartidoInvalido.MostrarResumen();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"[VALIDACIÓN CORRECTA] Bloqueo exitoso: {ex.Message}");
                }

            } 
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error inesperado en la inicialización: {ex.Message}");
            }

            Console.WriteLine("\nPresiona Enter para finalizar...");
            Console.ReadLine();
        }
    }
}