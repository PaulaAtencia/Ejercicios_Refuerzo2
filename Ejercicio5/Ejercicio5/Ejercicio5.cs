using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios
{
    internal class Ejercicio5
    {
        public static void ejercicio5()
        {
            ClaseAlumnos clase = new ClaseAlumnos();

            clase.AgregarAlumno(new Alumno("Pepe", 20, 5.5));
            clase.AgregarAlumno(new Alumno("Mario", 21, 8.0));
            clase.AgregarAlumno(new Alumno("Paula", 20, 9.5));

            clase.ListarAlumnos();

            clase.BuscarAlumno("Paula");

            double media = clase.CalcularNotaMedia();
            Console.WriteLine($"Nota media de la clase: {media}");
        }

        public class Alumno
        {
            public string Nombre { get; set; }
            public int Edad { get; set; }
            public double NotaMedia { get; set; }

            public Alumno(string nombre, int edad, double notaMedia)
            {
                Nombre = nombre;
                Edad = edad;
                NotaMedia = notaMedia;
            }
            public override string ToString()
            {
                return $"{Nombre}, Edad: {Edad}, Nota Media: {NotaMedia}";
            }
        }

        public class ClaseAlumnos
        {
            private List<Alumno> alumnos = new List<Alumno>();

            public void AgregarAlumno(Alumno alumno)
            {
                alumnos.Add(alumno);
                Console.WriteLine($"Alumno '{alumno.Nombre}' agregado.");
            }

            public void EliminarAlumno(string nombre)
            {
                Alumno alumno = alumnos.FirstOrDefault(a => a.Nombre.Equals(nombre));
                if (alumno != null)
                {
                    alumnos.Remove(alumno);
                    Console.WriteLine($"Alumno '{nombre}' eliminado.");
                }
                else
                {
                    Console.WriteLine($"No se encontró el alumno '{nombre}'.");
                }
            }

            public void ListarAlumnos()
            {
                Console.WriteLine("\nLista de Alumnos:");
                foreach (var alumno in alumnos)
                {
                    Console.WriteLine(alumno);
                }
            }

            public void BuscarAlumno(string nombre)
            {
                Alumno alumno = alumnos.FirstOrDefault(a => a.Nombre.Equals(nombre));
                if (alumno != null)
                {
                    Console.WriteLine($"Alumno encontrado: {alumno}");
                }
                else
                {
                    Console.WriteLine($"No se encontró el alumno '{nombre}'.");
                }
            }

            public double CalcularNotaMedia()
            {
                if (alumnos.Count == 0) return 0;
                return alumnos.Average(a => a.NotaMedia);
            }
        }
    }
}
