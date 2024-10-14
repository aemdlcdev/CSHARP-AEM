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
            // Le pasamos una abrebiatura o "id", el nombre completo, las vidas iniciales, y los saltos iniciales
            Jugador pinocho = new Jugador("PI", "Pinocho", 30, 18);
            Jugador pepito = new Jugador("PE", "Pepito", 30, 18);
            Jugador gapetto = new Jugador("GA", "Gapetto",30, 18);
            Jugador figaro = new Jugador("FI", "Figaro", 30, 18);

            // Añadimos los jugadores a una lista, podemos añadir los que queramos, para probar he añadido 4
            List<Jugador> jugadores = new List<Jugador> { pinocho, pepito, gapetto, figaro  /* otros jugadores */ };
            #endregion

            #region TABLERO

            string[,] tablero = new string[12, 12]; // Tablero de 12x12, puedes cambiarl el tamaño sin problemas
            Operaciones.InicializarTablero(tablero, jugadores);
            
            #endregion

            #region MENUYOPCIONES

            bool automatico = true;

            // ProcesaOperacionIndividual realiza las operaciones de ambos jugadores de forma secuencial

            // Pasando "automatico" a ProcesaOperacionIndividual, los movimientos son automaticos (true) o manuales (false)

            Operaciones.ProcesaOperacionIndividual(ref tablero, jugadores, automatico);
                
            Console.ReadKey();
            #endregion

        }
    }
}

