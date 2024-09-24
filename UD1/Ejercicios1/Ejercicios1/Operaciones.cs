using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios1
{
    internal class Operaciones
    {
        /*
         * Usuario introduce numeros y el programa cuenta los positivos
         * 
         */
        public static void cuentaPositivos()
        {

            
            int positivos = 0;

            int numTecleado = 0;
            Boolean interruptor = true;
            while (interruptor)
            {
                Console.WriteLine("Introduzca un numero" + ", introduce 0 para mostrar los positivos tecleados");
                numTecleado = int.Parse(Console.ReadLine());
                if (numTecleado > 0)
                {
                    positivos += 1;
                }
                else if (numTecleado == 0)
                {
                    interruptor = false;
                }

            }
            Console.WriteLine("Total de numeros positivos tecleados: " + positivos);
            
        }

        /// <summary>
        /// Genera un número aleatorio dentro de un rango especificado.
        /// </summary>
        /// <param name="min">El valor mínimo del rango (incluido).</param>
        /// <param name="max">El valor máximo del rango (incluido).</param>
        /// <returns>Un número aleatorio entero entre el valor mínimo y el valor máximo, ambos inclusive.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Se lanza si el valor de <paramref name="min"/> es mayor que el valor de <paramref name="max"/>.
        /// </exception>
        public static int generaRandom(int min, int max)
        {
            Random random = new Random();
            int num = random.Next(min, max+1); //+1 para incluir el valor maximo
            return num;
        }
        
        
    }
}