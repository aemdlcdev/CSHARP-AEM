using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioA
{
    internal class EjercicioA
    {
        public static void Apartado1() {
            int mark = 30;
            if (mark > 49)
            {
                Console.WriteLine("PASS");
            }
            else {
                Console.WriteLine("FAIL");
            }
        }

        public static void Apartado2() {
            int num = 2;
            if (num % 2 == 0) { 
                Console.WriteLine("El numero "+ num + " es par");
            }
            else {
                Console.WriteLine("El numero "+ num + " es impar");
            }
        }

        public static void Apartado3(int tope) {
            int suma = 0;
            for (int i = 1; i < tope+1; i++) { 
                suma = suma + i;
            }
            Console.WriteLine("La suma es: " + suma);
            Console.WriteLine("La media es: " + (double)suma / 100);
        }

        public static void Apartado3Mod(int tope) {
            int suma = 0;
            int i = 0;
            while (i < tope+1)
            {
                suma = suma + i;
                i++;
            }
            Console.WriteLine("La suma es: " + suma);
            Console.WriteLine("La media es: " + (double)suma / 100);
        }

        public static void Apartado3Mod2(int tope) { 
            int i = 0;
            int suma = 0;
            do
            {
                suma += i;
                i++;
            }while (i < tope+1);

            Console.WriteLine("La suma es: " + suma);
            Console.WriteLine("La media es: " + (double)suma / 100);
        }

        public static void Apartado3Mod3(int tope) {
            int suma = 0;
            int media = 0;
            for (int i = 1; i < tope + 1; i++)
            {
                if(i % 2 == 0)
                {
                    suma = suma + i;
                    media += 1;
                }
            }
            Console.WriteLine("La suma es: " + suma);
            Console.WriteLine("La media es: " + (double)suma / media);
        }

        public static void Apartado3Mod4(int tope) {
            int suma = 0;
            for (int i = 1; i < tope + 1; i++)
            {
                suma += i * i; //Se suma el cuadrado de cada numero
            }
            Console.WriteLine("La suma de los cuadrados es: " + suma);
        }

        public static void Apartado4() {
            int n = 50000;
            double sumaIzqADer = 0.0;
            double sumaDerAIzq = 0.0;

            //Suma de izquierda a derecha
            for (int i = 1; i <= n; i++)
            {
                sumaIzqADer += 1.0 / i;
            }

            //Suma de derecha a izquierda
            for (int i = n; i >= 1; i--)
            {
                sumaDerAIzq += 1.0 / i;
            }

            Console.WriteLine("Suma de izquierda a derecha: " + sumaIzqADer);
            Console.WriteLine("Suma de derecha a izquierda: " + sumaDerAIzq);

            //Calculo la diferencia
            double diferencia = Math.Abs(sumaIzqADer - sumaDerAIzq); //Uso el Math.Abs para asegurarme que el valor no es negativo (devuelve el valor absoluto)
            Console.WriteLine("Diferencia entre las sumas: " + diferencia);

            if (sumaIzqADer > sumaDerAIzq)
            {
                Console.WriteLine("La suma de derecha a izquierda es mas precisa.");
            }
            else
            {
                Console.WriteLine("La suma de izquierda a derecha es mas precisa.");
            }
        }

        public static double Apartado5(int numTerminos) {

            double suma = 0.0;

            for (int i = 0; i < numTerminos; i++) 
            { 
                double termino = Math.Pow(-1,i) / (2*i+1); // (-1)^i / (2i + 1).

                //La primera parte es para altenar entra suma y resta (exponente impar numero negativo, exponente par numero positivo)
                //La segunda parte es para cambiar el denominador y aumentarlo en 2 por cada vuelta del bucle.
                //Podria crearme una variable y incrementarla en 2, pero asi ahorro variables.

                suma += termino;
            }
            return 4 * suma;
        }

        public static int Aparatado6(int n)
        {
            if (n == 1 || n == 2)
                return 1;  // T(1) y T(2) son 1
            else if (n == 3)
                return 2;  // T(3) es 2
            else
                return Aparatado6(n - 1) + Aparatado6(n - 2) + Aparatado6(n - 3);  // T(n) = T(n-1) + T(n-2) + T(n-3)
        }

        public static void Apartado7() 
        {
            Console.Write("* |");
            for (int i = 1; i <= 9; i++)
            {
                Console.Write("{0,4}", i); // Espacio de 4 caracteres para alineación
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 40)); // Línea de separación

            
            for (int i = 1; i <= 9; i++)// Imprimir las filas de la tabla
            {               
                Console.Write("{0} |", i);//Numero de la fila

                for (int j = 1; j <= 9; j++)//Columna (multiplicaciones)
                {
                    Console.Write("{0,4}", i * j); //Imprimir la multiplicación con formato para alineación
                }        
                Console.WriteLine();//Salto de fila cuando ya ha imprimido las multiplicaciones de un numero
            }
        }
    }
}
