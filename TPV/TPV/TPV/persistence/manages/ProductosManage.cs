using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPV.domain;
using System.Globalization;


namespace TPV.persistence.manages
{
    internal class ProductosManage
    {
        private DataTable dataTable { get; set; }
        private List<Productos> listaProductos { get; set; }

        private DBBroker dbBroker = DBBroker.obtenerAgente();
        private NumberFormatInfo nfi = new NumberFormatInfo();
       
        public ProductosManage()
        {
            dataTable = new DataTable();
            listaProductos = new List<Productos>();
            nfi.NumberDecimalSeparator = ".";
        }

        public List<Productos> LeerProductos()
        {
            Productos producto = null;
            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT * FROM tpv.productos");
            foreach (List<Object> c in aux)
            {
                producto = new Productos(int.Parse(c[0].ToString()), c[1].ToString(), c[2].ToString(), double.Parse(c[3].ToString()), int.Parse(c[4].ToString()));
                this.listaProductos.Add(producto);
            }
            return listaProductos;
        }

        public void ModificarProducto(Productos producto)
        {
            string sql = "UPDATE tpv.productos SET pnombre = '" + producto.nombre + "', palergias = '" + producto.alergias + "', precio = " + producto.precio.ToString(nfi) + ", cantidad = " + producto.cantidad + " WHERE idproductos = " + producto.idProducto;
            DBBroker.obtenerAgente().modificar(sql);
        }

        public void EliminarProducto(Productos producto)
        {
            string sql = "DELETE FROM tpv.productos WHERE idproductos = " + producto.idProducto;
            DBBroker.obtenerAgente().modificar(sql);
        }
    }
}
