using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios
{
    internal class Ejercicio6
    {
        public static void ejercicio6()
        {
            Empresa empresa = new Empresa();

            Empleado empleado1 = new Empleado("Juan Perez", "Desarrollador", 3000);
            Empleado empleado2 = new Empleado("Maria Lopez", "Diseñadora", 2800);
            Empleado empleado3 = new Empleado("Carlos Ramirez", "Gerente", 5000);

            empresa.AgregarEmpleado(empleado1);
            empresa.AgregarEmpleado(empleado2);
            empresa.AgregarEmpleado(empleado3);

            empresa.ListarEmpleados();

            empresa.EliminarEmpleado("Maria Lopez");

            empresa.ListarEmpleados();

            Console.WriteLine($"El salario predio es {empresa.CalcularSalarioPromedio()}");
        }

        public class Empleado
        {
 
            public string Nombre { get; set; }
            public string Puesto { get; set; }
            public double Salario { get; set; }

            public Empleado(string nombre, string puesto, double salario)
            {
                Nombre = nombre;
                Puesto = puesto;
                Salario = salario;
            }

            public override string ToString()
            {
                return $"Nombre: {Nombre}, Puesto: {Puesto}, Salario: {Salario}";
            }
        }

        public class Empresa
        {
            private List<Empleado> empleados = new List<Empleado>();

            public void AgregarEmpleado(Empleado empleado)
            {
                empleados.Add(empleado);
                Console.WriteLine($"Empleado {empleado.Nombre} agregado.");
            }

            public void EliminarEmpleado(string nombre)
            {
                Empleado empleadoAEliminar = empleados.Find(e => e.Nombre.Equals(nombre));

                if (empleadoAEliminar != null)
                {
                    empleados.Remove(empleadoAEliminar);
                    Console.WriteLine($"Empleado {nombre} eliminado.");
                }
                else
                {
                    Console.WriteLine($"Empleado con nombre {nombre} no encontrado.");
                }
            }

            public void ListarEmpleados()
            {
                Console.WriteLine("Lista de empleados:");
                foreach (Empleado empleado in empleados)
                {
                    Console.WriteLine(empleado.ToString());
                }
            }

            public double CalcularSalarioPromedio()
            {
                if (empleados.Count == 0)
                {
                    Console.WriteLine("No hay empleados en la lista.");
                    return 0;
                }

                double sumaSalarios = empleados.Sum(e => e.Salario);
                double salarioPromedio = sumaSalarios / empleados.Count;
                return salarioPromedio;
            }

        }





    }
}
