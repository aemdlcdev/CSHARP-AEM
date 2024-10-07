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
            Operaciones.InicializarTablero(tablero);

            int fila = 0;
            int columna = 0;
            bool esValido = false;
            #endregion

            // Variables para contar las vidas y los ml de pocion
            int vidas = 5;
            int pocion = 0;

            #region MENUYOPCIONES
            do
            {
                Console.Clear(); // Para borrar la consola
                Operaciones.MuestraArray(tablero);
                Console.WriteLine("");
                Operaciones.MuestraStats(ref vidas, ref pocion);
                Console.WriteLine("");
                Operaciones.MuestraMenu();

                int operacion = Operaciones.LeeOpcion();

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
                        break;
                }

                // Comprobación de victoria
                if (pocion > 5 && tablero[7, 7] == "M")
                {
                    Console.WriteLine("Has ganado, tienes un total de " + pocion + " ml de poción.");
                    esValido = true;
                }
                else
                {
                    Console.WriteLine("No has ganado. Necesitas más pociones o no estás en la posición correcta.");
                }

                // Comprobación de derrota
                if (vidas <= 0)
                {
                    Console.WriteLine("Has perdido");
                    esValido = true;
                }

            } while (!esValido);
            #endregion

            Console.ReadKey();
        }
    }
}
