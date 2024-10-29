using System;
using System.Collections.Generic;

namespace Ejercicios
{
    internal class Ejercicio11
    {
        public static void ejercicio11()
        {
            NubeAlmacenamiento nube = new NubeAlmacenamiento();

            Archivo archivo1 = new Archivo("Foto1", "imagen", 120);
            Archivo archivo2 = new Archivo("Documento1", "documento", 200);
            Archivo archivo3 = new Archivo("Video1", "video", 250);

            nube.SubirArchivo(archivo1);
            nube.SubirArchivo(archivo2);
            nube.SubirArchivo(archivo3);

            nube.ListarArchivos();

            nube.EliminarArchivo("Documento1");
            nube.ListarArchivos();

            Console.Write("Buscar Foto1: ");
            nube.BuscarArchivo("Foto1");

            Console.WriteLine($"Espacio disponible: {nube.CalcularEspacioDisponible()} MB");
        }

        public class Archivo
        {
            public string Nombre { get; set; }
            public string Tipo { get; set; }
            public double Tamano { get; set; }

            public Archivo(string nombre, string tipo, double tamano)
            {
                Nombre = nombre;
                Tipo = tipo;
                Tamano = tamano;
            }

            public override string ToString()
            {
                return $"Nombre: {Nombre}, Tipo: {Tipo}, Tamaño: {Tamano} MB";
            }
        }

        public class NubeAlmacenamiento
        {
            private List<Archivo> archivos = new List<Archivo>();
            private const double LimiteAlmacenamiento = 500;

            public void SubirArchivo(Archivo archivo)
            {
                if (CalcularEspacioDisponible() >= archivo.Tamano)
                {
                    archivos.Add(archivo);
                    Console.WriteLine($"Archivo '{archivo.Nombre}' subido correctamente.");
                }
                else
                    Console.WriteLine($"Error: No hay suficiente espacio para subir el archivo {archivo.Nombre}.");
            }

            public void EliminarArchivo(string nombre)
            {
                Archivo archivoAEliminar = archivos.Find(a => a.Nombre.Equals(nombre));

                if (archivoAEliminar != null)
                {
                    archivos.Remove(archivoAEliminar);
                    Console.WriteLine($"Archivo '{nombre}' eliminado.");
                }
                else
                    Console.WriteLine($"Error: Archivo '{nombre}' no encontrado.");
            }

            public void ListarArchivos()
            {
                Console.WriteLine("Lista de archivos en la nube:");
                foreach (Archivo archivo in archivos)
                    Console.WriteLine(archivo.ToString());
            }

            public void BuscarArchivo(string nombre)
            {
                Archivo archivoBuscado = archivos.Find(a => a.Nombre.Equals(nombre));

                if (archivoBuscado != null)
                    Console.WriteLine(archivoBuscado.ToString());
                else
                    Console.WriteLine($"Archivo '{nombre}' no encontrado.");
            }

            public double CalcularEspacioDisponible()
            {
                double espacioUsado = 0;
                foreach (Archivo archivo in archivos)
                    espacioUsado += archivo.Tamano;
                return LimiteAlmacenamiento - espacioUsado;
            }
        }
    }
}
