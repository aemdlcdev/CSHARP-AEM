using DataGridView.persistence;
using ExamenFinal.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinal.persistence.manages
{
    internal class GeneroManage
    {
        private DataTable dataTable { get; set; }
        private List<Genero> listaGeneros { get; set; }
        private DBBroker dbBroker = DBBroker.obtenerAgente();

        public GeneroManage() 
        {
            dataTable = new DataTable();
            listaGeneros = new List<Genero>();
        }

        public List<Genero> LeerGeneros()
        {

            Genero genero = null;

            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT * FROM club_lectura.genero");

            foreach (List<Object> c in aux)
            {
                genero = new Genero(int.Parse(c[0].ToString()), c[1].ToString());

                this.listaGeneros.Add(genero);
            }

            return listaGeneros;
        }

    }
}
