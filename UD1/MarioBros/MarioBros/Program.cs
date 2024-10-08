using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioBros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region TABLERO
            string[,] tablero = new string[8, 8];
            Operaciones.InicializarTablero(tablero,"M");

            int fila = 0;
            int columna = 0;
            bool esValido = false;
            #endregion

            // Variables para contar las vidas y los ml de pocion
            int vidas = 3;
            int pocion = 0;

            #region MENUYOPCIONES
            do
            {
                Console.Clear(); // Para borrar la consola al inicio del ciclo
                Operaciones.MuestraTableroOculto(tablero, fila, columna, "M"); // Muestra el tablero
                Console.WriteLine("");
                Operaciones.MuestraStats(ref vidas, ref pocion); // Muestra vidas y pociones
                Console.WriteLine("");
                Operaciones.MuestraMenu(); // Muestra el menú

                int operacion = Operaciones.LeeOpcion();

                bool movimientoValido = true; // Controlar si el movimiento es válido

                switch (operacion)
                {
                    case 1: // Mover a la derecha
                        Operaciones.MoverDerecha(ref tablero, ref fila, ref columna, ref vidas, ref pocion);
                        break;

                    case 2: // Mover a la izquierda
                        Operaciones.MoverIzquierda(ref tablero, ref fila, ref columna, ref vidas, ref pocion);
                        break;

                    case 3: // Mover hacia arriba
                        Operaciones.MoverArriba(ref tablero, ref fila, ref columna, ref vidas, ref pocion);
                        break;

                    case 4: // Mover hacia abajo
                        Operaciones.MoverAbajo(ref tablero, ref fila, ref columna, ref vidas, ref pocion);
                        break;

                    case 5: // Salir
                        esValido = true;
                        Console.WriteLine("Finalizando el programa...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida, intenta de nuevo.");
                        movimientoValido = false; // Marcamos el movimiento como inválido
                        break;
                }

                // Comprobación de victoria
                if (pocion > 5 && tablero[7, 7] == "M")
                {
                    Console.WriteLine("Has ganado, tienes un total de " + pocion + " ml de poción.");
                    esValido = true;
                }

                // Comprobación de derrota
                if (vidas <= 0)
                {
                    Console.WriteLine($"Vidas: {vidas}");
                    Console.WriteLine("Has perdido");
                    esValido = true;
                }

                // Mensaje de movimiento inválido si lo hubo
                if (vidas < 0)
                {
                    Console.WriteLine("Movimiento no válido: no puedes moverte fuera del tablero.");
                }

                // Espera un momento para que el usuario vea el mensaje, pero solo si el movimiento fue inválido
                if (!esValido)
                {
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey(); // Espera a que el usuario presione una tecla
                }

            } while (!esValido);
            #endregion

            Console.ReadKey();
        }
    }
}
