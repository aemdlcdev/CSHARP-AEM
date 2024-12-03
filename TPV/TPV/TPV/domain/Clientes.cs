using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPV.persistence.manages;

namespace TPV.domain
{

    internal class Clientes
    {
        public int codCliente { get; set; }
        public string email { get; set; }
        public string cnombre { get; set; }
        public int idTicket { get; set; }

        private ClientesManage clientesManage;
        public Clientes(int codCliente, string email, string cnombre, int idTicket)
        {
            this.codCliente = codCliente;
            this.email = email;
            this.cnombre = cnombre;
            this.idTicket = idTicket;
        }

        public Clientes(int codCliente, string nombre)
        { 
            this.codCliente = codCliente;
            this.cnombre = nombre;
        }

        public Clientes(string nombre, string email)
        {
            this.cnombre = nombre;
            this.email = email;
        }

        public Clientes() 
        {
        
        }

        public List<Clientes> LeerClientes()
        {
            clientesManage = new ClientesManage();
            return clientesManage.LeerClientes();
        }

        public void InsertarCliente(Clientes cliente)
        {
            clientesManage = new ClientesManage();
            clientesManage.InsertarCliente(cliente);
        }

    }
}
