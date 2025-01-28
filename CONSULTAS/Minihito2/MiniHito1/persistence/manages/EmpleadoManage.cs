using DataGridView.persistence;
using MiniHito1.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHito1.persistence.manages
{
    internal class EmpleadoManage
    {
        private DataTable dataTable { get; set; }
        private List<Empleado> listaEmpleados { get; set; }
        private DBBroker dbBroker = DBBroker.obtenerAgente();

        public EmpleadoManage()
        {
            dataTable = new DataTable();
            listaEmpleados = new List<Empleado>();
        }

        public List<Empleado> LeerEmpleados()
        {

            Empleado empleado = null;

            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT * FROM mydb.empleado");

            foreach (List<Object> c in aux)
            {
                empleado = new Empleado(int.Parse(c[0].ToString()), c[1].ToString(), c[2].ToString(), float.Parse(c[3].ToString()),
                   int.Parse(c[4].ToString()), int.Parse(c[5].ToString()));

                this.listaEmpleados.Add(empleado);
            }

            return listaEmpleados;

        }

        public void InsertarEmpleado(Empleado empleado)
        {

            string sql = $"INSERT INTO mydb.empleado ( nombreemp, apellidosemp, csr,idusuario,idrol) " +
                $"VALUES ('{empleado.nombre}', '{empleado.apellidos}', '{empleado.csr}', '{empleado.idUsuario}', '{empleado.idRol}')";

            DBBroker.obtenerAgente().modificar(sql);
        }


        public void ModificarEmpleado(Empleado empleado)
        {
            string sql = $"UPDATE mydb.empleado SET nombreemp = '{empleado.nombre}', apellidosemp = '{empleado.apellidos}',  csr = '{empleado.csr}', idrol = '{empleado.idRol}' WHERE idempleado = '{empleado.idEmpleado}'";
            dbBroker.modificar(sql);

            var empleadoExistente = listaEmpleados.Find(e => e.idEmpleado == empleado.idEmpleado);
            if (empleadoExistente != null)
            {
                empleadoExistente.nombre = empleado.nombre;
                empleadoExistente.apellidos = empleado.apellidos;
                empleadoExistente.csr = empleado.csr;
                empleadoExistente.idRol = empleado.idRol;
            }
        }

    }
}
