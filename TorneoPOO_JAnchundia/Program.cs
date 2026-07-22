using TorneoPOO_JAnchundia.Generales;
using TorneoPOO_JAnchundia.Models;
{ 
     Database.CargarDatos();
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
        opcion = Convert.ToInt32(Console.ReadLine());
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
                listarEquipos(); 
                break;
            case 8:
                buscarEquipo();
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
        int edad = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingrese el número del jugador: ");
        int numero = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingrese la posición del jugador: ");
        string posicion = Console.ReadLine();
        Console.WriteLine("Ingrese el lugar de nacimiento del jugador: ");
        string lugarNacimiento = Console.ReadLine();
        Console.WriteLine("Ingrese la cédula del jugador: ");
        string cedula = Console.ReadLine();
        Console.WriteLine("Ingrese los goles del jugador: ");
        int goles = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("¿Es titular? S/N: ");
        bool esTitular = Console.ReadLine().ToUpper() == "S";

        Jugador objJugador = new Jugador(nombre, edad, numero, posicion, lugarNacimiento, cedula, goles, esTitular);
        Database.Jugadores.Add(objJugador);
        Database.GuardarJugadores();
        Console.WriteLine("Jugador creado exitosamente.");
        Console.ReadLine();

    }
    void listarJugadores()
    {
        Console.Clear();
        Console.WriteLine("**********Jugadores Creados**********");
        foreach (Jugador jugador in Database.Jugadores)
        {
            jugador.Imprimir();
            Console.WriteLine("-----------------------------------");
        }
        Console.ReadLine();
    }
    void BuscarJugador()
    {
        Console.Clear();
        Console.WriteLine("**********Buscar Jugador**********");
        Console.WriteLine("Ingrese la cédula del jugador a buscar: ");
        string cedulaIngresada = Console.ReadLine();
        Jugador objJugador = Database.Jugadores.Find(j => j.Cedula == cedulaIngresada);
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
        Console.ReadLine();
    }
    void ActualizarJugador()
    {
        Console.Clear();
        Console.WriteLine("**********Actualizar Jugador**********");
        Console.WriteLine("Ingrese la cédula del jugador a actualizar: ");
        string cedulaIngresada = Console.ReadLine();
        Jugador objJugador = Database.Jugadores.Find(j => j.Cedula == cedulaIngresada);
        if (objJugador != null)
        {
            Console.WriteLine("Jugador encontrado:");
            Console.WriteLine("-----------------------------------");
            objJugador.Imprimir();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Ingrese el nuevo nombre del jugador: ");
            objJugador.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la nueva edad del jugador: ");
            objJugador.Edad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo número del jugador: ");
            objJugador.Numero = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese la nueva posición del jugador: ");
            objJugador.Posicion = Console.ReadLine();
            Console.WriteLine("Ingrese la nacionalidad del jugador: ");
            objJugador.Nacionalidad = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo número de goles del jugador: ");
            objJugador.Goles = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("¿Es titular? S/N: ");
            objJugador.EsTitular = Console.ReadLine().ToUpper() == "S";
            Database.GuardarJugadores();
            Console.WriteLine("Jugador actualizado exitosamente.");
           
        }
        else
        {
            Console.WriteLine("Jugador no encontrado.");
        }
        Console.ReadLine();
    }
    void EliminarJugador()
    {
        Console.Clear();
        Console.WriteLine("**********Elimar Jugador**********");
        Console.WriteLine("Ingrese la cédula del jugador a eliminar: ");
        string cedulaIngresada = Console.ReadLine();
        Jugador objJugador = Database.Jugadores.Find(j => j.Cedula == cedulaIngresada);
        if (objJugador != null)
        {
            Console.WriteLine("-----------------------------------");
            objJugador.Imprimir();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"¿Está seguro de que desea eliminar al jugador {objJugador.Nombre} ? S/N:");
            if (Console.ReadLine().ToUpper() == "S")
            {
                Database.Jugadores.Remove(objJugador);
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
        int puntos = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingrese el nomnbre del estadio: ");
        string estadio = Console.ReadLine();

        Equipo objEquipo = new Equipo(nombre, ciudad, directorTecnico, puntos, estadio);
        Database.GuardarJugadores();
        Console.WriteLine("Equipo creado exitosamente.");
        string respuesta = "";
        do
        {
            Console.WriteLine("¿Desea Ingresar Jugadores? S/N");
            respuesta = Console.ReadLine();
            if (respuesta.ToUpper() == "S")
            {
                Console.WriteLine("Ingrese la cédula del jugador a fichar");
                string cedulaIngresada = Console.ReadLine();
                Jugador objJugador = Database.Jugadores.Find(x => x.Cedula == cedulaIngresada);
                if (objJugador != null)
                {
                    objEquipo.AgregarJugador(objJugador);
                }
                else
                {
                    Console.WriteLine("Jugador no encontrado.");
                }
            }

        } while (respuesta == "S");
        Database.Equipos.Add(objEquipo);
        Console.ReadLine();

    }

    void listarEquipos()
    {
        Console.Clear();
        Console.WriteLine("**********Equipos Creados**********");
        if (Database.Equipos.Count == 0)
        {
            Console.WriteLine("No hay equipos registrados.");
        }
        else
        {
            foreach (Equipo eq in Database.Equipos)
            {
                eq.Imprimir();
                Console.WriteLine("===================================");
            }
        }
        Console.ReadLine();
    }

    static void buscarEquipo()
    {
        Console.Clear();
        Console.WriteLine("**********Buscar Equipo**********");
        Console.WriteLine("Ingrese el nombre del equipo a buscar: ");
        string nombre_ingresado = Console.ReadLine();
        Equipo objEquipo = Database.Equipos.Find(j => j.Nombre.ToUpper() == nombre_ingresado.ToUpper());
        if (objEquipo != null)
        {
            Console.WriteLine("Equipo encontrado:");
            Console.WriteLine("-----------------------------------");
            objEquipo.Imprimir();
        }
        else
        {
            Console.WriteLine("Equipo no encontrado.");
        }
        Console.ReadLine();
    }
    void ActualizarEquipo()
    {
        Console.Clear();
        Console.WriteLine("**********Actualizar Equipo**********");
        Console.WriteLine("Ingrese el nombre del equipo a actualizar: ");
        string nombreBusqueda = Console.ReadLine();

        Equipo eq = Database.Equipos.Find(e => e.Nombre.ToUpper() == nombreBusqueda.ToUpper());

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
            eq.Puntos = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el nuevo nombre del estadio: ");
            eq.Estadio = Console.ReadLine();

            Console.WriteLine("Equipo actualizado exitosamente.");
        }
        else
        {
            Console.WriteLine("Equipo no encontrado.");
        }
        Console.ReadLine();
    }
    void EliminarEquipo()
    {
        Console.Clear();
        Console.WriteLine("**********Eliminar Equipo**********");
        Console.Write("Ingrese el nombre del equipo a eliminar: ");
        string nombreBusqueda = Console.ReadLine();

        Equipo eq = Database.Equipos.Find(e => e.Nombre.ToUpper() == nombreBusqueda.ToUpper());

        if (eq != null)
        {
            Console.WriteLine("-----------------------------------");
            eq.Imprimir();
            Console.WriteLine("-----------------------------------");
            Console.Write($"¿Está seguro de que desea eliminar al equipo {eq.Nombre}? S/N: ");
            if (Console.ReadLine().ToUpper() == "S")
            {
                Database.Equipos.Remove(eq);
                Console.WriteLine("Equipo eliminado exitosamente.");
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
        Console.ReadLine();
    }
    void crearPartido()
    {
        Console.Clear();
        Console.WriteLine("**********Crear Partido**********");

        if (Database.Equipos.Count < 2)
        {
            Console.WriteLine("Error: Se necesitan al menos 2 equipos registrados para crear un partido.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Ingrese el nombre del equipo local: ");
        string nombreLocal = Console.ReadLine();
        Equipo local = Database.Equipos.Find(e => e.Nombre.ToUpper() == nombreLocal.ToUpper());
        if (local == null)
        {
            Console.WriteLine("Equipo no encontrado.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Ingrese el nombre del equipo visitante: ");
        string nombreVisitante = Console.ReadLine();
        Equipo visitante = Database.Equipos.Find(e => e.Nombre.ToUpper() == nombreVisitante.ToUpper());
        if (visitante == null)
        {
            Console.WriteLine("Equipo no encontrado.");
            Console.ReadLine();
            return;
        }

        if (local.Nombre.ToUpper() == visitante.Nombre.ToUpper())
        {
            Console.WriteLine("Un equipo no puede jugar contra sí mismo.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Ingrese la fecha del partido (AAAA-MM-DD): ");
        DateTime fecha = Convert.ToDateTime(Console.ReadLine());
        Console.WriteLine("Ingrese el lugar del partido: ");
        string lugar = Console.ReadLine();
        Console.WriteLine("Ingrese la asistencia de espectadores: ");
        int espectadores = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingrese la duración del partido en minutos: ");
        int duracion = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingrese el estado del partido: ");
        string estado = Console.ReadLine();

        Partido nuevoPartido = new Partido(local, visitante, fecha, lugar, espectadores, duracion, estado);
        Console.WriteLine("Partido creado exitosamente.");

        Database.Partido.Add(nuevoPartido);
        Console.ReadLine();
    }
    void listarPartidos()
    {
        Console.Clear();
        Console.WriteLine("**********Partidos Registrados**********");
        if (Database.Partido.Count == 0)
        {
            Console.WriteLine("No hay partidos registrados.");
        }
        else
        {
            foreach (Partido part in Database.Partido)
            {
                part.MostrarResumen(); 
                Console.WriteLine("----------------------------------------------------------------------");
            }
        }
        Console.ReadLine();
    }
    void buscarPartido()
    {
        Console.Clear();
        Console.WriteLine("**********Buscar Partido**********");
        Console.WriteLine("Ingrese el nombre de uno de los equipos que jugó para buscar su partido: ");
        string nombreEquipo = Console.ReadLine();

        Partido partidoEncontrado = Database.Partido.Find(p =>
            p.Local.Nombre.ToUpper() == nombreEquipo.ToUpper() ||
            p.Visitante.Nombre.ToUpper() == nombreEquipo.ToUpper()
        );

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
        Console.ReadLine();
    }

    void ActualizarPartido()
    {
        Console.Clear();
        Console.WriteLine("**********Actualizar Partido**********");
        Console.WriteLine("Ingrese el nombre del equipo local del partido que desea actualizar: ");
        string localBusqueda = Console.ReadLine();
        Console.WriteLine("Ingrese el nombre del equipo visitante: ");
        string visitanteBusqueda = Console.ReadLine();

        
        Partido part = Database.Partido.Find(p =>
            p.Local.Nombre.ToUpper() == localBusqueda.ToUpper() &&
            p.Visitante.Nombre.ToUpper() == visitanteBusqueda.ToUpper()
        );

        if (part != null)
        {
            Console.WriteLine("\nPartido encontrado. Ingrese los nuevos datos:");
            Console.WriteLine("-----------------------------------");

            Console.Write($"Nueva fecha (actual: {part.Fecha.ToShortDateString()}): ");
            string fechaInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(fechaInput)) part.Fecha = Convert.ToDateTime(fechaInput);

            Console.Write($"Nuevo lugar (actual: {part.Lugar}): ");
            string nuevoLugar = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoLugar)) part.Lugar = nuevoLugar;

            Console.Write($"Nueva asistencia (actual: {part.AsistenciaEspectadores}): ");
            string asistenciaInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(asistenciaInput)) part.AsistenciaEspectadores = Convert.ToInt32(asistenciaInput);

            Console.Write($"Nueva duración en minutos (actual: {part.DuracionMinutos}): ");
            string duracionInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(duracionInput)) part.DuracionMinutos = Convert.ToInt32(duracionInput);

            Console.Write($"Nuevo estado (actual: {part.Estado}): ");
            string nuevoEstado = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoEstado)) part.Estado = nuevoEstado;

            Console.WriteLine("\n¡Partido actualizado correctamente!");
        }
        else
        {
            Console.WriteLine("No se encontró ningún partido programado entre esos dos equipos.");
        }
        Console.ReadLine();
    }
    static void EliminarPartido()
    {
        Console.Clear();
        Console.WriteLine("**********Eliminar Partido**********");
        Console.WriteLine("Ingrese el nombre del equipo local del partido que desea eliminar: ");
        string localBusqueda = Console.ReadLine();
        Console.WriteLine("Ingrese el nombre del equipo visitante: ");
        string visitanteBusqueda = Console.ReadLine();

        Partido part = Database.Partido.Find(p =>
            p.Local.Nombre.ToUpper() == localBusqueda.ToUpper() &&
            p.Visitante.Nombre.ToUpper() == visitanteBusqueda.ToUpper()
        );

        if (part != null)
        {
            Console.WriteLine("-----------------------------------");
            part.Imprimir();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("¿Está seguro de que desea eliminar este partido? S/N: ");
            if (Console.ReadLine().ToUpper() == "S")
            {
                Database.Partido.Remove(part);
                Console.WriteLine("Partido eliminado exitosamente.");
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
        Console.ReadLine();
    }
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