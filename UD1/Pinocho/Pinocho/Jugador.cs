using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinocho
{
    internal class Jugador
    {
        private string nombre;
        private int vidas;
        private int peces;
        private int fila; // Posición en fila del jugador
        private int columna; // Posición en columna del jugador

        public Jugador(string nombre, int vidasIniciales)
        {
            this.nombre = nombre;
            this.vidas = vidasIniciales;
            this.peces = 0;
            this.fila = 0; // Posición inicial (puedes cambiarla según la lógica del juego)
            this.columna = 0; // Posición inicial (puedes cambiarla según la lógica del juego)
        }

        public string GetNombre()
        {
            return nombre;
        }

        public int GetVidas()
        {
            return vidas;
        }

        public void SetVidas(int vidas)
        {
            this.vidas = vidas;
        }

        public int GetPeces()
        {
            return peces;
        }

        public void SetPeces(int peces)
        {
            this.peces = peces;
        }

        // Métodos para manejar la posición en el tablero
        public int GetFila()
        {
            return fila;
        }

        public void SetFila(int fila)
        {
            this.fila = fila;
        }

        public int GetColumna()
        {
            return columna;
        }

        public void SetColumna(int columna)
        {
            this.columna = columna;
        }
    }
}
