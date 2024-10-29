using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicios
{
    internal class Ejercicio12
    {
        public static void ejercicio12()
        {
            SistemaRecomendacionLibros sistema = new SistemaRecomendacionLibros();

            Libro libro1 = new Libro("El Principito", "Antoine de Saint-Exupéry", "Ficción", 5);
            Libro libro2 = new Libro("1984", "George Orwell", "Distopía", 4.8);
            Libro libro3 = new Libro("Orgullo y Prejuicio", "Jane Austen", "Romance", 4.5);
            Libro libro4 = new Libro("Cien Años de Soledad", "Gabriel García Márquez", "Realismo Mágico", 5);
            Libro libro5 = new Libro("Brave New World", "Aldous Huxley", "Distopía", 4.7);
            Libro libro6 = new Libro("La niebla", "Stephen King", "Terror", 4.3);
            Libro libro7 = new Libro("Holly", "Stephen King", "Terror", 4.6);
            Libro libro8 = new Libro("It", "Stephen King", "Terror", 4.9);

            sistema.AgregarLibro(libro1);
            sistema.AgregarLibro(libro2);
            sistema.AgregarLibro(libro3);
            sistema.AgregarLibro(libro4);
            sistema.AgregarLibro(libro5);
            sistema.AgregarLibro(libro6);
            sistema.AgregarLibro(libro7);
            sistema.AgregarLibro(libro8);

            sistema.ListarLibrosPorGenero("Terror");
            sistema.ListarMejoresLibros(3);
            sistema.RecomendarLibro("Distopía");
        }

        public class Libro
        {
            public string Titulo { get; set; }
            public string Autor { get; set; }
            public string Genero { get; set; }
            public double Valoracion { get; set; }

            public Libro(string titulo, string autor, string genero, double valoracion)
            {
                Titulo = titulo;
                Autor = autor;
                Genero = genero;
                Valoracion = valoracion;
            }

            public override string ToString()
            {
                return $"Título: {Titulo}, Autor: {Autor}, Género: {Genero}, Valoración: {Valoracion} estrellas";
            }
        }

        public class SistemaRecomendacionLibros
        {
            private List<Libro> libros = new List<Libro>();
            private Random random = new Random();

            public void AgregarLibro(Libro libro)
            {
                libros.Add(libro);
                Console.WriteLine($"Libro '{libro.Titulo}' agregado al sistema.");
            }

            public void ListarLibrosPorGenero(string genero)
            {
                List<Libro> librosGenero = libros.Where(l => l.Genero.Equals(genero)).ToList();

                Console.WriteLine($"Libros de género '{genero}':");
                foreach (var libro in librosGenero)
                    Console.WriteLine(libro.ToString());
            }

            public void ListarMejoresLibros(int cantidad)
            {
                List<Libro> mejoresLibros = libros.OrderByDescending(l => l.Valoracion).Take(cantidad).ToList();

                Console.WriteLine($"Los {cantidad} mejores libros:");
                foreach (var libro in mejoresLibros)
                    Console.WriteLine(libro.ToString());
            }

            public void RecomendarLibro(string genero)
            {
                List<Libro> librosGenero = libros.Where(l => l.Genero.Equals(genero)).ToList();

                if (librosGenero.Count > 0)
                {
                    var libroRecomendado = librosGenero[random.Next(librosGenero.Count)];
                    Console.WriteLine($"Recomendación de libro de género '{genero}': {libroRecomendado.ToString()}");
                }
                else
                    Console.WriteLine($"No hay libros disponibles en el género '{genero}'.");
            }
        }
    }
}

