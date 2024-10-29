using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicios
{
    internal class Ejercicio3
    {
        public static void ejercicio3()
        {
            Biblioteca biblioteca = new Biblioteca();

            // Agregar libros
            biblioteca.AgregarLibro(new Libro("La niebla", "Stephen King"));
            biblioteca.AgregarLibro(new Libro("Holly", "Stephen King"));
            biblioteca.AgregarLibro(new Libro("El Instituto", "Stephen King"));

            biblioteca.ListarLibrosDisponibles();

            biblioteca.PrestarLibro("La niebla");
            biblioteca.PrestarLibro("Libro Inexistente");
            biblioteca.ListarLibrosDisponibles();

            biblioteca.DevolverLibro("La niebla");
            biblioteca.ListarLibrosDisponibles();
        }

        public class Libro
        {
            public string Titulo { get; set; }
            public string Autor { get; set; }
            public bool Disponible { get; set; } = true;

            public Libro(string titulo, string autor)
            {
                Titulo = titulo;
                Autor = autor;
            }

            public override string ToString() =>
                $"{Titulo} - {Autor} | {(Disponible ? "Disponible" : "Prestado")}";
        }

        public class Biblioteca
        {
            private readonly List<Libro> libros = new List<Libro>();

            public void AgregarLibro(Libro libro)
            {
                libros.Add(libro);
                Console.WriteLine($"Libro '{libro.Titulo}' agregado.");
            }

            public void EliminarLibro(string titulo)
            {
                Libro libro = BuscarLibro(titulo);
                if (libro != null)
                {
                    libros.Remove(libro);
                    Console.WriteLine($"Libro '{titulo}' eliminado.");
                }
            }

            public void ListarLibrosDisponibles()
            {
                Console.WriteLine("\nLibros disponibles:");
                List<Libro> disponibles = libros.Where(l => l.Disponible).ToList();

                if (disponibles.Any())
                {
                    foreach (var libro in disponibles)
                    {
                        Console.WriteLine(libro);
                    }
                    Console.WriteLine($"Total: {disponibles.Count()} libros");
                }
                else
                {
                    Console.WriteLine("No hay libros disponibles.");
                }
            }

            public void PrestarLibro(string titulo)
            {
                Libro libro = BuscarLibro(titulo);
                if (libro != null && libro.Disponible)
                {
                    libro.Disponible = false;
                    Console.WriteLine($"Libro '{titulo}' prestado.");
                }
                else if (libro != null)
                {
                    Console.WriteLine($"'{titulo}' no está disponible.");
                }
            }

            public void DevolverLibro(string titulo)
            {
                Libro libro = BuscarLibro(titulo);
                if (libro != null && !libro.Disponible)
                {
                    libro.Disponible = true;
                    Console.WriteLine($"Libro '{titulo}' devuelto.");
                }
                else if (libro != null)
                {
                    Console.WriteLine($"'{titulo}' ya estaba disponible.");
                }
            }

            private Libro BuscarLibro(string titulo)
            {
                Libro libro = libros.FirstOrDefault(l => l.Titulo.Equals(titulo));

                if (libro == null)
                {
                    Console.WriteLine($"No se encontró '{titulo}'");
                }
                return libro;
            }
        }
    }
}
