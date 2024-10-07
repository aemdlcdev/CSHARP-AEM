using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioA
{
    internal class EjercicioD
    {
        public static void Apartado13()
        {
            Console.WriteLine("Introduce el numero de estudiantes");
            int tamanio = int.Parse(Console.ReadLine());
            int[] alumnos = new int[tamanio];
            int media = 0;
            for (int i=0; i < alumnos.Length; i++)
            {
                Console.WriteLine("Introduce la nota del estudiante " + (i + 1) + ":");
                bool notaValida = false; 

                while (!notaValida) 
                {
                    alumnos[i] = int.Parse(Console.ReadLine());

                    if (alumnos[i] < 0 || alumnos[i] > 100)
                    {
                        Console.WriteLine("Error: La nota debe estar entre 0 y 100. Intenta de nuevo.");
                    }
                    else
                    {
                        media += alumnos[i]; 
                        notaValida = true; 
                    }             
                }
            }
            Console.WriteLine("La media es: " + (media / alumnos.Length));
        }

        public static void Apartado14(string hex)
        {
            string[] hexToBin = { //Hexadecimales a binarios
            "0000", "0001", "0010", "0011",
            "0100", "0101", "0110", "0111",
            "1000", "1001", "1010", "1011",
            "1100", "1101", "1110", "1111"
            };

            string binario = "";
            
            #region ConvertirBinario
            //Convierto a binario
            foreach (char c in hex)
            {
                //Convierto el hexadecimal a un decimal. Reutilizo el metodo de la clase EjercicioC que pasandole una cadena hexadecimal me devolvia el entero
                int indice = EjercicioC.Apartado12(c.ToString());
                //Obtengo el numero binario correspondiente y lo concateno a mi cadena
                binario += hexToBin[indice] + " ";
            }
            #endregion
            //Muestro el resultado
            Console.Write($"La cadena binaria equivalente para \"{hex}\" es {binario.Trim()}");
        }
    }
}

