using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioA
{
    internal class Program
    {
        static void Main(string[] args)
        {

            EjercicioA.Apartado1();
            Console.WriteLine();
            EjercicioA.Apartado2();
            Console.WriteLine();
            EjercicioA.Apartado3(100);
            Console.WriteLine();
            EjercicioA.Apartado3Mod(100);
            Console.WriteLine();
            EjercicioA.Apartado3Mod2(100);
            Console.WriteLine();
            EjercicioA.Apartado7();
            Console.WriteLine();
            EjercicioB.Apartado8();
            Console.WriteLine();
            EjercicioC.Apartado9("hola que tal");
            Console.WriteLine();
            EjercicioC.Apartado10("Dabale arroz a la zorra el abad");
            Console.WriteLine();
            EjercicioC.Apartado11("1011");
            Console.WriteLine("");
            EjercicioC.Apartado12("1A");
            Console.ReadKey();
        }
    }
}
