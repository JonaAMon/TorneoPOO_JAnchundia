using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;

namespace TorneoPOO_JAnchundia.Generales
{
    public static class ArchivoJson
    {
        private static readonly JsonSerializerOptions Opciones = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        public static List<T> LeerArchivo<T>(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
            {
                return new List<T>();
            }
            string contenido = File.ReadAllText(rutaArchivo);
            return JsonSerializer.Deserialize<List<T>>(contenido, Opciones) ?? new List<T>();
        }
        public static void Guardar<T>(string rutaArchivo, List<T> lista)
        {
            if (!Directory.Exists(Path.GetDirectoryName(rutaArchivo)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(rutaArchivo));
            }
            string contenido = JsonSerializer.Serialize(lista, Opciones);
            File.WriteAllText(rutaArchivo, contenido);
        }



    }
}


    
