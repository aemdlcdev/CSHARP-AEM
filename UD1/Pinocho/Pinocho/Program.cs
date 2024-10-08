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
            //Jugadores
            Jugador pinocho = new Jugador("PI", 18, 0);
            Jugador pepito = new Jugador("PE", 18, 0);

            #region TABLERO
            string[,] tablero = new string[8, 8];
            Operaciones.InicializarTablero(tablero, pinocho,pepito);
            int filas = 0;
            int columnas =0;
            bool esValido = false;

            #endregion

            #region MENUYOPCIONES

            do
            {
                Operaciones.ProcesaOperacion(ref tablero, ref filas, ref columnas, pinocho, pepito, ref esValido);   
            } while (!esValido);

            #endregion

            

        }
    }
}
