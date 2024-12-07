using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TPV.domain
{
    internal class CuentaCliente
    {
        public Clientes cliente { get; set; }
        public ObservableCollection<Productos> productos { get; set; }

        public CuentaCliente(Clientes cliente)
        {
            this.cliente = cliente;
            this.productos = new ObservableCollection<Productos>();
            this.productos.CollectionChanged += Productos_CollectionChanged;
        }

        private void Productos_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnProductosChanged?.Invoke(this, EventArgs.Empty);
        }

        public void AgregarProducto(Productos producto)
        {
            productos.Add(producto);
        }

        public List<string> consumiciones()
        {
            return productos.Select(p => p.nombre).ToList();
        }

        public double Total
        {
            get
            {
                return productos.Sum(p => p.precio);
            }
            set
            {
                OnProductosChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler OnProductosChanged;
    }
}
