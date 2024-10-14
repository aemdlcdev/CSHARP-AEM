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

        #region CONSTANTES

        public const string PIRAÑA = "1";
        public const string AGUA = "2";
        public const string PIEDRA = "3";
        public const string PEZ = "4";
        public const string PIERDE = "pierde";

        #endregion

        #region MOSTRAR E INICIALIZAR

        public static void MuestraMenu()
        {
            Console.WriteLine("Seleccione una operacion");
            Console.WriteLine("1: Derecha");
            Console.WriteLine("2: Izquierda");
            Console.WriteLine("3: Arriba");
            Console.WriteLine("4: Abajo");
            Console.WriteLine("5: Salir");
        }

        public static int LeeOpcionEntero(bool auto)
        {
            int opcion = 0;
            if (!auto)
            {
                try
                {
                    int.TryParse(Console.ReadLine(), out opcion);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Opcion incorrecta" + ex.Message);
                }
            }
            else
            {
                opcion = GeneraRandom(1, 4);
            }
            return opcion;
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
            Console.WriteLine("Vidas de " + jugador.GetNombreCompleto() + ": " + jugador.GetVidas());
            Console.WriteLine("Peces de " + jugador.GetNombreCompleto() + ": " + jugador.GetPeces());
            Console.WriteLine("Saltos de " + jugador.GetNombreCompleto() + ": " + jugador.GetSaltos());
            Console.WriteLine("");

        }

        public static void InicializarTablero(string[,] tablero, Jugador j1)
        {
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    tablero[i, j] = "" + GeneraRandom(1, 4);
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
                    tablero[i, j] = "" + GeneraRandom(1, 4); // Llenar el tablero con valores aleatorios
                }
            }

            j1.SetFila(0);  // Jugador 1 en la posición (0,0)
            j1.SetColumna(0);

            j2.SetFila(1);  // Jugador 2 justo debajo, en la posición (1,0)
            j2.SetColumna(0);
        }

        public static void MuestraPosiciones(Jugador jugador)
        {
            Console.WriteLine("Filas: F, Columnas: C");
            Console.Write("F de " + jugador.GetNombreCompleto() + " " + jugador.GetPosicionesF().ToString());
            Console.WriteLine();
            Console.Write("C de " + jugador.GetNombreCompleto() + " " + jugador.GetPosicionesC().ToString());
            Console.WriteLine();
        }

        #endregion

        #region MOVIMIENTO SIMPLE

        private static void MoverJugadorSiValido(ref string[,] tablero, Jugador jugador, Jugador jugador2, int desplFila, int desplColumna)
        {
            int nuevaFila = jugador.GetFila() + desplFila;
            int nuevaColumna = jugador.GetColumna() + desplColumna;

            if (EsMovimientoValido(tablero, nuevaFila, nuevaColumna))
            {
                if (tablero[nuevaFila,nuevaColumna] == jugador2.GetId())
                {
                    Console.WriteLine("Hay una colision!");
                    return;
                }
                else
                {
                    MoverJugador(ref tablero, jugador, nuevaFila, nuevaColumna);
                }
            }

            else
            {
                Console.WriteLine("Movimiento no válido: se sale del tablero.");
            }
        }

        public static void MoverJugador(ref string[,] tablero, Jugador jugador, int nuevaFila, int nuevaColumna)
        {
            // Obtener el valor de la nueva celda
            string contenidoCelda = tablero[nuevaFila, nuevaColumna];
            if(jugador.GetVidas()<=0)
            {
                contenidoCelda = PIERDE;
            }
            // Actualizar estadísticas del jugador dependiendo del contenido de la celda
            switch (contenidoCelda)
            {
                case PIRAÑA: // Piraña
                    Console.WriteLine($"{jugador.GetNombreCompleto()} ha encontrado una piraña y pierde una vida.");
                    jugador.SetVidas(jugador.GetVidas() - 1);
                    break;
                case AGUA: // Agua
                    Console.WriteLine($"{jugador.GetNombreCompleto()} ha encontrado agua. No pasa nada.");
                    break;
                case PIEDRA: // Piedra
                    Console.WriteLine($"{jugador.GetNombreCompleto()} ha chocado con una piedra. No pasa nada.");
                    break;
                case PEZ: // Pez
                    Console.WriteLine($"{jugador.GetNombreCompleto()} ha encontrado un pez y gana un pez.");
                    jugador.SetPeces(jugador.GetPeces() + 1);
                    break;
                case PIERDE:
                    Console.WriteLine($"Al jugador {jugador.GetNombreCompleto()} no le quedan vidas");
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

            // Añadimos la posicion de cada jugar a las lista para saber por donde se han movido
            jugador.AñadirPosicionF();
            jugador.AñadirPosicionC();
        }

        #endregion

        #region PROCESAR
        
        public static void ProcesaOperacionIndividual(ref string[,] tablero, Jugador jugador1, Jugador jugador2, ref bool esValido, bool auto)
        {
            // Proceso de juego
            while (esValido)
            {
                // Turno del jugador 1
                Console.WriteLine($"{jugador1.GetNombreCompleto()}, es tu turno.");
                Operaciones.MuestraTableroOculto(tablero, jugador1, jugador2);
                Operaciones.MuestraStats(jugador1);
                Operaciones.MuestraStats(jugador2);
                Operaciones.MuestraMenu();

                // Leer opción del jugador 1
                int operacion = Operaciones.LeeOpcionEntero(auto);

                // Compruebo que si no tiene vidas que no haga nada
                if (jugador1.GetVidas() <= 0 || jugador1.GetSaltos() <=0) 
                {
                    operacion = 6;
                }
                switch (operacion)

                {
                    
                    case 1: // Mover a la derecha
                        MoverJugadorSiValido(ref tablero, jugador1,jugador2, 0, 1);
                        break;
                    case 2: // Mover a la izquierda
                        MoverJugadorSiValido(ref tablero, jugador1,jugador2, 0, -1);
                        break;
                    case 3: // Mover hacia arriba
                        MoverJugadorSiValido(ref tablero, jugador1,jugador2, -1, 0);
                        break;
                    case 4: // Mover hacia abajo
                        MoverJugadorSiValido(ref tablero, jugador1,jugador2, 1, 0);
                        break;
                    case 5: // Salir
                        esValido = false;
                        Console.WriteLine("Finalizando el programa...");
                        break;
                    case 6: // Salto de turno
                        break;
                    default:
                        Console.WriteLine("Opción no válida, intenta de nuevo.");
                        break;
                }
                
                VerificarCondicionesDeVictoria(ref esValido, tablero, jugador1, jugador2);

                if (!esValido) break; // Si hay un ganador, salir del bucle

                // Turno del jugador 2
                Console.WriteLine($"{jugador2.GetNombreCompleto()}, es tu turno.");
                Operaciones.MuestraTableroOculto(tablero, jugador1, jugador2);
                Operaciones.MuestraStats(jugador1);
                Operaciones.MuestraStats(jugador2);
                Operaciones.MuestraMenu();

                // Leer opción del jugador 2
                operacion = Operaciones.LeeOpcionEntero(auto);

                // Compruebo que si no tiene vidas que no haga nada
                if (jugador2.GetVidas() <= 0)
                {
                    operacion = 6;
                }
                switch (operacion)
                {
                    case 1: // Mover a la derecha
                        MoverJugadorSiValido(ref tablero, jugador2,jugador1, 0, 1);
                        break;
                    case 2: // Mover a la izquierda
                        MoverJugadorSiValido(ref tablero, jugador2, jugador1, 0, -1);
                        break;
                    case 3: // Mover hacia arriba
                        MoverJugadorSiValido(ref tablero, jugador2, jugador1, -1, 0);
                        break;
                    case 4: // Mover hacia abajo
                        MoverJugadorSiValido(ref tablero, jugador2, jugador1, 1, 0);
                        break;
                    case 5: // Salir
                        esValido = false;
                        Console.WriteLine("Finalizando el programa...");
                        break;
                    case 6: // Salto de turno
                        break;
                    default:
                        Console.WriteLine("Opción no válida, intenta de nuevo.");
                        break;
                }


                if (!esValido) break; // Si hay un ganador, salir del bucle

                // Reducir vidas (maximo 18 intentos), verificando que las vidas sean mayores que 0
                BajaSaltos(jugador1,jugador2);
                // Verificamos las condiciones
                VerificarCondicionesDeVictoria(ref esValido, tablero, jugador1, jugador2);
                Console.WriteLine("Pulse cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
            MuestraPosiciones(jugador1);
            MuestraPosiciones(jugador2);

        }
        #endregion

        #region METODOS PRIVADOS

        private static bool EsMovimientoValido(string[,] tablero, int fila, int columna)
        {
            return fila >= 0 && fila < tablero.GetLength(0) && columna >= 0 && columna < tablero.GetLength(1);
        }

        private static void VerificarCondicionesDeVictoria(ref bool esValido, string[,] tablero, Jugador jugador1, Jugador jugador2)
        {
            int metaFila = tablero.GetLength(0) - 1;
            int metaColumna = tablero.GetLength(1) - 1;


            if (jugador1.GetPeces() > 5 && tablero[metaFila, metaColumna] == jugador1.GetId())
            {
                Console.WriteLine($"{jugador1.GetId()} ha ganado con un total de {jugador1.GetPeces()} peces.");
                esValido = false;
            }

            if (jugador2.GetPeces() > 5 && tablero[metaFila, metaColumna] == jugador2.GetId())
            {
                Console.WriteLine($"{jugador2.GetId()} ha ganado con un total de {jugador2.GetPeces()} peces.");
                esValido = false;
            }

            if (jugador1.GetVidas() <= 0 && jugador2.GetVidas() <= 0)
            {
                Console.WriteLine("Ambos jugadores se han quedado sin vidas, el juego ha terminado");
                esValido = false;
            }

            if (jugador1.GetVidas() <= 0)
            {
                Console.WriteLine($"El jugador {jugador1.GetNombreCompleto()} se ha quedado sin vidas!");
            }
            else if (jugador2.GetVidas() <= 0)
            {
                Console.WriteLine($"El jugador {jugador2.GetNombreCompleto()} se ha quedado sin vidas!");
            }
            
            if(jugador1.GetSaltos() <= 0 && jugador2.GetSaltos() <= 0)
            {
                Console.WriteLine("Ambos jugadores se han quedado sin saltos, el juego ha terminado");
                esValido = false;
            } else if(jugador1.GetSaltos() <= 0)
            {
                Console.WriteLine($"El jugador {jugador1.GetNombreCompleto()} se ha quedado sin saltos!");
            }
            else if (jugador2.GetSaltos() <= 0)
            {
                Console.WriteLine($"El jugador {jugador2.GetNombreCompleto()} se ha quedado sin saltos!");
            }
        }

        private static int GeneraRandom(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        private static void BajaSaltos(Jugador jugador1, Jugador jugador2)
        {
            if (jugador1.GetSaltos() > 0 && jugador2.GetSaltos() > 0)
            {
                jugador1.SetSaltos(jugador1.GetSaltos() - 1);
                jugador2.SetSaltos(jugador2.GetSaltos() - 1);
            }
            else if (jugador1.GetSaltos() > 0)
            {
                jugador1.SetSaltos(jugador1.GetSaltos() - 1);
            }
            else if(jugador2.GetSaltos() > 0)
            {
                jugador2.SetSaltos(jugador2.GetSaltos() - 1);
            }
        }
        #endregion
    }

}


