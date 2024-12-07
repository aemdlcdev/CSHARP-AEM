using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPV.persistence.manages;

namespace TPV.domain
{
    internal class Productos
    {
        public int idProducto { get; set; }
        public String nombre { get; set; }
        public String alergias { get; set; }
        public double precio { get; set; }
        public int cantidad { get; set; }

        private ProductosManage productosManage;

        public string Imagen { get; set; }

        public Productos(int idProducto, string nombre, string alergias, double precio, int cantidad, string imagen)
        {
            this.idProducto = idProducto;
            this.nombre = nombre;
            this.alergias = alergias;
            this.precio = precio;
            this.cantidad = cantidad;
            this.Imagen = imagen;
        }

        public Productos(string nombre, string alergias, double precio, int cantidad, string imagen)
        {
            this.nombre = nombre;
            this.alergias = alergias;
            this.precio = precio;
            this.cantidad = cantidad;
            this.Imagen = imagen;
        }

        public Productos(int idProducto, String nombre, String alergias, double precio, int cantidad)
        {
            this.idProducto = idProducto;
            this.nombre = nombre;
            this.precio = precio;
            this.alergias = alergias;
            this.cantidad = cantidad;
        }

        public Productos( String nombre, String alergias, double precio, int cantidad)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.alergias = alergias;
            this.cantidad = cantidad;
        }

        public Productos()
        {

        }

        public List<Productos> LeerProductos() 
        {
            productosManage = new ProductosManage();
            return productosManage.LeerProductos();
        }

        public void InsertarProducto(Productos producto)
        {
            productosManage = new ProductosManage();
            productosManage.InsertarProducto(producto);
        }
        public void ModificarProducto(Productos producto)
        {
            productosManage = new ProductosManage();
            productosManage.ModificarProducto(producto);
        }

        public void EliminarProducto(Productos producto)
        {
            productosManage = new ProductosManage();
            productosManage.EliminarProducto(producto);
        }

    }
}
