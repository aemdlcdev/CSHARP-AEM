using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioA
{
    internal class EjercicioC
    {

        public static void Apartado9(string str) 
        {
            char[] arrayCaracteres = str.ToCharArray();
            Array.Reverse(arrayCaracteres);
            string strReversa = new string(arrayCaracteres);
            Console.WriteLine("Cadena normal: " + str); 
            Console.WriteLine("Cadena al reves: " + strReversa);
        }

        public static void Apartado10(string str)
        {
            string strM = str.Replace(" ","").ToLower();
            char[] strR = strM.ToCharArray();
            Array.Reverse(strR);
            string strReversa = new string(strR);
            if (strM.Equals(strReversa))
            {
                Console.WriteLine("Es palindromo");
                Console.WriteLine(strM + " | " + strReversa);
            }
        }

        public static void Apartado11(string binario)
        { 
            if(EsBinarioValido(binario))
            {
                int numDecimal = Convert.ToInt32(binario, 2);
                Console.WriteLine($"El equivalente al número decimal para binario \"{binario}\" es {numDecimal}");
            }
            else
            {
                Console.WriteLine($"Error: el valor binario \"{binario}\" es erroneo!");
            }

        }

        public static bool EsBinarioValido(string binario) //Metodo auxiliar que comprueba que la cadena pasada solo contengan o 0 o 1
        {
            foreach (char c in binario)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }
            return true;
        }

        public static int Apartado12(string hexadecimal)
        {
            if(EsHexadecimalValido(hexadecimal))
            {
                int numDecimal = Convert.ToInt32(hexadecimal, 16);
                Console.WriteLine($"El equivalente decimal para este numero hexadecimal \"{hexadecimal}\" es {numDecimal}.");
                return numDecimal;
            }
            else
            {
                Console.WriteLine("Numero hexadecimal invalido!");
                return -1;
            }
        }

        public static bool EsHexadecimalValido(string hexadecimal) //Metodo auxiliar que comprueba que la cadena pasada solo contenga numeros del 0 al 9 y ABCDEF
        {
            foreach (char c in hexadecimal)
            {
                if (!((c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f')))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
