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

        public static void MuestraTableroOculto(string[,] tablero, Jugador ju,Jugador ju2)
        {
            int fila1 = ju.GetFila();
            int columna1 = ju.GetColumna();

            int fila2 = ju2.GetFila();
            int columna2 = ju2.GetColumna();
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    if (i == fila1 && j == columna1)
                    {
                        Console.Write(ju.GetId() + " ");
                    }
                    else if (i == fila2 && j == columna2) // Se usa "else if" para evitar superposición
                    {
                        Console.Write(ju2.GetId() + " ");
                    }
                    else if (tablero[i, j] == "-")
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write("* ");
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
            Console.WriteLine("Vidas de " + jugador.GetNombreCompleto() + ": " + jugador.GetVidas());
            Console.WriteLine("Peces de " + jugador.GetNombreCompleto() + ": " + jugador.GetPeces());
            Console.WriteLine("");
            Console.WriteLine("Vidas de " + jugador2.GetNombreCompleto()+": "+ jugador2.GetVidas());
            Console.WriteLine("Peces de " + jugador2.GetNombreCompleto() + ": " + jugador2.GetPeces());

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
            tablero[0, 0] = j1.GetId();
        }

        public static void InicializarTablero(string[,] tablero, Jugador j1, Jugador j2)
        {
            
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    tablero[i, j] = "" + GeneraRandom(0, 3); // Llenar el tablero con valores aleatorios
                }
            }

            j1.SetFila(0);  // Jugador 1 en la posición (0,0)
            j1.SetColumna(0);

            j2.SetFila(1);  // Jugador 2 justo debajo, en la posición (1,0)
            j2.SetColumna(0);
        }


        private static int GeneraRandom(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        #region MOVIMIENTOSIMPLE
        public static void MoverJugador(ref string[,] tablero, Jugador jugador, int nuevaFila, int nuevaColumna)
        {
            // Obtener el valor de la nueva celda
            string contenidoCelda = tablero[nuevaFila, nuevaColumna];

            // Actualizar estadísticas del jugador dependiendo del contenido de la celda
            switch (contenidoCelda)
            {
                case "0": // Piraña
                    Console.WriteLine($"{jugador.GetNombreCompleto()} ha encontrado una piraña y pierde una vida.");
                    jugador.SetVidas(jugador.GetVidas() - 1);
                    break;
                case "1": // Agua
                    Console.WriteLine($"{jugador.GetNombreCompleto()} ha encontrado agua. No pasa nada.");
                    break;
                case "2": // Piedra
                    Console.WriteLine($"{jugador.GetNombreCompleto()} ha chocado con una piedra. No pasa nada.");
                    break;
                case "3": // Pez
                    Console.WriteLine($"{jugador.GetNombreCompleto()} ha encontrado un pez y gana un pez.");
                    jugador.SetPeces(jugador.GetPeces() + 1);
                    break;
                default:
                    Console.WriteLine($"{jugador.GetNombreCompleto()} se ha movido a una celda vacía.");
                    break;
            }

            // Borrar la posición actual del jugador en el tablero
            tablero[jugador.GetFila(), jugador.GetColumna()] = "-"; // "-" representa una celda vacía.

            // Actualizar la posición del jugador
            jugador.SetFila(nuevaFila);
            jugador.SetColumna(nuevaColumna);

            // Colocar al jugador en la nueva posición
            tablero[nuevaFila, nuevaColumna] = jugador.GetId();
        }

        public static bool EsMovimientoValido(string[,] tablero, int fila, int columna)
        {
            return fila >= 0 && fila < tablero.GetLength(0) && columna >= 0 && columna < tablero.GetLength(1);
        }

        #endregion

        #region MOVIMIENTOPARALELO

        public static void MoverEnParalelo(ref string[,] tablero, Jugador jugador1, Jugador jugador2, int desplFila, int desplColumna)
        {
            // Posiciones actuales de ambos jugadores
            int fila1 = jugador1.GetFila();
            int columna1 = jugador1.GetColumna();

            int fila2 = jugador2.GetFila();
            int columna2 = jugador2.GetColumna();

            // Nuevas posiciones calculadas
            int nuevaFila1 = fila1 + desplFila;
            int nuevaColumna1 = columna1 + desplColumna;
            int nuevaFila2 = fila2 + desplFila;
            int nuevaColumna2 = columna2 + desplColumna;

            // Verificar si ambas nuevas posiciones están dentro de los límites del tablero
            if (EsMovimientoValido(tablero, nuevaFila1, nuevaColumna1) && EsMovimientoValido(tablero, nuevaFila2, nuevaColumna2))
            {
                // Verificar que no haya colisión entre los jugadores
                if (nuevaFila1 == nuevaFila2 && nuevaColumna1 == nuevaColumna2)
                {
                    Console.WriteLine("Movimiento no válido: ambos jugadores colisionarían.");
                    return; // Sale si colisonan
                }
                else
                {
                    // Mover ambos jugadores y actualizar el tablero
                    MoverJugador(ref tablero, jugador1, nuevaFila1, nuevaColumna1);
                    MoverJugador(ref tablero, jugador2, nuevaFila2, nuevaColumna2);
                }
            }
            else
            {
                Console.WriteLine("Movimiento no válido: uno o ambos jugadores se salen del tablero.");
            }
        }



        #endregion


        public static void ProcesaOperacion(ref string[,] tablero, Jugador jugador1, Jugador jugador2, ref bool esValido)
        {
            // Mostrar tablero y estadísticas
            

            // Proceso de juego
            while (!esValido)
            {
                
                Operaciones.MuestraTableroOculto(tablero, jugador1, jugador2);
                Console.WriteLine("");
                Operaciones.MuestraStats(jugador1, jugador2);
                Console.WriteLine("");
                
                Operaciones.MuestraMenu();

                // Leer opción del jugador 1
                int operacion = Operaciones.LeeOpcionEntero();

                switch (operacion)
                {
                    case 1: // Mover a la derecha
                        MoverEnParalelo(ref tablero, jugador1, jugador2, 0, 1);
                        break;
                    case 2: // Mover a la izquierda
                        MoverEnParalelo(ref tablero, jugador1, jugador2, 0, -1);
                        break;
                    case 3: // Mover hacia arriba
                        MoverEnParalelo(ref tablero, jugador1, jugador2, -1, 0);
                        break;
                    case 4: // Mover hacia abajo
                        MoverEnParalelo(ref tablero, jugador1, jugador2, 1, 0);
                        break;
                    case 5: // Salir
                        esValido = true;
                        Console.WriteLine("Finalizando el programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida, intenta de nuevo.");
                        break;
                }

                // Verificar condiciones de victoria o derrota
                if (jugador1.GetPeces() > 5 && tablero[7, 7] == jugador1.GetId())
                {
                    Console.WriteLine($"{jugador1.GetId()} ha ganado con un total de {jugador1.GetPeces()} peces.");
                    esValido = true;
                }

                if (jugador2.GetPeces() > 5 && tablero[7, 7] == jugador2.GetId())
                {
                    Console.WriteLine($"{jugador2.GetId()} ha ganado con un total de {jugador2.GetPeces()} peces.");
                    esValido = true;
                }

                if (jugador1.GetVidas() <= 0 || jugador2.GetVidas() <= 0)
                {
                    Console.WriteLine("Uno de los jugadores ha perdido todas sus vidas.");
                    esValido = true;
                }

                // Bajo las vidas ya que de maximo tienen 18 intentos
                jugador1.SetVidas(jugador1.GetVidas()-1);
                jugador2.SetVidas(jugador1.GetVidas() - 1);

                
                Console.WriteLine("Pulse cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                
            }
        }





    }


}

