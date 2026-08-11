using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TorneoPOO_JAnchundia.Models;

namespace TorneoPOO_JAnchundia.Datos
{
    public class TorneoDbContext : DbContext
    {

        //1er paso DbSet para cada clase que se quiera mapear a la base de datos
        public DbSet<Models.Equipo> Equipos { get; set; }
        public DbSet<Models.Jugador> Jugadores { get; set; }
        public DbSet<Models.Partido> Partidos { get; set; }

        //2do paso Configurar la cadena de conexion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //CADENA CONEXION USUARIO SQL SERVER
            optionsBuilder.UseSqlServer("Server=DESKTOP-QE2VON0\\SQLEXPRESS;Database=TORNEO_JANCHUNDIA;User Id=sa;Password=1234;TrustServerCertificate=True;");
            //CADENA CONEXION USUARIO WINDOWS
            //optionsBuilder.UseSqlServer("Server=localhost;Database=TorneoDB;Trusted_Connection=True;");
        }

        //3er paso Configurar las relaciones entre las tablas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //Relacion 1 a muchos entre Equipo y Jugador
            modelBuilder.Entity<Models.Equipo>()
                .HasMany(e => e.Jugadores)
                .WithOne()
                .HasForeignKey(j => j.EquipoId)
                .OnDelete(DeleteBehavior.Cascade);

            //Relacion 1 a muchos entre Partido y Equipo (local y visitante)
            modelBuilder.Entity<Models.Partido>()
                .HasOne(p => p.Local)
                .WithMany()
                .HasForeignKey(p => p.LocalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Models.Partido>()
                .HasOne(p => p.Visitante)
                .WithMany()
                .HasForeignKey(p => p.VisitanteId)
                .OnDelete(DeleteBehavior.Restrict);



        }
    }
}