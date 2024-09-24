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
           /* Operaciones.cuentaPositivos();

            Console.WriteLine("");

            Console.WriteLine("Numero random entre 0 y 100: " + Operaciones.generaRandom(0, 100));
            Console.ReadKey(); //Esto lo uso para que no se cierre la consola cuando termine la ejecucion
           */

            //Trabajar con Listas

            List<string> ListaColores = new List<string>();

            ListaColores.Add("Rojo");
            ListaColores.Add("Amarillo");
            ListaColores.Add("Verde");
            ListaColores.Add("Azul");
            ListaColores.Add("Morado");

            Console.WriteLine(ListaColores[0]);
            ListaColores[2] = "hola";
            Console.WriteLine(ListaColores[2]);
            Console.WriteLine();
            foreach (String Str in ListaColores)
            {
                Console.WriteLine(Str);
            }

            Console.WriteLine();
            ListaColores.Insert(2, "Alejandro");
            foreach (String Str in ListaColores)
            {
                Console.WriteLine(Str);
            }

            Console.WriteLine();
            ListaColores.Sort(); //Ordena por orden alfabetico
            foreach (String Str in ListaColores)
            {
                Console.WriteLine(Str);
            }

            Console.WriteLine(ListaColores.IndexOf("Rojo")); //Devuelve el indice del contenido

            Console.ReadKey();
        }
    }
}
