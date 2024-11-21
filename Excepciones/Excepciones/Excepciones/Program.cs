using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dividendo = { -4, 8, 15, 16, 23, 42, 65, -56, 34, 97 };
            int[] divisor = { 2, 0, 4, 4, -0, 8, -7, 0, 3, 5 };

            int[] resultado = new int[10];

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    if (divisor[i] < 0)
                    {
                        throw new NumeroNegativoException("No se puede dividir por un número negativo", divisor[i]);
                    }
                    else if (dividendo[i] < 0)
                    {
                        throw new NumeroNegativoException("No se puede dividir un número negativo", dividendo[i]);
                    }

                    resultado[i] = dividendo[i] / divisor[i];
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("Error: " + ex.Message + " " + dividendo[i] + " / " + divisor[i]);
                    resultado[i] = 0;
                }
                catch (NumeroNegativoException ex)
                {
                    Console.WriteLine("Error: " + ex.Message + " | Valor por el que se está intentando dividir: " + ex.ValorNegativo);
                    resultado[i] = 0;
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    resultado[i] = 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    resultado[i] = 0;
                }
            }
        }
    }
}
