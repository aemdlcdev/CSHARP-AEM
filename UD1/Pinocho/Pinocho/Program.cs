using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinocho
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region JUGADORES

            Jugador pinocho = new Jugador("PI", "Pinocho", 18);
            Jugador pepito = new Jugador("PE", "Pepito", 18);

            #endregion

            #region TABLERO

            string[,] tablero = new string[8, 8];
            Operaciones.InicializarTablero(tablero, pinocho,pepito);
            
            bool esValido = true;

            #endregion

            #region MENUYOPCIONES

            // Hay dos versiones, una llamando a ProcesaOperacionParalelo y otra a ProcesaOperacionIndividual
            // ProcesaOperacionParalelo realiza las operaciones de ambos jugadores de forma paralela
            // ProcesaOperacionIndividual realiza las operaciones de ambos jugadores de forma secuencial

            //Pasando true o false a ProcesaOperacionIndividual, los movimientos son automaticos (true) o manuales (false)

            do
            {  
                Operaciones.ProcesaOperacionIndividual(ref tablero, pinocho, pepito, ref esValido, true);
                
            } while (esValido);

            Console.ReadKey();
            #endregion

        }
    }
}
