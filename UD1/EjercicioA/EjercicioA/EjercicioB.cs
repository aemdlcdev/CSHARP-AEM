using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioA
{
    internal class EjercicioB
    {
        public static void Apartado8()
        {
            Console.WriteLine("Introduce el radio de la esfera:");
            double radio = double.Parse(Console.ReadLine());

            double area = 4 * Math.PI * Math.Pow(radio, 2);
            double volumen = (4.0 / 3.0) * Math.PI * Math.Pow(radio, 3);

            Console.WriteLine("El área de la superficie es: " + area);
            Console.WriteLine("El volumen de la esfera es: " + volumen);
        }
    }
}
