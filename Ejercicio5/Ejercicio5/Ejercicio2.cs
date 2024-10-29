using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios
{
    internal class Ejercicio2
    {
        public static void ejercicio2()
        {
            AgendaTareas agenda = new AgendaTareas();

            agenda.AgregarTarea(new Tarea("Dormir"));
            agenda.AgregarTarea(new Tarea("Llorar"));
            agenda.AgregarTarea(new Tarea("Ducharme"));

            Console.WriteLine("Listado inicial de tareas:");
            agenda.ListarTareas();

            agenda.CompletarTarea("Llorar");

            Console.WriteLine("\nEstado de una tarea:");
            agenda.BuscarTarea("Llorar");

            // Eliminar una tarea
            agenda.EliminarTarea("Llorar");

            Console.WriteLine
                ("\nListado de tareas después de completar y eliminar:");
            agenda.ListarTareas();
        }

        public class Tarea
        {
            public string Titulo { get; set; }    
            public bool Completada { get; set; }    

            
            public Tarea(string titulo)
            {
                Titulo = titulo;
                Completada = false;   
            }

            public override string ToString()
            {
                string estado = Completada ? "Completada" : "Pendiente";
                return $"Tarea: {Titulo}, Estado: {estado}";
            }
        }

        public class AgendaTareas
        {
            private List<Tarea> tareas;

            public AgendaTareas()
            {
                tareas = new List<Tarea>();
            }

            public void AgregarTarea(Tarea tarea)
            {
                tareas.Add(tarea);
            }

            public void EliminarTarea(string titulo)
            {
                Tarea tarea = tareas.FirstOrDefault(t => t.Titulo == titulo);
                if (tarea != null)
                {
                    tareas.Remove(tarea);
                }
                else
                {
                    Console.WriteLine($"No se encontró ninguna tarea con el título: {titulo}");
                }
            }

            public void CompletarTarea(string titulo)
            {
                Tarea tarea = tareas.FirstOrDefault(t => t.Titulo == titulo);
                if (tarea != null)
                {
                    tarea.Completada = true;
                }
                else
                {
                    Console.WriteLine($"No se encontró ninguna tarea con el título: {titulo}");
                }
            }

            public void ListarTareas()
            {
                if (tareas.Count == 0)
                {
                    Console.WriteLine("No hay tareas!.");
                }
                else
                {
                    foreach (Tarea tarea in tareas)
                    {
                        Console.WriteLine(tarea);
                    }
                }
            }
            public void BuscarTarea(string titulo)
            {
                Tarea tarea = tareas.FirstOrDefault(t => t.Titulo == titulo);
                if (tarea != null)
                {
                    string estado = tarea.Completada ? "completada" : "pendiente";
                    Console.WriteLine($"La tarea '{titulo}' está {estado}.");
                }
                else
                {
                    Console.WriteLine($"No se encontro ninguna tarea con el título: {titulo}");
                }
            }
        }
    }
}