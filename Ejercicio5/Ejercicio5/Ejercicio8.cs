using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicios
{
    internal class Ejercicio8
    {
        public static void ejercicio8()
        {
            Curso curso = new Curso("2ºDAM");

            Estudiante estudiante1 = new Estudiante("Paula", 9.5);
            Estudiante estudiante2 = new Estudiante("Kiko", 8.8);
            Estudiante estudiante3 = new Estudiante("Lindo", 7.6);

            curso.AgregarEstudiante(estudiante1);
            curso.AgregarEstudiante(estudiante2);
            curso.AgregarEstudiante(estudiante3);

            curso.ListarEstudiantes();

            curso.EliminarEstudiante("Kiko");

            curso.ListarEstudiantes();

            Console.WriteLine($"La calificación media del curso es: {curso.CalcularCalificacionMedia():F2}");
        }

        public class Estudiante
        {
            public string Nombre { get; set; }
            public double Calificacion { get; set; }

            public Estudiante(string nombre, double calificacion)
            {
                Nombre = nombre;
                Calificacion = calificacion;
            }

            public override string ToString()
            {
                return $"Nombre: {Nombre}, Calificación: {Calificacion}";
            }
        }

        public class Curso
        {
            public string Nombre { get; set; }
            private List<Estudiante> estudiantes = new List<Estudiante>();

            public Curso(string nombre)
            {
                Nombre = nombre;
            }

            public void AgregarEstudiante(Estudiante estudiante)
            {
                estudiantes.Add(estudiante);
                Console.WriteLine($"Estudiante {estudiante.Nombre} agregado al curso {Nombre}.");
            }

            public void EliminarEstudiante(string nombre)
            {
                Estudiante estudianteAEliminar = estudiantes.Find(e => e.Nombre.Equals(nombre));

                if (estudianteAEliminar != null)
                {
                    estudiantes.Remove(estudianteAEliminar);
                    Console.WriteLine($"Estudiante {nombre} eliminado del curso {Nombre}.");
                }
                else
                {
                    Console.WriteLine($"Estudiante con nombre {nombre} no encontrado en el curso {Nombre}.");
                }
            }

            public double CalcularCalificacionMedia()
            {
                if (estudiantes.Count == 0)
                {
                    Console.WriteLine("No hay estudiantes en el curso.");
                    return 0;
                }

                double sumaCalificaciones = estudiantes.Sum(e => e.Calificacion);
                return sumaCalificaciones / estudiantes.Count;
            }

            public void ListarEstudiantes()
            {
                Console.WriteLine($"Estudiantes en el curso {Nombre}:");
                foreach (Estudiante estudiante in estudiantes)
                {
                    Console.WriteLine(estudiante.ToString());
                }
            }
        }
    }
}
