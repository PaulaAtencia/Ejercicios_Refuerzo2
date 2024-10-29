using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios
{
    internal class Ejercicio1
    {
        public static void ejercicio1()
        {
            Producto p1 = new Producto("Jarra", 9, 1);
            Producto p2 = new Producto("Taza");

            Console.WriteLine(p1.ToString() + "\n" + p2.ToString());

            p1.AumentarCantidad(10);
            p2.ReducirCantidad(3);

            Console.WriteLine(p1.ToString() + "\n" + p2.ToString());
        }

        public class Producto
        {
            // Atributos de la clase 
            private string nombre;
            private double precio;
            private int cantidad;

            // Constructor de la clase Producto
            public Producto(
                string nombre,   
                double precio = 0,
                int cantidad = 0)

            {
                this.nombre = nombre;
                this.precio = precio;
                this.cantidad = cantidad;
            }

            // Para obtener 
            public string GetNombre()
            {
                return nombre;
            }

            // Obtiene el valor
            public void SetNombre(string nombre)
            {
                this.nombre = nombre;
            }

            public double GetPrecio()
            {
                return precio;
            }

            public void SetPrecio(double precio)
            {
                this.precio = precio;
            }

            // Obtener los datos
            public int GetCantidad()
            {
                return cantidad;
            }

            public void SetCantidad(int cantidad)
            {
                this.cantidad = cantidad;
            }

            public override string ToString()
            {
                return $"Producto: {nombre}, Precio: {precio}, Cantidad: {cantidad}";
            }

            public void AumentarCantidad(int cantidad)
            {
                this.cantidad += cantidad;
            }

            public void ReducirCantidad(int cantidad)
            {
                if (this.cantidad - cantidad >= 0)
                {
                    this.cantidad -= cantidad;
                }

                else
                {
                    Console.WriteLine("Operación inválida");
                }
            }
        }
    }
}