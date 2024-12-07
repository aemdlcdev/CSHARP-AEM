using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPV.domain
{
    internal class CuentaCliente
    {
        public Clientes cliente { get; set; }
        public List<Productos> productos { get; set; }

        public CuentaCliente(Clientes cliente)
        {
            this.cliente = cliente;
            productos = new List<Productos>();
        }

        public void AgregarProducto(Productos producto)
        {
            productos.Add(producto);
        }

        public List<String> consumiciones()
        {
            List<String> consumiciones = new List<string>();
            foreach (Productos p in productos)
            {
                consumiciones.Add(p.nombre);
            }
            return consumiciones;
        }


        public double Total
        {
            get
            {
                return productos.Sum(p => p.precio);
            }
        }
    }
}
