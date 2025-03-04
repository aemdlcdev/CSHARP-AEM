using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGridView.persistence;
using MiniHito1.domain;

namespace MiniHito1.persistence.manages
{
    internal class ProyectoEmpleadoManage
    {
        private DataTable dataTable { get; set; }
        private List<ProyectoEmpleado> listaProyectoEmpleado { get; set; }
        private DBBroker dbBroker = DBBroker.obtenerAgente();

        public ProyectoEmpleadoManage()
        {
            dataTable = new DataTable();
            listaProyectoEmpleado = new List<ProyectoEmpleado>();
        }

        public List<ProyectoEmpleado> LeerProyectoEmpleado()
        {

            ProyectoEmpleado empleado = null;

            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT * FROM mydb.proyecto_has_empleado");

            foreach (List<Object> c in aux)
            {
                empleado = new ProyectoEmpleado(int.Parse(c[0].ToString()), int.Parse(c[1].ToString()), c[2].ToString(), float.Parse(c[3].ToString()),
                   int.Parse(c[4].ToString()));

                this.listaProyectoEmpleado.Add(empleado);
            }

            return listaProyectoEmpleado;

        }

        public void InsertarProyectoEmpleado(ProyectoEmpleado pe)
        {

            string sql = $"INSERT INTO mydb.proyecto_has_empleado ( idproyecto, idempleado, fecha,costes,horas) " +
                $"VALUES ('{pe.idProyecto}', '{pe.idEmpleado}', '{pe.fecha}', '{pe.costes}', '{pe.horas}')";

            DBBroker.obtenerAgente().modificar(sql);
        }
    }
}
