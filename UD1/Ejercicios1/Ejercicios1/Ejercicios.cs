using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios1
{
    internal class Ejercicios
    {
        public static void ejercicio1()
        {

            /*
             * Usuario introduce numeros y el programa cuenta los positivos
             * 
             */
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
            Console.ReadKey(); //Esto lo uso para que no se cierre la consola cuando termine la ejecucion
        }
    }
}
