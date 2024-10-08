using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinocho
{
    internal class Operaciones
    {
        private static Random random = new Random();

        public const int PIRAÑA = 0;
        public const int AGUA = 1;
        public const int PIEDRA = 2;
        public const int PEZ = 3;

        public static void MuestraMenu()
        {
            Console.WriteLine("Seleccione una operacion");
            Console.WriteLine("1: Derecha");
            Console.WriteLine("2: Izquierda");
            Console.WriteLine("3: Arriba");
            Console.WriteLine("4: Abajo");
            Console.WriteLine("5: Salir");
        }

        public static int LeeOpcionEntero()
        {
            try
            {
                int opcion = 0;
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    return opcion;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Opcion incorrecta" + ex.Message);
            }
            return 0;
        }
        public static void MuestraArray(string[,] array)
        {
            // GetLength(0) obtiene el número de filas, GetLength(1) obtiene el número de columnas
            for (int i = 0; i < array.GetLength(0); i++) // Recorre las filas
            {
                for (int j = 0; j < array.GetLength(1); j++) // Recorre las columnas
                {
                    Console.Write(array[i, j] + " "); // Imprime cada elemento de la matriz
                }
                Console.WriteLine(); // Salto de línea al final de cada fila
            }
        }

        public static void MuestraTableroOculto(string[,] tablero, int fila, int columna, Jugador jugador)
        {
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    if (i == fila && j == columna) // Verifica si estamos en la posición del jugador
                    {
                        Console.Write(jugador.GetNombre() + " "); // Muestra 'M' para la posición actual del jugador
                    }
                    else if (tablero[i, j] == "X")
                    {
                        Console.Write("X "); // Muestra 'X' para celdas visitadas
                    }
                    else
                    {
                        Console.Write("* "); // Muestra '*' para celdas no visitadas
                    }
                }
                Console.WriteLine();
            }
        }

        public static void MuestraStats(Jugador jugador)
        {
            Console.WriteLine("Vidas: " + jugador.GetVidas());
            Console.WriteLine("Peces: " + jugador.GetPeces());

        }

        public static void MuestraStats(Jugador jugador, Jugador jugador2)
        {
            Console.WriteLine("Vidas: " + jugador.GetVidas());
            Console.WriteLine("Peces: " + jugador.GetPeces());
            Console.WriteLine("");
            Console.WriteLine("Vidas de " + jugador.GetNombre()+": "+ jugador.GetVidas());
            Console.WriteLine("Peces de " + jugador2.GetNombre() + ": " + jugador2.GetVidas());

        }

        public static void InicializarTablero(string[,] tablero, Jugador j1)
        {
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    tablero[i, j] = "" + GeneraRandom(0, 3);
                }
            }
            tablero[0, 0] = j1.GetNombre();
        }

        public static void InicializarTablero(string[,] tablero, Jugador j1, Jugador j2)
        {
            // Inicializar el tablero con valores aleatorios
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    tablero[i, j] = "" + GeneraRandom(0, 3); // Llenar el tablero con valores aleatorios
                }
            }

            // Asignar posiciones iniciales a los jugadores
            tablero[0, 0] = j1.GetNombre(); // Posición del jugador 1
            tablero[0, 1] = j2.GetNombre(); // Posición del jugador 2 (justo a la derecha del jugador 1)
        }


        private static int GeneraRandom(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        #region MOVIMIENTOSSIMPLES
        #endregion

        public static void MoverDerecha(ref string[,] tablero, ref int fila, ref int columna, Jugador ju)
        {
            if (columna + 1 < tablero.GetLength(1))
            {
                tablero[fila, columna] = "X";
                columna++;


                string valorCelda = tablero[fila, columna];

                if (valorCelda == "0")
                {
                    ju.SetVidas(ju.GetVidas()-1);
                }
                else if (valorCelda == "1")
                {
                    ju.SetVidas(ju.GetVidas()+1);
                }
                else if (valorCelda == "2")
                {
                    ju.SetPeces(ju.GetPeces()+1);
                }


                tablero[fila, columna] = ju.GetNombre();
            }
            else
            {
                Console.WriteLine("Movimiento no válido: no puedes moverte fuera del tablero.");
            }
        }

        public static void MoverIzquierda(ref string[,] tablero, ref int fila, ref int columna, Jugador ju)
        {
            if (columna - 1 >= 0)  // Asegura que no salga del tablero a la izquierda
            {
                tablero[fila, columna] = "X";  // Marca la posición actual como visitada
                columna--;  // Mueve el jugador a la izquierda

                string valorCelda = tablero[fila, columna];

                if (valorCelda == "0")
                {
                    ju.SetVidas(ju.GetVidas() - 1);
                }
                else if (valorCelda == "1")
                {
                    ju.SetVidas(ju.GetVidas() + 1);
                }
                else if (valorCelda == "2")
                {
                    ju.SetPeces(ju.GetPeces() + 1);
                }

                tablero[fila, columna] = ju.GetNombre();  // Actualiza la posición del jugador en el tablero
            }
            else
            {
                Console.WriteLine("Movimiento no válido: no puedes moverte fuera del tablero.");
            }
        }

        public static void MoverArriba(ref string[,] tablero, ref int fila, ref int columna, Jugador ju)
        {
            if (fila - 1 >= 0)  // Asegura que no salga del tablero hacia arriba
            {
                tablero[fila, columna] = "X";  // Marca la posición actual como visitada
                fila--;  // Mueve el jugador hacia arriba

                string valorCelda = tablero[fila, columna];

                if (valorCelda == "0")
                {
                    ju.SetVidas(ju.GetVidas() - 1);
                }
                else if (valorCelda == "1")
                {
                    ju.SetVidas(ju.GetVidas() + 1);
                }
                else if (valorCelda == "2")
                {
                    ju.SetPeces(ju.GetPeces() + 1);
                }

                tablero[fila, columna] = ju.GetNombre();  // Actualiza la posición del jugador en el tablero
            }
            else
            {
                Console.WriteLine("Movimiento no válido: no puedes moverte fuera del tablero.");
            }
        }

        public static void MoverAbajo(ref string[,] tablero, ref int fila, ref int columna, Jugador ju)
        {
            if (fila + 1 < tablero.GetLength(0))  // Asegura que no salga del tablero hacia abajo
            {
                tablero[fila, columna] = "X";  // Marca la posición actual como visitada
                fila++;  // Mueve el jugador hacia abajo

                string valorCelda = tablero[fila, columna];

                if (valorCelda == "0")
                {
                    ju.SetVidas(ju.GetVidas() - 1);
                }
                else if (valorCelda == "1")
                {
                    ju.SetVidas(ju.GetVidas() + 1);
                }
                else if (valorCelda == "2")
                {
                    ju.SetPeces(ju.GetPeces() + 1);
                }

                tablero[fila, columna] = ju.GetNombre();  // Actualiza la posición del jugador en el tablero
            }
            else
            {
                Console.WriteLine("Movimiento no válido: no puedes moverte fuera del tablero.");
            }
        }

        #region MOVIMIENTOSPARALELOS
        public static void MoverDerecha(ref string[,] tablero, ref int fila, ref int columna, Jugador ju, Jugador juParalelo)
        {
            if (columna + 1 < tablero.GetLength(1))
            {
                tablero[fila, columna] = "X";  // Marca la posición del jugador principal como visitada
                columna++;  // Mueve el jugador principal a la derecha

                // Procesar el valor de la celda del jugador principal
                ProcesarCelda(ref ju, tablero[fila, columna]);

                // Mover al jugador paralelo a la misma posición
                tablero[juParalelo.GetFila(), juParalelo.GetColumna()] = "X";  // Marca la posición del jugador paralelo como visitada
                juParalelo.SetColumna(juParalelo.GetColumna() + 1);  // Mueve el jugador paralelo a la derecha
                ProcesarCelda(ref juParalelo, tablero[juParalelo.GetFila(), juParalelo.GetColumna()]);

                // Actualiza las posiciones en el tablero
                tablero[fila, columna] = ju.GetNombre();  // Actualiza la posición del jugador principal
                tablero[juParalelo.GetFila(), juParalelo.GetColumna()] = juParalelo.GetNombre();  // Actualiza la posición del jugador paralelo
            }
            else
            {
                Console.WriteLine("Movimiento no válido: no puedes moverte fuera del tablero.");
            }
        }

        public static void MoverIzquierda(ref string[,] tablero, ref int fila, ref int columna, Jugador ju, Jugador juParalelo)
        {
            if (columna - 1 >= 0)  // Asegura que no salga del tablero a la izquierda
            {
                tablero[fila, columna] = "X";  // Marca la posición del jugador principal como visitada
                columna--;  // Mueve el jugador principal a la izquierda

                // Procesar el valor de la celda del jugador principal
                ProcesarCelda(ref ju, tablero[fila, columna]);

                // Mover al jugador paralelo a la misma posición
                tablero[juParalelo.GetFila(), juParalelo.GetColumna()] = "X";  // Marca la posición del jugador paralelo como visitada
                juParalelo.SetColumna(juParalelo.GetColumna() - 1);  // Mueve el jugador paralelo a la izquierda
                ProcesarCelda(ref juParalelo, tablero[juParalelo.GetFila(), juParalelo.GetColumna()]);

                // Actualiza las posiciones en el tablero
                tablero[fila, columna] = ju.GetNombre();  // Actualiza la posición del jugador principal
                tablero[juParalelo.GetFila(), juParalelo.GetColumna()] = juParalelo.GetNombre();  // Actualiza la posición del jugador paralelo
            }
            else
            {
                Console.WriteLine("Movimiento no válido: no puedes moverte fuera del tablero.");
            }
        }

        public static void MoverArriba(ref string[,] tablero, ref int fila, ref int columna, Jugador ju, Jugador juParalelo)
        {
            if (fila - 1 >= 0)  // Asegura que no salga del tablero hacia arriba
            {
                tablero[fila, columna] = "X";  // Marca la posición del jugador principal como visitada
                fila--;  // Mueve el jugador principal hacia arriba

                // Procesar el valor de la celda del jugador principal
                ProcesarCelda(ref ju, tablero[fila, columna]);

                // Mover al jugador paralelo a la misma posición
                tablero[juParalelo.GetFila(), juParalelo.GetColumna()] = "X";  // Marca la posición del jugador paralelo como visitada
                juParalelo.SetFila(juParalelo.GetFila() - 1);  // Mueve el jugador paralelo hacia arriba
                ProcesarCelda(ref juParalelo, tablero[juParalelo.GetFila(), juParalelo.GetColumna()]);

                // Actualiza las posiciones en el tablero
                tablero[fila, columna] = ju.GetNombre();  // Actualiza la posición del jugador principal
                tablero[juParalelo.GetFila(), juParalelo.GetColumna()] = juParalelo.GetNombre();  // Actualiza la posición del jugador paralelo
            }
            else
            {
                Console.WriteLine("Movimiento no válido: no puedes moverte fuera del tablero.");
            }
        }

        public static void MoverAbajo(ref string[,] tablero, ref int fila, ref int columna, Jugador ju, Jugador juParalelo)
        {
            if (fila + 1 < tablero.GetLength(0))  // Asegura que no salga del tablero hacia abajo
            {
                tablero[fila, columna] = "X";  // Marca la posición del jugador principal como visitada
                fila++;  // Mueve el jugador principal hacia abajo

                // Procesar el valor de la celda del jugador principal
                ProcesarCelda(ref ju, tablero[fila, columna]);

                // Mover al jugador paralelo a la misma posición
                tablero[juParalelo.GetFila(), juParalelo.GetColumna()] = "X";  // Marca la posición del jugador paralelo como visitada
                juParalelo.SetFila(juParalelo.GetFila() + 1);  // Mueve el jugador paralelo hacia abajo
                ProcesarCelda(ref juParalelo, tablero[juParalelo.GetFila(), juParalelo.GetColumna()]);

                // Actualiza las posiciones en el tablero
                tablero[fila, columna] = ju.GetNombre();  // Actualiza la posición del jugador principal
                tablero[juParalelo.GetFila(), juParalelo.GetColumna()] = juParalelo.GetNombre();  // Actualiza la posición del jugador paralelo
            }
            else
            {
                Console.WriteLine("Movimiento no válido: no puedes moverte fuera del tablero.");
            }
        }

        // Método para procesar el valor de la celda
        private static void ProcesarCelda(ref Jugador ju, string valorCelda)
        {
            if (valorCelda == "0")
            {
                ju.SetVidas(ju.GetVidas() - 1);
            }
            else if (valorCelda == "1")
            {
                ju.SetVidas(ju.GetVidas() + 1);
            }
            else if (valorCelda == "2")
            {
                ju.SetPeces(ju.GetPeces() + 1);
            }
        }

        #endregion

        public static void ProcesaOperacion(ref string[,] tablero, ref int fila, ref int columna, Jugador jugador, Jugador jugador2, ref bool esValido)
        {
            // Mostrar tablero y estadísticas
            Operaciones.MuestraTableroOculto(tablero, fila, columna, jugador);
            Console.WriteLine("");
            Operaciones.MuestraStats(jugador,jugador2);
            Console.WriteLine("");

            // Mostrar el menú
            Operaciones.MuestraMenu();

            // Leer opción del usuario
            int operacion = Operaciones.LeeOpcionEntero();

            // Procesar la opción seleccionada
            switch (operacion)
            {
                case 1: // Mover a la derecha
                    Operaciones.MoverDerecha(ref tablero, ref fila, ref columna, jugador,jugador2);
                    break;

                case 2: // Mover a la izquierda
                    Operaciones.MoverIzquierda(ref tablero, ref fila, ref columna, jugador,jugador2);
                    break;

                case 3: // Mover hacia arriba
                    Operaciones.MoverArriba(ref tablero, ref fila, ref columna, jugador,jugador2);
                    break;

                case 4: // Mover hacia abajo
                    Operaciones.MoverAbajo(ref tablero, ref fila, ref columna, jugador, jugador2);
                    break;

                case 5: // Salir
                    esValido = true;
                    Console.WriteLine("Finalizando el programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida, intenta de nuevo.");
                    break;
            }

            // Comprobación de victoria
            if (jugador.GetPeces() > 5 && tablero[7, 7] == jugador.GetNombre())
            {
                Console.WriteLine($"Has ganado, tienes un total de {jugador.GetPeces()} peces");
                esValido = true;
            } else if(jugador2.GetPeces() > 5 && tablero[7, 7] == jugador2.GetNombre())
            {
                Console.WriteLine($"Has ganado, tienes un total de {jugador2.GetPeces()} peces");
                esValido = true;
            }

            // Comprobación de derrota
            if (jugador.GetVidas() <= 0)
            {
                Console.WriteLine($"Vidas: {jugador.GetVidas()}");
                Console.WriteLine("Has perdido");
                esValido = true;
            }
        }


    }


}

