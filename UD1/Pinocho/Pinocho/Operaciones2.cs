using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinocho
{
    internal class Operaciones2 : Operaciones
    {


        private static void MoverJugadorSiValido(ref string[,] tablero, Jugador jugador, int desplFila, int desplColumna)
        {
            int nuevaFila = jugador.GetFila() + desplFila;
            int nuevaColumna = jugador.GetColumna() + desplColumna;

            if (EsMovimientoValido(tablero, nuevaFila, nuevaColumna))
            {
                MoverJugador(ref tablero, jugador, nuevaFila, nuevaColumna);
            }
            else
            {
                Console.WriteLine("Movimiento no válido: se sale del tablero.");
            }
        }

        public static void ProcesaOperacionIndividual(ref string[,] tablero, Jugador jugador1, Jugador jugador2, ref bool esValido, bool auto)
        {
            // Proceso de juego
            while (!esValido)
            {
                // Turno del jugador 1
                Console.WriteLine($"{jugador1.GetNombreCompleto()}, es tu turno.");
                Operaciones.MuestraTableroOculto(tablero, jugador1, jugador2);
                Operaciones.MuestraStats(jugador1, jugador2);
                Operaciones.MuestraMenu();

                // Leer opción del jugador 1
                int operacion = Operaciones.LeeOpcionEntero(auto);

                switch (operacion)
                {
                    case 1: // Mover a la derecha
                        MoverJugadorSiValido(ref tablero, jugador1, 0, 1);
                        break;
                    case 2: // Mover a la izquierda
                        MoverJugadorSiValido(ref tablero, jugador1, 0, -1);
                        break;
                    case 3: // Mover hacia arriba
                        MoverJugadorSiValido(ref tablero, jugador1, -1, 0);
                        break;
                    case 4: // Mover hacia abajo
                        MoverJugadorSiValido(ref tablero, jugador1, 1, 0);
                        break;
                    case 5: // Salir
                        esValido = true;
                        Console.WriteLine("Finalizando el programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida, intenta de nuevo.");
                        break;
                }

                
                VerificarCondicionesDeVictoria(ref esValido, tablero, jugador1, jugador2);

                if (esValido) break; // Si hay un ganador, salir del bucle

                // Turno del jugador 2
                Console.WriteLine($"{jugador2.GetNombreCompleto()}, es tu turno.");
                Operaciones.MuestraTableroOculto(tablero, jugador1, jugador2);
                Operaciones.MuestraStats(jugador1, jugador2);
                Operaciones.MuestraMenu();

                // Leer opción del jugador 2
                operacion = Operaciones.LeeOpcionEntero(auto);

                switch (operacion)
                {
                    case 1: // Mover a la derecha
                        MoverJugadorSiValido(ref tablero, jugador2, 0, 1);
                        break;
                    case 2: // Mover a la izquierda
                        MoverJugadorSiValido(ref tablero, jugador2, 0, -1);
                        break;
                    case 3: // Mover hacia arriba
                        MoverJugadorSiValido(ref tablero, jugador2, -1, 0);
                        break;
                    case 4: // Mover hacia abajo
                        MoverJugadorSiValido(ref tablero, jugador2, 1, 0);
                        break;
                    case 5: // Salir
                        esValido = true;
                        Console.WriteLine("Finalizando el programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida, intenta de nuevo.");
                        break;
                }

                
                VerificarCondicionesDeVictoria(ref esValido, tablero, jugador1, jugador2);

                if (esValido) break; // Si hay un ganador, salir del bucle

                // Reducir vidas (maximo 18 intentos)
                jugador1.SetVidas(jugador1.GetVidas() - 1);
                jugador2.SetVidas(jugador2.GetVidas() - 1);

                Console.WriteLine("Pulse cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
