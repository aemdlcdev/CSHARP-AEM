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
        /// <param name="Min">El valor mínimo del rango (incluido).</param>
        /// <param name="Max">El valor máximo del rango (incluido).</param>
        /// <returns>Un número aleatorio entero entre el valor mínimo y el valor máximo, ambos inclusive.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Se lanza si el valor de <paramref name="min"/> es mayor que el valor de <paramref name="max"/>.
        /// </exception>
        public static int GeneraRandom(int Min, int Max)
        {
            Random random = new Random();
            int Num = random.Next(Min, Max+1); //+1 para incluir el valor maximo
            return Num;
        }
        
        public static void IntroduccionListas()
        {
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
            Console.WriteLine(ListaColores.Contains("Rojo")); //Para ver si la lista contiene la cadena
            ListaColores[ListaColores.IndexOf("Alejandro")] = "Verde"; //Le decimos que donde este Alejandro lo cambie por Verde
            Console.WriteLine(ListaColores[3]);
            Console.WriteLine(ListaColores.Count);
            Console.WriteLine(ListaColores.Capacity);
            ListaColores.Clear(); //Borro todo el contenido de la lista
            foreach (String Str in ListaColores)
            {
                Console.WriteLine(Str);
            }
            Console.ReadKey();
        }
        
    }
}