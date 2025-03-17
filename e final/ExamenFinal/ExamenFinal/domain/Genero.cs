using ExamenFinal.persistence.manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinal.domain
{
    internal class Genero
    {
        public int idGenero {  get; set; }
        public string nombreGenero { get; set; }

        private GeneroManage gm { get; set; }

        public Genero() { gm = new GeneroManage(); }

        public Genero(int idGenero, string nombre) 
        { 
            this.idGenero = idGenero;
            this.nombreGenero = nombre;
            gm = new GeneroManage();
        }

        public List<Genero> LeerGeneros() 
        {
            return gm.LeerGeneros();
        }

    }
}
