using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicios
{
    internal class Ejercicio7
    {
        public static void ejercicio7()
        {
            GestionFacturas gestionFacturas = new GestionFacturas();

            Factura factura1 = new Factura(1, "Compra de materiales", 1500);
            Factura factura2 = new Factura(2, "Servicio de transporte", 800);
            Factura factura3 = new Factura(3, "Consultoría", 1200);

            gestionFacturas.AgregarFactura(factura1);
            gestionFacturas.AgregarFactura(factura2);
            gestionFacturas.AgregarFactura(factura3);

            gestionFacturas.ListarFacturas();

            gestionFacturas.EliminarFactura(2);

            gestionFacturas.ListarFacturas();

            Console.WriteLine($"El importe total es: {gestionFacturas.CalcularImporteTotal()}");
        }

        public class Factura
        {
            public int Numero { get; set; }
            public string Concepto { get; set; }
            public double Importe { get; set; }

            public Factura(int numero, string concepto, double importe)
            {
                Numero = numero;
                Concepto = concepto;
                Importe = importe;
            }

            public override string ToString()
            {
                return $"Número: {Numero}, Concepto: {Concepto}, Importe: {Importe}";
            }
        }

        public class GestionFacturas
        {
            private List<Factura> facturas = new List<Factura>();

            public void AgregarFactura(Factura factura)
            {
                facturas.Add(factura);
                Console.WriteLine($"Factura {factura.Numero} agregada.");
            }

            public void EliminarFactura(int numero)
            {
                Factura facturaAEliminar = facturas.Find(f => f.Numero == numero);

                if (facturaAEliminar != null)
                {
                    facturas.Remove(facturaAEliminar);
                    Console.WriteLine($"Factura {numero} eliminada.");
                }
                else
                {
                    Console.WriteLine($"Factura con número {numero} no encontrada.");
                }
            }

            public void ListarFacturas()
            {
                Console.WriteLine("Lista de facturas:");
                foreach (Factura factura in facturas)
                {
                    Console.WriteLine(factura.ToString());
                }
            }

            public double CalcularImporteTotal()
            {
                double importeTotal = facturas.Sum(f => f.Importe);
                return importeTotal;
            }
        }
    }
}

