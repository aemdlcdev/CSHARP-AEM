using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tablero
{
    internal class Operaciones
    {
        public static void MuestraMenu()
        {
            Console.WriteLine("Seleccione una operacion");
            Console.WriteLine("1: Derecha");
            Console.WriteLine("2: Izquierda");
            Console.WriteLine("3: Arriba");
            Console.WriteLine("4: Abajo");
            Console.WriteLine("5: Salir");
        }

        public static int LeeOpcion()
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

        public static void InicializarTablero(ref string[,] tablero)
        {
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    tablero[i, j] = "X"; 
                }
            }
            tablero[0, 0] = "0"; 
        }
  
        public static void MoverDerecha(ref string[,] tablero, ref int fila, ref int columna)
        {
            if (columna + 1 < tablero.GetLength(1)) 
            {
                tablero[fila, columna] = "X"; 
                columna++; 
                tablero[fila, columna] = "0"; 
            }
            else
            {
                Console.WriteLine("Movimiento no válido: no puedes moverte fuera del tablero.");
            }
        }

        public static void MoverIzquierda(ref string[,] tablero, ref int fila, ref int columna)
        {
            if (columna - 1 >= 0) 
            {
                tablero[fila, columna] = "X"; 
                columna--; 
                tablero[fila, columna] = "0"; 
            }
            else
            {
                Console.WriteLine("Movimiento no válido: no puedes moverte fuera del tablero.");
            }
        }
    
        public static void MoverArriba(ref string[,] tablero, ref int fila, ref int columna)
        {
            if (fila - 1 >= 0) 
            {
                tablero[fila, columna] = "X"; 
                fila--; 
                tablero[fila, columna] = "0"; 
            }
            else
            {
                Console.WriteLine("Movimiento no válido: no puedes moverte fuera del tablero.");
            }
        }
     
        public static void MoverAbajo(ref string[,] tablero, ref int fila, ref int columna)
        {
            if (fila + 1 < tablero.GetLength(0)) 
            {
                tablero[fila, columna] = "X"; 
                fila++; 
                tablero[fila, columna] = "0"; 
            }
            else
            {
                Console.WriteLine("Movimiento no válido: no puedes moverte fuera del tablero.");
            }
        }
    }
}
