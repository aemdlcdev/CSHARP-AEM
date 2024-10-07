using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioA
{
    internal class EjerciciosE
    {

        public static void Apartado15()
        {
            Console.WriteLine("Introduce el numero de estudiantes:");
            int tamanio = int.Parse(Console.ReadLine());

            double acumulaNotas = 0;

            double[] notas = new double[tamanio];

            for (int i = 0; i < tamanio; i++)
            {
                Console.WriteLine($"Introduce la nota del alumno {i + 1}:");
                double nota = int.Parse(Console.ReadLine());

                
                while (nota < 0 || nota > 100)
                {
                    Console.WriteLine("Nota incorrecta, vuelva a introducir una nota (entre 0 y 100):");
                    nota = int.Parse(Console.ReadLine());
                    acumulaNotas=acumulaNotas+nota;
                }

                notas[i] = nota; 
            }

            Console.WriteLine($"Media de las notas: {acumulaNotas/tamanio}");
            Console.WriteLine($"El minimo es: {notas.Min()}");
            Console.WriteLine($"El maximo es: {notas.Max()}");
            Console.WriteLine("La desviacion es: "+CalcularDesviacionEstandar(notas));
        }

        private static double CalcularDesviacionEstandar(double[] numeros)
        {
            // Calcular la media
            double suma = 0;
            for (int i = 0; i < numeros.Length; i++)
            {
                suma += numeros[i]; // Sumar todos los números
            }
            double media = suma / numeros.Length; // Calcular la media

            // Calcular la suma de las diferencias al cuadrado
            double sumaDiferenciasCuadradas = 0;
            for (int i = 0; i < numeros.Length; i++)
            {
                double diferencia = numeros[i] - media; // Calcular la diferencia
                sumaDiferenciasCuadradas += Math.Pow(diferencia, 2); // Sumar la diferencia al cuadrado
            }

            // Calcular la varianza
            double varianza = sumaDiferenciasCuadradas / numeros.Length; // Calcular la varianza
            return Math.Sqrt(varianza); // Devolver la raíz cuadrada de la varianza
        }

    }
}
