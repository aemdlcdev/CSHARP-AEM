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
            
            bool esValido = false;

            #endregion

            #region MENUYOPCIONES

            do
            {  
                Operaciones.ProcesaOperacionIndividual(ref tablero, pinocho, pepito, ref esValido,true);
                
            } while (!esValido);

            #endregion

        }
    }
}
