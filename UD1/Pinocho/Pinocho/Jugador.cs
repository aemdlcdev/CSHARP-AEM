using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinocho
{
    internal class Jugador
    {
        private String nombre;
        private int vidas;
        private int peces;

        public Jugador(String nombre, int vidas, int peces) { 
            this.nombre = nombre;
            this.vidas = vidas;
            this.peces = peces;
        }

        public String GetNombre() 
        {
            return nombre;
        }
        public int GetVidas()
        { 
            return vidas;
        }
        public int GetPeces()
        {
            return peces;
        }

        public void GetVidas(int vidas) { 
            this.vidas = vidas;
        }

        public void GetPeces(int peces)
        {
            this.peces = peces;
        }

    }
}
