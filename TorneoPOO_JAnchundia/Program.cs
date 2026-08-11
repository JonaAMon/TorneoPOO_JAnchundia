using Microsoft.EntityFrameworkCore;
using TorneoPOO_JAnchundia.Datos;
using TorneoPOO_JAnchundia.Generales;
using TorneoPOO_JAnchundia.Models;

int opcion = 0;
do
{
    Console.Clear();
    Console.WriteLine("****************Bienvenido al Torneo de Futbol - ISTLC 2026****************");
    Console.WriteLine("Menú de Opciones:");
    Console.WriteLine("1.- Crear Jugadores");
    Console.WriteLine("2.- Listar Jugadores");
    Console.WriteLine("3.- Buscar Jugador");
    Console.WriteLine("4.- Actualizar Jugador");
    Console.WriteLine("5.- Eliminar Jugador");
    Console.WriteLine("6.- Crear Equipos");
    Console.WriteLine("7.- Listar Equipos");
    Console.WriteLine("8.- Buscar Equipo");
    Console.WriteLine("9.- Actualizar Equipos");
    Console.WriteLine("10.- Eliminar Equipos");
    Console.WriteLine("11.- Crear Partidos");
    Console.WriteLine("12.- Listar Partidos");
    Console.WriteLine("13.- Buscar Partido");
    Console.WriteLine("14.- Actualizar Partido");
    Console.WriteLine("15.- Eliminar Partido");
    Console.WriteLine("16.- Salir");
    Console.WriteLine("");
    Console.Write("Ingrese una opción: ");

    if (!int.TryParse(Console.ReadLine(), out opcion))
    {
        opcion = 0;
    }

    switch (opcion)
    {
        case 1:
            crearJugador();
            break;
        case 2:
            listarJugadores();
            break;
        case 3:
            BuscarJugador();
            break;
        case 4:
            ActualizarJugador();
            break;
        case 5:
            EliminarJugador();
            break;
        case 6:
            crearEquipo();
            break;
        case 7:
            ListarEquipos();
            break;
        case 8:
            BuscarEquipo();
            break;
        case 9:
            ActualizarEquipo();
            break;
        case 10:
            EliminarEquipo();
            break;
        case 11:
            crearPartido();
            break;
        case 12:
            listarPartidos();
            break;
        case 13:
            buscarPartido();
            break;
        case 14:
            ActualizarPartido();
            break;
        case 15:
            EliminarPartido();
            break;
        case 16:
            Console.WriteLine("Saliendo del programa...");
            break;
        default:
            Console.WriteLine("Opción inválida. Por favor, intente nuevamente.");
            Console.ReadLine();
            break;
    }

} while (opcion != 16);



void crearJugador()
{
    Console.Clear();
    Console.WriteLine("**********Crear Jugador**********");
    Console.WriteLine("Ingrese el nombre del jugador: ");
    string nombre = Console.ReadLine();

    Console.WriteLine("Ingrese la edad del jugador: ");
    int.TryParse(Console.ReadLine(), out int edad);

    Console.WriteLine("Ingrese el número del jugador: ");
    int.TryParse(Console.ReadLine(), out int numero);

    Console.WriteLine("Ingrese la posición del jugador: ");
    string posicion = Console.ReadLine();

    Console.WriteLine("Ingrese el lugar de nacimiento del jugador: ");
    string lugarNacimiento = Console.ReadLine();

    Console.WriteLine("Ingrese la cédula del jugador: ");
    string cedula = Console.ReadLine();

    Console.WriteLine("Ingrese los goles del jugador: ");
    int.TryParse(Console.ReadLine(), out int goles);

    Console.WriteLine("¿Es titular? S/N: ");
    bool esTitular = Console.ReadLine().ToUpper() == "S";

    Jugador objJugador = new Jugador(nombre, edad, numero, posicion, lugarNacimiento, cedula, goles, esTitular);

    using (var context = new TorneoDbContext())
    {
        context.Jugadores.Add(objJugador);
        context.SaveChanges();
    }

    Console.WriteLine("Jugador creado exitosamente.");
    Console.ReadLine();
}

void listarJugadores()
{
    Console.Clear();
    Console.WriteLine("**********Jugadores Creados**********");

    using (var context = new TorneoDbContext())
    {
        var listaJugadores = context.Jugadores.ToList();
        if (listaJugadores.Count == 0)
        {
            Console.WriteLine("No hay jugadores registrados.");
        }
        else
        {
            foreach (Jugador jugador in listaJugadores)
            {
                jugador.Imprimir();
                Console.WriteLine("-----------------------------------");
            }
        }
    }
    Console.ReadLine();
}

void BuscarJugador()
{
    Console.Clear();
    Console.WriteLine("**********Buscar Jugador**********");
    Console.WriteLine("Ingrese la cédula del jugador a buscar: ");
    string cedulaIngresada = Console.ReadLine();

    using (var context = new TorneoDbContext())
    {
        Jugador objJugador = context.Jugadores.FirstOrDefault(j => j.Cedula == cedulaIngresada);
        if (objJugador != null)
        {
            Console.WriteLine("Jugador encontrado:");
            Console.WriteLine("-----------------------------------");
            objJugador.Imprimir();
        }
        else
        {
            Console.WriteLine("Jugador no encontrado.");
        }
    }
    Console.ReadLine();
}

void ActualizarJugador()
{
    Console.Clear();
    Console.WriteLine("**********Actualizar Jugador**********");
    Console.WriteLine("Ingrese la cédula del jugador a actualizar: ");
    string cedulaIngresada = Console.ReadLine();

    using (var context = new TorneoDbContext())
    {
        Jugador objJugador = context.Jugadores.FirstOrDefault(j => j.Cedula == cedulaIngresada);
        if (objJugador != null)
        {
            Console.WriteLine("Jugador encontrado:");
            Console.WriteLine("-----------------------------------");
            objJugador.Imprimir();
            Console.WriteLine("-----------------------------------");

            Console.WriteLine("Ingrese el nuevo nombre del jugador: ");
            objJugador.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese la nueva edad del jugador: ");
            if (int.TryParse(Console.ReadLine(), out int nuevaEdad)) objJugador.Edad = nuevaEdad;

            Console.WriteLine("Ingrese el nuevo número del jugador: ");
            if (int.TryParse(Console.ReadLine(), out int nuevoNumero)) objJugador.Numero = nuevoNumero;

            Console.WriteLine("Ingrese la nueva posición del jugador: ");
            objJugador.Posicion = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo lugar de nacimiento del jugador: ");
            objJugador.Nacionalidad = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo número de goles del jugador: ");
            if (int.TryParse(Console.ReadLine(), out int nuevosGoles)) objJugador.Goles = nuevosGoles;

            Console.WriteLine("¿Es titular? S/N: ");
            objJugador.EsTitular = Console.ReadLine().ToUpper() == "S";

            context.SaveChanges();
            Console.WriteLine("Jugador actualizado exitosamente.");
        }
        else
        {
            Console.WriteLine("Jugador no encontrado.");
        }
    }
    Console.ReadLine();
}

void EliminarJugador()
{
    Console.Clear();
    Console.WriteLine("**********Eliminar Jugador**********");
    Console.WriteLine("Ingrese la cédula del jugador a eliminar: ");
    string cedulaIngresada = Console.ReadLine();

    using (var context = new TorneoDbContext())
    {
        Jugador objJugador = context.Jugadores.FirstOrDefault(j => j.Cedula == cedulaIngresada);
        if (objJugador != null)
        {
            Console.WriteLine("-----------------------------------");
            objJugador.Imprimir();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"¿Está seguro de que desea eliminar al jugador {objJugador.Nombre}? S/N:");
            if (Console.ReadLine().ToUpper() == "S")
            {
                context.Jugadores.Remove(objJugador);
                context.SaveChanges();
                Console.WriteLine("Jugador eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Operación cancelada.");
            }
        }
        else
        {
            Console.WriteLine("Jugador no encontrado.");
        }
    }
    Console.ReadLine();
}



void crearEquipo()
{
    Console.Clear();
    Console.WriteLine("**********Crear Equipo**********");
    Console.WriteLine("Ingrese el nombre del equipo: ");
    string nombre = Console.ReadLine();
    Console.WriteLine("Ingrese la ciudad del equipo: ");
    string ciudad = Console.ReadLine();
    Console.WriteLine("Ingrese el director técnico del equipo: ");
    string directorTecnico = Console.ReadLine();
    Console.WriteLine("Ingrese los puntos del equipo: ");
    int.TryParse(Console.ReadLine(), out int puntos);
    Console.WriteLine("Ingrese el nombre del estadio: ");
    string estadio = Console.ReadLine();

    Equipo objEquipo = new Equipo(nombre, ciudad, directorTecnico, puntos, estadio);

    using (var context = new TorneoDbContext())
    {
        string respuesta = "";
        do
        {
            Console.WriteLine("¿Desea ingresar jugadores al equipo? S/N");
            respuesta = Console.ReadLine().ToUpper();
            if (respuesta == "S")
            {
                Console.WriteLine("Ingrese la cédula del jugador a fichar: ");
                string cedulaIngresada = Console.ReadLine();
                Jugador objJugador = context.Jugadores.FirstOrDefault(j => j.Cedula == cedulaIngresada);

                if (objJugador != null)
                {
                    objEquipo.AgregarJugador(objJugador);
                    Console.WriteLine($"Jugador {objJugador.Nombre} agregado al equipo.");
                }
                else
                {
                    Console.WriteLine("Jugador no encontrado en la base de datos.");
                }
            }
        } while (respuesta == "S");

        context.Equipos.Add(objEquipo);
        context.SaveChanges();
    }

    Console.WriteLine("Equipo creado y guardado exitosamente en la base de datos.");
    Console.ReadLine();
}

void ListarEquipos()
{
    Console.Clear();
    Console.WriteLine("***Equipos Creados***");

    using (var context = new TorneoDbContext())
    {
      
        var listaEquipos = context.Equipos
            .Include(e => e.Jugadores)
            .ToList();

        if (listaEquipos.Count == 0)
        {
            Console.WriteLine("No hay equipos registrados.");
        }
        else
        {
            foreach (Equipo eq in listaEquipos)
            {
                eq.Imprimir();
                eq.ListarPlantilla(); 
                Console.WriteLine("==================================================");
            }
        }
    }
    Console.ReadLine();
}

void BuscarEquipo()
{
    Console.Clear();
    Console.WriteLine("**Buscar Equipo**");
    Console.Write("Ingrese el nombre del equipo a buscar: ");
    string nombreIngresado = Console.ReadLine();

    using (var context = new TorneoDbContext())
    {
        
        var objEquipo = context.Equipos
            .Include(e => e.Jugadores)
            .FirstOrDefault(e => e.Nombre == nombreIngresado);

        if (objEquipo != null)
        {
            objEquipo.Imprimir();
            
        }
        else
        {
            Console.WriteLine("Equipo no encontrado.");
        }
    }
    Console.ReadLine();
}

void ActualizarEquipo()
{
    Console.Clear();
    Console.WriteLine("**********Actualizar Equipo**********");
    Console.WriteLine("Ingrese el nombre del equipo a actualizar: ");
    string nombreBusqueda = Console.ReadLine();

    using (var context = new TorneoDbContext())
    {
        Equipo eq = context.Equipos.FirstOrDefault(e => e.Nombre.ToUpper() == nombreBusqueda.ToUpper());

        if (eq != null)
        {
            Console.WriteLine("Equipo encontrado:");
            Console.WriteLine("-----------------------------------");
            eq.Imprimir();
            Console.WriteLine("-----------------------------------");

            Console.WriteLine("Ingrese el nuevo nombre del equipo: ");
            eq.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese la nueva ciudad del equipo: ");
            eq.Ciudad = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo director técnico del equipo: ");
            eq.DirectorTecnico = Console.ReadLine();

            Console.WriteLine("Ingrese los nuevos puntos del equipo: ");
            if (int.TryParse(Console.ReadLine(), out int nuevosPuntos)) eq.Puntos = nuevosPuntos;

            Console.WriteLine("Ingrese el nuevo nombre del estadio: ");
            eq.Estadio = Console.ReadLine();

            context.SaveChanges();
            Console.WriteLine("Equipo actualizado exitosamente en la base de datos.");
        }
        else
        {
            Console.WriteLine("Equipo no encontrado.");
        }
    }
    Console.ReadLine();
}

void EliminarEquipo()
{
    Console.Clear();
    Console.WriteLine("**********Eliminar Equipo**********");
    Console.Write("Ingrese el nombre del equipo a eliminar: ");
    string nombreBusqueda = Console.ReadLine();

    using (var context = new TorneoDbContext())
    {
        Equipo eq = context.Equipos.FirstOrDefault(e => e.Nombre.ToUpper() == nombreBusqueda.ToUpper());

        if (eq != null)
        {
            Console.WriteLine("-----------------------------------");
            eq.Imprimir();
            Console.WriteLine("-----------------------------------");
            Console.Write($"¿Está seguro de que desea eliminar al equipo {eq.Nombre}? S/N: ");
            if (Console.ReadLine().ToUpper() == "S")
            {
                context.Equipos.Remove(eq);
                context.SaveChanges();
                Console.WriteLine("Equipo eliminado exitosamente de la base de datos.");
            }
            else
            {
                Console.WriteLine("Operación cancelada.");
            }
        }
        else
        {
            Console.WriteLine("Equipo no encontrado.");
        }
    }
    Console.ReadLine();
}



void crearPartido()
{
    Console.Clear();
    Console.WriteLine("**********Crear Partido**********");

    using (var context = new TorneoDbContext())
    {
        var equipos = context.Equipos.ToList();
        if (equipos.Count < 2)
        {
            Console.WriteLine("Error: Se necesitan al menos 2 equipos registrados en la base de datos para programar un partido.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Ingrese el nombre del equipo local: ");
        string nombreLocal = Console.ReadLine();
        Equipo local = context.Equipos.FirstOrDefault(e => e.Nombre.ToUpper() == nombreLocal.ToUpper());
        if (local == null)
        {
            Console.WriteLine("Equipo local no encontrado.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Ingrese el nombre del equipo visitante: ");
        string nombreVisitante = Console.ReadLine();
        Equipo visitante = context.Equipos.FirstOrDefault(e => e.Nombre.ToUpper() == nombreVisitante.ToUpper());
        if (visitante == null)
        {
            Console.WriteLine("Equipo visitante no encontrado.");
            Console.ReadLine();
            return;
        }

        if (local.Id == visitante.Id)
        {
            Console.WriteLine("Un equipo no puede jugar contra sí mismo.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Ingrese la fecha del partido (AAAA-MM-DD): ");
        DateTime.TryParse(Console.ReadLine(), out DateTime fecha);

        Console.WriteLine("Ingrese el lugar del partido: ");
        string lugar = Console.ReadLine();

        Console.WriteLine("Ingrese la asistencia de espectadores: ");
        int.TryParse(Console.ReadLine(), out int espectadores);

        Console.WriteLine("Ingrese la duración del partido en minutos: ");
        int.TryParse(Console.ReadLine(), out int duracion);

        Console.WriteLine("Ingrese el estado del partido: ");
        string estado = Console.ReadLine();

        Partido nuevoPartido = new Partido
        {
            LocalId = local.Id,
            VisitanteId = visitante.Id,
            Fecha = fecha,
            Lugar = lugar,
            AsistenciaEspectadores = espectadores,
            DuracionMinutos = duracion,
            Estado = estado
        };

        context.Partidos.Add(nuevoPartido);
        context.SaveChanges();
        Console.WriteLine("Partido creado y guardado exitosamente en la base de datos.");
    }
    Console.ReadLine();
}

void listarPartidos()
{
    Console.Clear();
    Console.WriteLine("**********Partidos Registrados**********");

    using (var context = new TorneoDbContext())
    {
        var partidos = context.Partidos
            .Include(p => p.Local)
            .Include(p => p.Visitante)
            .ToList();

        if (partidos.Count == 0)
        {
            Console.WriteLine("No hay partidos registrados en la base de datos.");
        }
        else
        {
            foreach (Partido part in partidos)
            {
                part.MostrarResumen();
                Console.WriteLine("----------------------------------------------------------------------");
            }
        }
    }
    Console.ReadLine();
}

void buscarPartido()
{
    Console.Clear();
    Console.WriteLine("**********Buscar Partido**********");
    Console.WriteLine("Ingrese el nombre de uno de los equipos para buscar su partido: ");
    string nombreEquipo = Console.ReadLine();

    using (var context = new TorneoDbContext())
    {
        Partido partidoEncontrado = context.Partidos
            .Include(p => p.Local)
            .Include(p => p.Visitante)
            .FirstOrDefault(p => p.Local.Nombre.ToUpper() == nombreEquipo.ToUpper() ||
                                 p.Visitante.Nombre.ToUpper() == nombreEquipo.ToUpper());

        if (partidoEncontrado != null)
        {
            Console.WriteLine("\nPartido encontrado:");
            Console.WriteLine("-----------------------------------");
            partidoEncontrado.Imprimir();
        }
        else
        {
            Console.WriteLine("No se encontraron partidos para ese equipo.");
        }
    }
    Console.ReadLine();
}

void ActualizarPartido()
{
    Console.Clear();
    Console.WriteLine("**********Actualizar Partido**********");
    Console.WriteLine("Ingrese el nombre del equipo local del partido: ");
    string localBusqueda = Console.ReadLine();
    Console.WriteLine("Ingrese el nombre del equipo visitante: ");
    string visitanteBusqueda = Console.ReadLine();

    using (var context = new TorneoDbContext())
    {
        Partido part = context.Partidos
            .Include(p => p.Local)
            .Include(p => p.Visitante)
            .FirstOrDefault(p => p.Local.Nombre.ToUpper() == localBusqueda.ToUpper() &&
                                 p.Visitante.Nombre.ToUpper() == visitanteBusqueda.ToUpper());

        if (part != null)
        {
            Console.WriteLine("\nPartido encontrado. Ingrese los nuevos datos:");
            Console.WriteLine("-----------------------------------");

            Console.Write($"Nueva fecha (actual: {part.Fecha.ToShortDateString()}): ");
            string fechaInput = Console.ReadLine();
            if (DateTime.TryParse(fechaInput, out DateTime nuevaFecha)) part.Fecha = nuevaFecha;

            Console.Write($"Nuevo lugar (actual: {part.Lugar}): ");
            string nuevoLugar = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoLugar)) part.Lugar = nuevoLugar;

            Console.Write($"Nueva asistencia (actual: {part.AsistenciaEspectadores}): ");
            string asistenciaInput = Console.ReadLine();
            if (int.TryParse(asistenciaInput, out int nuevaAsistencia)) part.AsistenciaEspectadores = nuevaAsistencia;

            Console.Write($"Nueva duración en minutos (actual: {part.DuracionMinutos}): ");
            string duracionInput = Console.ReadLine();
            if (int.TryParse(duracionInput, out int nuevaDuracion)) part.DuracionMinutos = nuevaDuracion;

            Console.Write($"Nuevo estado (actual: {part.Estado}): ");
            string nuevoEstado = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoEstado)) part.Estado = nuevoEstado;

            context.SaveChanges();
            Console.WriteLine("\n¡Partido actualizado correctamente en la base de datos!");
        }
        else
        {
            Console.WriteLine("No se encontró ningún partido registrado entre esos dos equipos.");
        }
    }
    Console.ReadLine();
}

void EliminarPartido()
{
    Console.Clear();
    Console.WriteLine("**********Eliminar Partido**********");
    Console.WriteLine("Ingrese el nombre del equipo local del partido: ");
    string localBusqueda = Console.ReadLine();
    Console.WriteLine("Ingrese el nombre del equipo visitante: ");
    string visitanteBusqueda = Console.ReadLine();

    using (var context = new TorneoDbContext())
    {
        Partido part = context.Partidos
            .Include(p => p.Local)
            .Include(p => p.Visitante)
            .FirstOrDefault(p => p.Local.Nombre.ToUpper() == localBusqueda.ToUpper() &&
                                 p.Visitante.Nombre.ToUpper() == visitanteBusqueda.ToUpper());

        if (part != null)
        {
            Console.WriteLine("-----------------------------------");
            part.Imprimir();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("¿Está seguro de que desea eliminar este partido? S/N: ");
            if (Console.ReadLine().ToUpper() == "S")
            {
                context.Partidos.Remove(part);
                context.SaveChanges();
                Console.WriteLine("Partido eliminado exitosamente de la base de datos.");
            }
            else
            {
                Console.WriteLine("Operación cancelada.");
            }
        }
        else
        {
            Console.WriteLine("Partido no encontrado.");
        }
    }
    Console.ReadLine();
}
















//namespace TorneoPOO_JAnchundia
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("=== INICIANDO SISTEMA DE TORNEO POO ===\n");

//            try 
//            {
//                // CREACIÓN DE JUGADORES
//                Jugador objJugador1 = new Jugador("Piero Hincapié", 24, 4, "Defensa", "Ecuatoriana", 0, true);
//                Jugador objJugador2 = new Jugador("Enner Valencia", 32, 90, "Delantero", "Ecuatoriana", 8, true);
//                Jugador objJugador3 = new Jugador("Moisés Caicedo", 23, 5, "Mediocampista", "Ecuatoriana", 3, true);
//                Jugador objJugador4 = new Jugador("Neiser Reascos", 45, 24, "Defensa", "Ecuatoriana", 1, false);

//                // CREACIÓN DE EQUIPOS
//                Equipo objEquipo1 = new Equipo("Emelec", "Guayaquil", "Leonel Álvarez", 0, "Estadio George Capwell");
//                Equipo objEquipo2 = new Equipo("Barcelona", "Guayaquil", "Segundo Castillo", 3, "Estadio Monumental");

//                // ASOCIACIÓN DE JUGADORES A EQUIPOS
//                objEquipo1.Jugadores.Add(objJugador1);
//                objEquipo1.Jugadores.Add(objJugador2);

//                // Simular validación de jugador nulo
//                Jugador objJugadorNulo = null;
//                if (objJugadorNulo == null)
//                {
//                    Console.WriteLine("No se puede agregar un jugador nulo.");
//                }

//                objEquipo1.ListarPlantilla();

//                objEquipo2.Jugadores.Add(objJugador3);
//                objEquipo2.Jugadores.Add(objJugador4);
//                objEquipo2.ListarPlantilla();

//                // PRUEBA DE CAMBIO DE NÚMERO
//                objJugador1.CambiarNumeroCamiseta(10);  
//                objJugador1.CambiarNumeroCamiseta(150);  

//                // CREACIÓN Y CONTROL DEL PARTIDO
//                Partido objPartido1 = new Partido(
//                    local: objEquipo1,
//                    visitante: objEquipo2,
//                    fecha: DateTime.Now,
//                    lugar: "Estadio Monumental",
//                    asistenciaEspectadores: 35000,
//                    duracionMinutos: 0,
//                    estado: "Programado"
//                );

//                objPartido1.MostrarResumen();

//                // Probar reprogramación de partido
//                objPartido1.CambiarLugar("Estadio Capwell");
//                objPartido1.PosponerPartido(DateTime.Now.AddDays(5));   // Válido
//                objPartido1.PosponerPartido(DateTime.Now.AddDays(-3));  // Inválido

//                // 6. PRUEBA DE CONTROL DE ERRORES (Mismo equipo local y visitante)
//                try
//                {

//                    Partido objPartidoInvalido = new Partido(
//                        local: objEquipo1,
//                        visitante: objEquipo1,
//                        fecha: DateTime.Now,
//                        lugar: "Estadio Capwell",
//                        asistenciaEspectadores: 1000,
//                        duracionMinutos: 0,
//                        estado: "Programado"
//                    );
//                    objPartidoInvalido.MostrarResumen();
//                }
//                catch (ArgumentException ex)
//                {
//                    Console.WriteLine($"[VALIDACIÓN CORRECTA] Bloqueo exitoso: {ex.Message}");
//                }

//            } 
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Ocurrió un error inesperado en la inicialización: {ex.Message}");
//            }

//            Console.WriteLine("\nPresiona Enter para finalizar...");
//            Console.ReadLine();
//        }
//    }
//}