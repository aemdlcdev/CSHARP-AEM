using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinocho
{
    internal class Jugador
    {
        private string _nombre;
        private string _nombreCompleto;
        private int _vidas;
        private int _peces;
        private int _fila; // Posición en fila del jugador
        private int _columna; // Posición en columna del jugador

        public Jugador(string nombre, string nombreCompleto, int vidasIniciales)
        {
            this._nombre = nombre;
            this._nombreCompleto = nombreCompleto;
            this._vidas = vidasIniciales;
            this._peces = 0;
            this._fila = 0; // Posición inicial (puedes cambiarla según la lógica del juego)
            this._columna = 0; // Posición inicial (puedes cambiarla según la lógica del juego)
        }

        public string GetNombre()
        {
            return _nombre;
        }

        public string GetNombreCompleto()
        {
            return _nombreCompleto;
        }

        public int GetVidas()
        {
            return _vidas;
        }

        public void SetVidas(int vidas)
        {
            this._vidas = vidas;
        }

        public int GetPeces()
        {
            return _peces;
        }

        public void SetPeces(int peces)
        {
            this._peces = peces;
        }

        // Métodos para manejar la posición en el tablero
        public int GetFila()
        {
            return _fila;
        }

        public void SetFila(int fila)
        {
            this._fila = fila;
        }

        public int GetColumna()
        {
            return _columna;
        }

        public void SetColumna(int columna)
        {
            this._columna = columna;
        }
    }
}
