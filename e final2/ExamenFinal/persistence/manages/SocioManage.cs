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
    internal class SocioManage
    {

        private DataTable dataTable { get; set; }
        private List<Socio> listaSocios { get; set; }
        private DBBroker dbBroker = DBBroker.obtenerAgente();

        public SocioManage()
        {
            dataTable = new DataTable();
            listaSocios = new List<Socio>();
        }

        public List<Socio> LeerSocios()
        {

            Socio socio = null;

            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT * FROM club_lectura.socio");

            foreach (List<Object> c in aux)
            {
                socio = new Socio(int.Parse(c[0].ToString()), c[1].ToString(), c[2].ToString(), (c[3].ToString()),
                   int.Parse(c[4].ToString()));

                this.listaSocios.Add(socio);
            }

            return listaSocios;

        }

        public void InsertarSocio(Socio socio)
        {

            string sql = $"INSERT INTO club_lectura.socio ( NOMBRE, FEC_NACIMIENTO, EMAIL,TLFNO) " +
                $"VALUES ('{socio.nombreSocio}', '{socio.fec_nacimiento}', '{socio.email}', {socio.tlfno})";

            DBBroker.obtenerAgente().modificar(sql);
        }
        
        public void ModificarSocio(Socio socio)
        {
            string sql = $"UPDATE club_lectura.socio SET NOMBRE = '{socio.nombreSocio}', FEC_NACIMIENTO = '{socio.fec_nacimiento}',  EMAIL = '{socio.email}', tlfno = '{socio.tlfno}' WHERE ID_SOCIO = '{socio.idSocio}'";
            dbBroker.modificar(sql);

            var socioExistente = listaSocios.Find(e => e.idSocio == socio.idSocio);
            if (socioExistente != null)
            {
                socioExistente.nombreSocio = socio.nombreSocio;
                socioExistente.fec_nacimiento = socio.fec_nacimiento;
                socioExistente.email = socio.email;
                socioExistente.tlfno = socio.tlfno;
            }
        }

        public void EliminarSocio(Socio socio)
        {
            string sql = $"DELETE FROM club_lectura.socio WHERE ID_SOCIO = {socio.idSocio}";
            dbBroker.modificar(sql);
            listaSocios.RemoveAll(p => p.idSocio == socio.idSocio);
        }

    }
}
