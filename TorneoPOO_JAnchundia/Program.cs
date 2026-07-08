using TorneoPOO_JAnchundia.Models;

Jugador objJugador1 = new Jugador("Piero Hincapié", 24, 4, "Defensa");

Jugador objJugador2 = new Jugador("Enner Valencia", 32, 300, "Delantero");

Equipo objEquipo1 = new Equipo("Emelec", "Guayaquil");

objEquipo1.AgregarJugador(objJugador1);
objEquipo1.AgregarJugador(objJugador2);



objEquipo1.ListarPlantilla();

Jugador objJugador3 = new Jugador("Moiséc Caicedo", 23, 5, "Medio Campo");


Jugador objJugador4 = new Jugador("Neiser Reascos", 45, 24, "Lateral");


Equipo objEquipo2 = new Equipo("Barcelona", "Guayaquil");

objEquipo2.AgregarJugador(objJugador3);
objEquipo2.AgregarJugador(objJugador4);



objEquipo2.ListarPlantilla();

Partido objPartido1 = new Partido(objEquipo1, objEquipo2, DateTime.Now, "Guayaquil");
objPartido1.MostrarResumen();