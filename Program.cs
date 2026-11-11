
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LaberintoRecursivo
{
    internal class Program
    {
        static long llamadasRecursivas;
        static bool[,] visitados;
        static char[,] laberinto;
        static List<(int Fila, int Columna)> camino;

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("======================================");
                Console.WriteLine("       SOLUCIONADOR DE LABERINTOS");
                Console.WriteLine("======================================");
                Console.WriteLine("1. Laberinto pequeno (7 x 7)");
                Console.WriteLine("2. Laberinto mediano (11 x 11)");
                Console.WriteLine("3. Laberinto grande (15 x 15)");
                Console.WriteLine("4. Salir");
                Console.WriteLine("======================================");
                Console.Write("Seleccione una opcion: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                    opcion = 0;

                switch (opcion)
                {
                    case 1:
                        EjecutarPrueba(7);
                        break;

                    case 2:
                        EjecutarPrueba(11);
                        break;

                    case 3:
                        EjecutarPrueba(15);
                        break;

                    case 4:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opcion no valida.");
                        Pausar();
                        break;
                }

            } while (opcion != 4);
        }

        static void EjecutarPrueba(int tamanio)
        {
            CrearLaberinto(tamanio);

            llamadasRecursivas = 0;
            visitados = new bool[tamanio, tamanio];
            camino = new List<(int Fila, int Columna)>();

            Console.Clear();
            Console.WriteLine($"LABERINTO DE {tamanio} x {tamanio}");
            Console.WriteLine("\nLaberinto original:");
            MostrarLaberinto(false);

            Stopwatch reloj = Stopwatch.StartNew();

            bool encontrado = BuscarCamino(0, 0);

            reloj.Stop();

            Console.WriteLine("\nResultado de la busqueda:");

            if (encontrado)
            {
                Console.WriteLine("Se encontro una salida.");
                MostrarLaberinto(true);
            }
            else
            {
                Console.WriteLine("No existe una salida.");
            }

            Console.WriteLine("\nESTADISTICAS");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"Tamano: {tamanio} x {tamanio}");
            Console.WriteLine($"Llamadas recursivas: {llamadasRecursivas}");
            Console.WriteLine($"Casillas del camino: {camino.Count}");
            Console.WriteLine($"Tiempo: {reloj.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine("--------------------------------------");

            Pausar();
        }

        static void CrearLaberinto(int tamanio)
        {
            laberinto = new char[tamanio, tamanio];

            // Inicializar todas las casillas como libres.
            for (int fila = 0; fila < tamanio; fila++)
            {
                for (int columna = 0; columna < tamanio; columna++)
                {
                    laberinto[fila, columna] = '.';
                }
            }

            // Crear paredes horizontales con aberturas alternadas.
            int numeroPared = 0;

            for (int fila = 2; fila < tamanio - 1; fila += 2)
            {
                for (int columna = 1; columna < tamanio - 1; columna++)
                {
                    laberinto[fila, columna] = '#';
                }

                int abertura = numeroPared % 2 == 0
                    ? tamanio - 2
                    : 1;

                laberinto[fila, abertura] = '.';
                numeroPared++;
            }

            laberinto[0, 0] = 'S';
            laberinto[tamanio - 1, tamanio - 1] = 'E';
        }

        static bool BuscarCamino(int fila, int columna)
        {
            llamadasRecursivas++;

            int filas = laberinto.GetLength(0);
            int columnas = laberinto.GetLength(1);

            // Validar limites, paredes y casillas visitadas.
            if (fila < 0 || columna < 0 ||
                fila >= filas || columna >= columnas ||
                laberinto[fila, columna] == '#' ||
                visitados[fila, columna])
            {
                return false;
            }

            // Marcar la casilla como visitada.
            visitados[fila, columna] = true;
            camino.Add((fila, columna));

            // CASO BASE: se llego a la salida.
            if (fila == filas - 1 && columna == columnas - 1)
            {
                return true;
            }

            // CASO RECURSIVO: explorar las cuatro direcciones.
            if (BuscarCamino(fila, columna + 1) ||  // Derecha
                BuscarCamino(fila + 1, columna) ||  // Abajo
                BuscarCamino(fila, columna - 1) ||  // Izquierda
                BuscarCamino(fila - 1, columna))    // Arriba
            {
                return true;
            }

            // BACKTRACKING: retirar la casilla del camino.
            camino.RemoveAt(camino.Count - 1);

            return false;
        }

        static void MostrarLaberinto(bool mostrarCamino)
        {
            for (int fila = 0; fila < laberinto.GetLength(0); fila++)
            {
                for (int columna = 0; columna < laberinto.GetLength(1); columna++)
                {
                    char caracter = laberinto[fila, columna];

                    if (mostrarCamino &&
                        caracter != 'S' && caracter != 'E' &&
                        camino.Contains((fila, columna)))
                    {
                        caracter = '*';
                    }

                    Console.Write(caracter + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine("\nS = Inicio | E = Salida | # = Pared");
            Console.WriteLine("* = Camino encontrado | . = Espacio libre");
        }

        static void Pausar()
        {
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
