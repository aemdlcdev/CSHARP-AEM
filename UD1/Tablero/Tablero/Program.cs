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

            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    tablero[i, j] = "X";
                }
            }
            tablero[0, 0] = "0";
            Operaciones.MuestraArray(tablero);
            #endregion

            Console.WriteLine("");

            #region MENU
            bool esValido = false; 

            do
            {
                Operaciones.MuestraMenu(); 

                int operacion = Operaciones.LeeOpcion(); 

                switch (operacion)
                {
                    case 1: //Derecha
                        tablero[0, 0] = "X";
                        tablero[0, 0+1] = "0";
                        Operaciones.MuestraArray(tablero);
                        Console.WriteLine("Opción 1 seleccionada.");
                      
                        break;
                    case 2: //Izquierda
                        Console.WriteLine("Opción 2 seleccionada.");
                        
                        break;
                    case 3: //Arriba
                        Console.WriteLine("Opción 3 seleccionada.");
                        
                        break;
                    case 4: //Abajo
                        Console.WriteLine("Opción 4 seleccionada.");
                        
                        break;
                    case 5:
                        Console.WriteLine("Adios"); 
                        esValido = true;
                        break;
                    default:
                        Console.WriteLine("Opción no reconocida. Intenta de nuevo."); 
                        break;
                }

            } while (!esValido);
            #endregion


            Console.ReadKey();
        }
    }
}

