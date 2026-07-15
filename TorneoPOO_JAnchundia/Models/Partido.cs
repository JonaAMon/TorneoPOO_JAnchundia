using System;
using System.Collections.Generic;
using System.Text;

namespace TorneoPOO_JAnchundia.Models
{
   
    public class Partido
    {
        private Equipo local;
        private Equipo visitante; 
        private DateTime fecha; 
        private string lugar;
        private int asistenciaEspectadores;
        private int duracionMinutos;
        private string estado;

        public Equipo Local
        {
            get => local;
            set
            {
                if (value == null)
                    throw new ArgumentException("El equipo local no puede ser nulo.");
                local = value;
            }
        }

        public Equipo Visitante
        {
            get => visitante;
            set
            {
                if (value == null)
                    throw new ArgumentException("El equipo visitante no puede ser nulo.");

                // Solución: Cambiar .NombreEquipo por .Nombre
                if (local != null && value.Nombre == local.Nombre)
                    throw new ArgumentException("El equipo local y visitante deben ser distintos.");

                visitante = value;
            }
        }

        public DateTime Fecha
        {
            get => fecha;
            set => fecha = value;
        }

        public string Lugar
        {
            get => lugar;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("El lugar del partido no puede estar vacío.");
                lugar = value;
            }
        }
        public int AsistenciaEspectadores
        {
            get => asistenciaEspectadores;
            set
            {
                if (value < 0)
                    throw new Exception("La asistencia de espectadores no puede ser un número negativo.");
                asistenciaEspectadores = value;
            }
        }

        public int DuracionMinutos
        {
            get => duracionMinutos;
            set
            {
                if (value < 0)
                    throw new Exception("La duración del partido no puede ser un tiempo negativo.");
                duracionMinutos = value;
            }
        }

        public string Estado
        {
            get => estado;
            set
            {
                string est = value?.ToLower().Trim();
                if (est != "programado" && est != "en juego" && est != "finalizado" && est != "suspendido")
                {
                    throw new Exception("Estado inválido. Debe ser: Programado, En juego, Finalizado o Suspendido.");
                }
                estado = char.ToUpper(est[0]) + est.Substring(1);
            }
        }
        public Partido(Equipo local, Equipo visitante, DateTime fecha, string lugar, int asistenciaEspectadores, int duracionMinutos, string estado)
        { 

            this.Local = local;
            this.Visitante = visitante;
            this.Fecha = fecha;
            this.Lugar = lugar;
            this.asistenciaEspectadores = asistenciaEspectadores;
            this.duracionMinutos = duracionMinutos;
            this.estado = estado;
        }


        public void MostrarResumen()
        {
            Console.WriteLine($"Hay un partido [{this.Estado}] entre el local {this.Local.Nombre} y el visitante {this.Visitante.Nombre} en el lugar {this.Lugar} el día {this.Fecha.ToShortDateString()}. Duración: {this.DuracionMinutos} min | Asistencia: {this.AsistenciaEspectadores:N0} personas.");
        }
        public void CambiarLugar(string nuevoLugar)
        {
            this.Lugar = nuevoLugar;
            Console.WriteLine($"El partido ahora se jugará en {nuevoLugar}");
        }

        public void PosponerPartido(DateTime nuevaFecha)
        {
            if (nuevaFecha < DateTime.Now)
            {
                Console.WriteLine("No se puede reprogramar el partido a una fecha pasada.");
                return;
            }

            this.Fecha = nuevaFecha;
            Console.WriteLine($"El partido fue reprogramado para {Fecha.ToShortDateString()}");
        }
    }
}