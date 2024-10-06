using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tablero
{
    internal class Program
    {
        static void Main(string[] args)

        {
            #region TABLERO

            string[,] tablero = new string[4, 4];
            Operaciones.InicializarTablero(ref tablero);

            int fila = 0;
            int columna = 0; 

            bool esValido = false;

            #endregion

            #region MENUYOPCIONES
            do
            {
                Operaciones.MuestraMenu(); 

                int operacion = Operaciones.LeeOpcion(); 

                switch (operacion)
                {
                    case 1: // Mover a la derecha
                        Operaciones.MoverDerecha(ref tablero, ref fila, ref columna); 
                        Operaciones.MuestraArray(tablero); 
                        break;

                    case 2: // Mover a la izquierda
                        Operaciones.MoverIzquierda(ref tablero, ref fila, ref columna); 
                        Operaciones.MuestraArray(tablero); 
                        break;

                    case 3: // Mover hacia arriba
                        Operaciones.MoverArriba(ref tablero, ref fila, ref columna); 
                        Operaciones.MuestraArray(tablero); 
                        break;

                    case 4: // Mover hacia abajo
                        Operaciones.MoverAbajo(ref tablero, ref fila, ref columna); 
                        Operaciones.MuestraArray(tablero); 
                        break;

                    case 5: // Salir
                        esValido = true;
                        Console.WriteLine("Finalizando el programa...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida, intenta de nuevo.");
                        break;
                }

            } while (!esValido);
            #endregion  

            Console.ReadLine();

        }
    }
}

