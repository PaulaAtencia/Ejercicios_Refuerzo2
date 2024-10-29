using System;
using System.Collections.Generic;
using System.Linq;
using static Ejercicios.Ejercicio3;


    namespace Ejercicios
    {
        internal class Ejercicio4
        {
            public static void ejercicio4()
            {
                ColeccionVideojuegos coleccion = new ColeccionVideojuegos();

               
                coleccion.AgregarJuego(new Videojuego("Call of Duty", "PlayStation"));
                coleccion.AgregarJuego(new Videojuego("Outer Wilds", "Xbox"));

                coleccion.ListarVideojuegos();

                coleccion.MarcarComoJugado("Call of Duty");
                coleccion.MarcarComoJugado("No existe este juego"); 

                coleccion.ListarVideojuegosJugados();
            }

            public class Videojuego
            {
                public string Nombre { get; set; }
                public string Plataforma { get; set; }
                public bool Jugado { get; set; }

                // Constructor
                public Videojuego(string nombre, string plataforma)
                {
                    Nombre = nombre;
                    Plataforma = plataforma;
                    Jugado = false; 
                }
                public override string ToString()
                {
                    return $"{Nombre} ({Plataforma}) - {(Jugado ? "Jugado" : "No Jugado")}";
                }
            }

            public class ColeccionVideojuegos
            {
                private List<Videojuego> videojuegos = new List<Videojuego>();

                public void AgregarJuego(Videojuego juego)
                {
                    videojuegos.Add(juego);
                    Console.WriteLine($"Juego '{juego.Nombre}' agregado a la colección.");
                }

                public Videojuego BuscarJuego(string nombre)
                {
                    Videojuego videojuego = videojuegos.FirstOrDefault(v => v.Nombre.Equals(nombre));

                    if (videojuego == null)
                    {
                        Console.WriteLine($"No se encontró '{nombre}'");
                    }
                    return videojuego;
                }

                public void EliminarJuego(string nombre)
                {
                    Videojuego juego = BuscarJuego(nombre);
                    if (juego != null)
                    {
                        videojuegos.Remove(juego);
                        Console.WriteLine($"Juego '{nombre}' eliminado de la colección.");
                    }
                    else
                    {
                        Console.WriteLine($"No se encontró el juego '{nombre}'.");
                    }
                }

                public void ListarVideojuegos()
                {
                    Console.WriteLine("\nLista de videojuegos en la colección:");
                    if (videojuegos.Count == 0)
                    {
                        Console.WriteLine("No hay videojuegos en la colección.");
                    }
                    else
                    {
                        foreach (Videojuego juego in videojuegos)
                        {
                            Console.WriteLine(juego);
                        }
                    }
                }
                public void MarcarComoJugado(string nombre)
                {
                    Videojuego juego = BuscarJuego(nombre);
                    if (juego != null)
                    {
                        juego.Jugado = true;
                        Console.WriteLine($"Juego '{nombre}' marcado como jugado.");
                    }
                    else
                    {
                        Console.WriteLine($"No se encontró el juego '{nombre}' para marcarlo como jugado.");
                    }
                }

                public void ListarVideojuegosJugados()
                {
                    Console.WriteLine("\nVideojuegos jugados:");
                    List<Videojuego> jugados = videojuegos.Where(j => j.Jugado).ToList();

                    if (jugados.Count == 0)
                    {
                        Console.WriteLine("No hay videojuegos jugados.");
                    }
                    else
                    {
                        foreach (Videojuego juego in jugados)
                        {
                            Console.WriteLine(juego);
                        }
                    }
                }


            }
        }
    }
