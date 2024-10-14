using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinocho
{
    internal class Operaciones
    {
        #region VARIABLES 
        private static Random random = new Random();
        private static bool esValido = true;
        #endregion

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

        public static int LeeOpcionEntero(bool automatico)
        {
            int opcion = 0;
            if (!automatico)
            {
                string input = Console.ReadLine();
                if (!int.TryParse(input, out opcion))
                {
                    Console.WriteLine("Opción incorrecta. Por favor, ingrese un número entero!");
                    return LeeOpcionEntero(automatico);
                }
            }
            else
            {
                opcion = GeneraRandom(1, 4);
            }
            return opcion;
        }

        public static void InicializarTablero(string[,] tablero, List<Jugador> jugadores)
        {
            // Llenar el tablero con valores aleatorios
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    tablero[i, j] = "" + GeneraRandom(1, 4);
                }
            }

            // Asignar posiciones iniciales a los jugadores
            
            for (int indice = 0; indice < jugadores.Count; indice++) // Count para el num de elementos de la lista
            {

                int fila = indice / tablero.GetLength(1); // Calcular la fila (aqui me quedo con el cociente al divir entre las columnas)
                int columna = indice % tablero.GetLength(1); // Calcular la columna (aqui me quedo con el resto al divir entre las columnas)

                // Asignar la posicion inicial a cada jugador de la listaa
                
                jugadores[indice].SetFila(fila);
                jugadores[indice].SetColumna(columna);

                // Coloco a cada jugador de la lista en el tablero
                tablero[fila, columna] = jugadores[indice].GetId();
            }
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

        public static void MuestraTableroOculto(string[,] tablero, List<Jugador> jugadores)
        {
            for (int fila = 0; fila < tablero.GetLength(0); fila++)
            {
                for (int columna = 0; columna < tablero.GetLength(1); columna++)
                {
                    bool esJugador = false;

                    // Comprobar si la celda contiene a algún jugador
                    foreach (var jugador in jugadores)
                    {
                        if (fila == jugador.GetFila() && columna == jugador.GetColumna())
                        {
                            Console.Write(jugador.GetId() + " ");
                            esJugador = true;
                            break;
                        }
                    }

                    if (!esJugador)
                    {
                        if (tablero[fila, columna] == "-")
                        {
                            Console.Write("- "); // Celdas ya visitadas o vacias
                        }
                        else
                        {
                            Console.Write("* "); // Celdas no visitadas
                        }
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

        private static void MoverJugadorSiValido(ref string[,] tablero, Jugador jugador, List<Jugador> jugadores, int desplFila, int desplColumna)
        {
            int nuevaFila = jugador.GetFila() + desplFila;
            int nuevaColumna = jugador.GetColumna() + desplColumna;

            if (EsMovimientoValido(tablero, nuevaFila, nuevaColumna))
            {
                bool celdaOcupada = false;

                // Verificar si la celda está ocupada por otro jugador
                foreach (var j in jugadores)
                {
                    if (j.GetId() != jugador.GetId() && j.GetFila() == nuevaFila && j.GetColumna() == nuevaColumna)
                    {
                        celdaOcupada = true;
                        break;
                    }
                }

                if (!celdaOcupada)
                {
                    MoverJugador(ref tablero, jugador, nuevaFila, nuevaColumna);
                }
                else
                {
                    Console.WriteLine("Movimiento no válido: la celda está ocupada por otro jugador.");
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

        public static void ProcesaOperacionIndividual(ref string[,] tablero, List<Jugador> jugadores, bool auto)
        {
            bool juegoEnCurso = true;

            while (juegoEnCurso)
            {
                foreach (var jugador in jugadores)
                {
                    if (jugador.GetVidas() <= 0 || jugador.GetSaltos() <= 0)
                    {
                        continue; // Saltar el turno si el jugador no tiene vidas o saltos
                    }

                    Console.WriteLine($"{jugador.GetNombreCompleto()}, es tu turno.");
                    MuestraTableroOculto(tablero, jugadores);
                    MuestraStats(jugador);
                    MuestraMenu();

                    int operacion = LeeOpcionEntero(auto);

                    switch (operacion)
                    {
                        case 1: // Mover a la derecha
                            MoverJugadorSiValido(ref tablero, jugador, jugadores, 0, 1);
                            break;
                        case 2: // Mover a la izquierda
                            MoverJugadorSiValido(ref tablero, jugador, jugadores, 0, -1);
                            break;
                        case 3: // Mover hacia arriba
                            MoverJugadorSiValido(ref tablero, jugador, jugadores, -1, 0);
                            break;
                        case 4: // Mover hacia abajo
                            MoverJugadorSiValido(ref tablero, jugador, jugadores, 1, 0);
                            break;
                        case 5: // Salir
                            juegoEnCurso = false;
                            Console.WriteLine("Finalizando el programa...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida, intenta de nuevo.");
                            break;
                    }

                    // Verificar condiciones de victoria después de cada movimiento
                    VerificarCondicionesDeVictoriaDerrota(ref juegoEnCurso, tablero, jugadores);

                    if (!juegoEnCurso) break; // Si hay un ganador, salir del bucle
                }

                if (!juegoEnCurso) break; // Si hay un ganador, salir del bucle

                // Reducir saltos (máximo 18 intentos), verificando que las vidas sean mayores que 0
                BajaSaltos(jugadores);
                VerificarCondicionesDeVictoriaDerrota(ref juegoEnCurso, tablero, jugadores);

                Console.WriteLine("Pulse cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }

            // Mostrar posiciones finales de los jugadores
            foreach (var jugador in jugadores)
            {
                MuestraPosiciones(jugador);
            }
        }

        #endregion

        #region METODOS PRIVADOS

        private static bool EsMovimientoValido(string[,] tablero, int fila, int columna)
        {
            return fila >= 0 && fila < tablero.GetLength(0) && columna >= 0 && columna < tablero.GetLength(1);
        }

        private static void VerificarCondicionesDeVictoriaDerrota(ref bool esValido, string[,] tablero, List<Jugador> jugadores)
        {
            int metaFila = tablero.GetLength(0) - 1;
            int metaColumna = tablero.GetLength(1) - 1;

            foreach (var jugador in jugadores)
            {
                if (jugador.GetPeces() > 5 && tablero[metaFila, metaColumna] == jugador.GetId())
                {
                    Console.WriteLine($"{jugador.GetId()} ha ganado con un total de {jugador.GetPeces()} peces.");
                    esValido = false;
                    return;
                }

                if (jugador.GetVidas() <= 0)
                {
                    Console.WriteLine($"El jugador {jugador.GetNombreCompleto()} se ha quedado sin vidas!");
                    esValido = false;
                    return;
                }

                if (jugador.GetSaltos() <= 0)
                {
                    Console.WriteLine($"El jugador {jugador.GetNombreCompleto()} se ha quedado sin saltos!");
                    esValido = false;
                    return;
                }
            }
        }

        private static int GeneraRandom(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        private static void BajaSaltos(List<Jugador> jugadores)
        {
            foreach (var jugador in jugadores)
            {
                if (jugador.GetSaltos() > 0)
                {
                    jugador.SetSaltos(jugador.GetSaltos() - 1);
                }
            }
        }

        #endregion
    }

}


