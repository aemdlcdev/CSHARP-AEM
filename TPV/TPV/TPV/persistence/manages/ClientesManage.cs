using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPV.domain;

namespace TPV.persistence.manages
{
    internal class ClientesManage
    {

        private DataTable dataTable { get; set; }

        private List<Clientes> listaClientes { get; set; }

        public ClientesManage() 
        { 
            dataTable = new DataTable();
            listaClientes = new List<Clientes>();
        }

        public List<Clientes> LeerClientes()
        {

            Clientes cliente = null;

            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT codcliente, cnombre FROM tpv.clientes");

            foreach (List<Object> c in aux)
            {
                cliente = new Clientes(int.Parse(c[0].ToString()), c[1].ToString());

                this.listaClientes.Add(cliente);
            }
            return listaClientes;
        }

        public void InsertarCliente(Clientes cliente)
        {
            string sql = "INSERT INTO tpv.clientes (email, cnombre) VALUES ('" + cliente.email + "', '" + cliente.cnombre + "')";
            DBBroker.obtenerAgente().modificar(sql);
        }


    }
}
