using TorneoPOO_JAnchundia.Models;

Jugador objJugador1 = new Jugador();

objJugador1.Nombre = "Joel Ordoñez";
objJugador1.Numero = 4;
objJugador1.Posicion = "Defensa";
objJugador1.Edad = 20;


Jugador objJugador2 = new Jugador();

objJugador2.Nombre = "Jordy Caicedo";
objJugador2.Numero = 9;
objJugador2.Posicion = "Delantero";
objJugador2.Edad = 30;


Equipo objEquipo1 = new Equipo();

objEquipo1.Nombre = "Orense";
objEquipo1.Ciudad = "Machala";
objEquipo1.Jugadores = new List<Jugador>();

objEquipo1.AgregarJugador(objJugador1);
objEquipo1.AgregarJugador(objJugador2);



objEquipo1.ListarPlantilla();

Jugador objJugador3 = new Jugador();

objJugador3.Nombre = "Allan Franco";
objJugador3.Numero = 5;
objJugador3.Posicion = "Medio Campo";
objJugador3.Edad = 28;


Jugador objJugador4 = new Jugador();

objJugador4.Nombre = "Felix Torres";
objJugador4.Numero = 22;
objJugador4.Posicion = "Defensa";
objJugador4.Edad = 29;


Equipo objEquipo2 = new Equipo();

objEquipo2.Nombre = "Barcelona";
objEquipo2.Ciudad = "Guayaquil";
objEquipo2.Jugadores = new List<Jugador>();

objEquipo2.AgregarJugador(objJugador3);
objEquipo2.AgregarJugador(objJugador4);



objEquipo2.ListarPlantilla();

Partido objPartido1 = new Partido();
objPartido1.Programar(objEquipo1, objEquipo2, DateTime.Now, "Machala");
objPartido1.MostrarResumen();