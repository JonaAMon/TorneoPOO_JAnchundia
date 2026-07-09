using TorneoPOO_JAnchundia.Models;

{
    
        Jugador objJugador1 = new Jugador("Piero Hincapié", 24, 4, "Defensa");
        Jugador objJugador2 = new Jugador("Enner Valencia", 32, 90, "Delantero");

        Equipo objEquipo1 = new Equipo("Emelec", "Guayaquil");

        // Agregar jugador válido
        objEquipo1.AgregarJugador(objJugador1);

        // Jugador nulo
        Jugador objJugadorNulo = null;
        objEquipo1.AgregarJugador(objJugadorNulo);

        objEquipo1.ListarPlantilla();

        Jugador objJugador3 = new Jugador("Moisés Caicedo", 23, 5, "Medio Campo");
        Jugador objJugador4 = new Jugador("Neiser Reascos", 45, 24, "Lateral");

        Equipo objEquipo2 = new Equipo("Barcelona", "Guayaquil");
        objEquipo2.AgregarJugador(objJugador3);
        objEquipo2.AgregarJugador(objJugador4);

        objEquipo2.ListarPlantilla();

        
        objJugador1.CambiarNumeroCamiseta(10);   // válido
        objJugador1.CambiarNumeroCamiseta(150);  // inválido

        
        Partido objPartido1 = new Partido(objEquipo1, objEquipo2, DateTime.Now, "Estadio Monumental");
        objPartido1.MostrarResumen();

        // Probar métodos de Partido
        objPartido1.CambiarLugar("Estadio Capwell");
        objPartido1.PosponerPartido(DateTime.Now.AddDays(5));   // válido
        objPartido1.PosponerPartido(DateTime.Now.AddDays(-3));  // inválido

        
        try
        {
            Partido objPartidoInvalido = new Partido(objEquipo1, objEquipo1, DateTime.Now, "Estadio Capwell");
            objPartidoInvalido.MostrarResumen();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.ReadLine();
    }
