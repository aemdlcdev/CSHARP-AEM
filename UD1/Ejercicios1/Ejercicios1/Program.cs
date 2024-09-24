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
            //Hacer una lista de numeros aleatorios de 1 a 50 con un tamanio de 100
            Operaciones.MuestraLista(Operaciones.CreaListaCienElementos());
            Console.ReadKey();
        }
    }
}
