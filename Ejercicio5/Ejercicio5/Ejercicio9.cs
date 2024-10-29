using System;
using System.Collections.Generic;

namespace Ejercicios
{
    internal class Ejercicio9
    {
        public static void ejercicio9()
        {
            Taller taller = new Taller();

            Coche coche1 = new Coche("5501BVC", "Toyota", false);
            Coche coche2 = new Coche("0068BWS", "Honda", false);
            Coche coche3 = new Coche("6337JJM", "Ford", true);

            taller.AgregarCoche(coche1);
            taller.AgregarCoche(coche2);
            taller.AgregarCoche(coche3);

            taller.ListarCoches();

            taller.RepararCoche("5501BVC");

            taller.ListarCoches();

            taller.EliminarCoche("0068BWS");

            taller.ListarCoches();
        }

        public class Coche
        {
            public string Matricula { get; set; }
            public string Marca { get; set; }
            public bool Estado { get; set; } 

            public Coche(string matricula, string marca, bool estado)
            {
                Matricula = matricula;
                Marca = marca;
                Estado = estado;
            }

            public override string ToString()
            {
                string estadoString = Estado ? "Reparado" : "No reparado";
                return $"Matrícula: {Matricula}, Marca: {Marca}, Estado: {estadoString}";
            }
        }

        public class Taller
        {
            private List<Coche> coches = new List<Coche>();

            public void AgregarCoche(Coche coche)
            {
                coches.Add(coche);
                Console.WriteLine($"Coche con matrícula {coche.Matricula} agregado al taller.");
            }

            public void EliminarCoche(string matricula)
            {
                Coche cocheAEliminar = coches.Find(c => c.Matricula.Equals(matricula));
                if (cocheAEliminar != null)
                {
                    coches.Remove(cocheAEliminar);
                    Console.WriteLine($"Coche con matrícula {matricula} eliminado del taller.");
                }
                else
                {
                    Console.WriteLine($"Coche con matrícula {matricula} no encontrado en el taller.");
                }
            }

            public void RepararCoche(string matricula)
            {
                Coche cocheAReparar = coches.Find(c => c.Matricula.Equals(matricula));

                if (cocheAReparar != null)
                {
                    cocheAReparar.Estado = true;
                    Console.WriteLine($"Coche con matrícula {matricula} ha sido reparado.");
                }
                else
                {
                    Console.WriteLine($"Coche con matrícula {matricula} no encontrado en el taller.");
                }
            }

            public void ListarCoches()
            {
                Console.WriteLine("Lista de coches en el taller:");
                foreach (Coche coche in coches)
                {
                    Console.WriteLine(coche.ToString());
                }
            }
        }
    }
}
