using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Operaciones.cuentaPositivos();

            Console.WriteLine("");

            Console.WriteLine("Numero random entre 0 y 100: "+ Operaciones.generaRandom(0, 100));
            
            Console.ReadKey(); //Esto lo uso para que no se cierre la consola cuando termine la ejecucion
        }
    }
}
