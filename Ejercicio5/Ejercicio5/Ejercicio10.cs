using System;

namespace Ejercicios
{
    internal class Ejercicio10
    {
        public static void ejercicio10()
        {
            SalaCine salaCine = new SalaCine(5, 8);

            salaCine.ReservarAsiento(1, 2);
            salaCine.ReservarAsiento(1, 3);
            salaCine.MostrarAsientos();

            salaCine.CancelarReserva(1, 2);
            salaCine.MostrarAsientos();

            salaCine.ReservarAsientosGrupo(6);
            salaCine.ReservarAsientosGrupo(4);
            salaCine.ReservarAsientosGrupo(7);
            salaCine.ReservarAsientosGrupo(5);
            salaCine.MostrarAsientos();
        }

        public class Asiento
        {
            public int Fila { get; set; }
            public int Columna { get; set; }
            public bool Reservado { get; set; }

            public Asiento(int fila, int columna)
            {
                Fila = fila;
                Columna = columna;
                Reservado = false;
            }

            public override string ToString()
            {
                return Reservado ? "[X]" : "[ ]";
            }
        }

        public class SalaCine
        {
            private Asiento[,] asientos;

            public SalaCine(int filas, int columnas)
            {
                asientos = new Asiento[filas, columnas];
                for (int i = 0; i < filas; i++)
                    for (int j = 0; j < columnas; j++)
                        asientos[i, j] = new Asiento(i, j);
            }

            public void ReservarAsiento(int fila, int columna)
            {
                if (asientos[fila, columna].Reservado)
                    Console.WriteLine($"Error: El asiento {fila + 1}-{columna + 1} ya está reservado.");
                else
                {
                    asientos[fila, columna].Reservado = true;
                    Console.WriteLine($"Asiento {fila + 1}-{columna + 1} reservado.");
                }
            }

            public void CancelarReserva(int fila, int columna)
            {
                if (!asientos[fila, columna].Reservado)
                    Console.WriteLine($"Error: El asiento {fila + 1}-{columna + 1} no está reservado.");
                else
                {
                    asientos[fila, columna].Reservado = false;
                    Console.WriteLine($"Reserva del asiento {fila + 1}-{columna + 1} cancelada.");
                }
            }

            public void MostrarAsientos()
            {
                for (int i = 0; i < asientos.GetLength(0); i++)
                {
                    for (int j = 0; j < asientos.GetLength(1); j++)
                        Console.Write(asientos[i, j].ToString());
                    Console.WriteLine();
                }
            }

            public void ReservarAsientosGrupo(int numAsientos)
            {
                for (int i = 0; i < asientos.GetLength(0); i++)
                {
                    int consecutivos = 0;
                    for (int j = 0; j < asientos.GetLength(1); j++)
                    {
                        if (!asientos[i, j].Reservado) consecutivos++;
                        else consecutivos = 0;

                        if (consecutivos == numAsientos)
                        {
                            for (int k = j; k > j - numAsientos; k--)
                                asientos[i, k].Reservado = true;

                            Console.WriteLine($"Reserva de grupo de {numAsientos} asientos en fila {i + 1} realizada.");
                            return;
                        }
                    }
                }
                Console.WriteLine("No hay suficientes asientos consecutivos disponibles para el grupo.");
            }
        }
    }
}
