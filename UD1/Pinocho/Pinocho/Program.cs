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

            Jugador pinocho = new Jugador("PI", "Pinocho", 3);
            Jugador pepito = new Jugador("PE", "Pepito", 3);
            Jugador manolo = new Jugador("MA", "Manolo",100);
            List<Jugador> jugadores = new List<Jugador> { pinocho, pepito, manolo /* otros jugadores */ };
            #endregion

            #region TABLERO

            string[,] tablero = new string[8, 8];
            Operaciones.InicializarTablero(tablero, jugadores);
            
            #endregion

            #region MENUYOPCIONES

            bool automatico = true;

            // ProcesaOperacionIndividual realiza las operaciones de ambos jugadores de forma secuencial

            //Pasando "automatico" a ProcesaOperacionIndividual, los movimientos son automaticos (true) o manuales (false)

            Operaciones.ProcesaOperacionIndividual(ref tablero, jugadores, automatico);
                
            Console.ReadKey();
            #endregion

        }
    }
}

